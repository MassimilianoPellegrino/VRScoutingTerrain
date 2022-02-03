using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPC : MonoBehaviour
{
   public bool CanMove {get; private set; } = true;
   private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
   private bool ShouldJump=> Input.GetKey(jumpKey) && characterController.isGrounded;
   private bool ShouldCrouch => Input.GetKey(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;

   [Header("Functional Options")]
   [SerializeField] private bool canSprint = true;
   [SerializeField] private bool canJump = true;
   [SerializeField] private bool canCrouch = true;
   [SerializeField] private bool canUseHeadbob = true;
   [SerializeField] private bool WillSlideOnSlopes = true;
   [SerializeField] private bool canZoom = true;


   [Header("Controls")]
   [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
   [SerializeField] private KeyCode jumpKey = KeyCode.Alpha1;
   [SerializeField] private KeyCode crouchKey = KeyCode.Space;
   [SerializeField] private KeyCode zoomKey = KeyCode.Mouse1;
  

   [Header("Movement Parameters")]
   [SerializeField] private float walkSpeed = 3.0f;
   [SerializeField] private float sprintSpeed = 6.0f;
   [SerializeField] private float crouchSpeed = 1.5f;
   [SerializeField] private float slopeSpeed = 8f;

   [Header("Look Parameters")]
   [SerializeField, Range(1,10)] private float lookSpeedX = 2.0f;
   [SerializeField, Range(1,10)] private float lookSpeedY = 2.0f;
   [SerializeField, Range(1,100)] private float upperLookLimit = 80.0f;
   [SerializeField, Range(1,100)] private float lowerLookLimit = 80.0f;

   [Header("Jumping Parameters")]
   [SerializeField] private float jumpForce = 8.0f;
   [SerializeField] private float gravity = 30.0f;

   [Header("Crouch Parameters")]
   [SerializeField] private float crouchHeight = 0.5f;    //Crouch height
   [SerializeField] private float standingHeight = 2f;     // Stand Height
   private bool isCrouching;    // Is crouching
   private bool duringCrouchAnimation;    //Is in crouch animation
   [SerializeField] private float timeToCrouch = 0.25f;  //Time to crouch/stand
   [SerializeField] private Vector3 standingCenter = new Vector3(0,0,0);  //standing center point
   [SerializeField] private Vector3 crouchingCenter = new Vector3(0,0.5f,0); // crouching center point

   [Header("Headbob Parameters")]
   [SerializeField] private float walkBobSpeed = 14f;
   [SerializeField] private float walkBobAmount = 0.05f;
   [SerializeField] private float springBobSpeed = 18f;
   [SerializeField] private float springBobAmount = 0.1f;
   [SerializeField] private float crouchBobSpeed = 8f;
   [SerializeField] private float crouchBobAmount = 0.025f;
   private float defaultYPos = 0;
   private float timer;

   [Header("Headbob Parameters")]
   [SerializeField] private float timeToZoom = 0.3f;
   [SerializeField] private float zoomFOV = 30f;
   private float defaultFOV;
   private Coroutine zoomRoutine;

   //SLIDING PARAMETERS
   private Vector3 hitPointNormal; // normal position della superficie, angolo floor

   private bool IsSliding
   {
       get 
       {
          // Debug.DrawRay(transform.position, Vector3.down, Color.red);
           if(characterController.isGrounded && Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit, 2f))
           {
             hitPointNormal = slopeHit.normal;
             return Vector3.Angle(hitPointNormal, Vector3.up) > characterController.slopeLimit;
           } 
           else 
           {
             return false;
           }
       }
   }



   private Camera playerCamera;
   private CharacterController characterController;

   private Vector3 moveDirection;
   private Vector2 currentInput;

   private float rotationX = 0;

    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        defaultYPos = playerCamera.transform.localPosition.y;
        defaultFOV = playerCamera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove)
        {
            HandleMovementInput();
            HandleMouseLock();

            if(canJump)
               HandleJump();

            if(canCrouch)
              HandleCrouch();

            if(canUseHeadbob)
              HandleHeadbob();

            if(canZoom)
              HandleZoom();

         
          
            ApplyFinalMovement();

        }
    }

    private void HandleMovementInput()
    {
        currentInput = new Vector2((IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Horizontal"));
        
        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private void HandleMouseLock()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX,0,0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
    }

    private void HandleJump()
    {
        if(ShouldJump)
        moveDirection.y = jumpForce;
    }

    private void HandleCrouch()
    {
        if(ShouldCrouch)
        StartCoroutine(CrouchStand());
    }

    private void HandleHeadbob()
    {
        if(!characterController.isGrounded) return;

        if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : IsSprinting ? springBobSpeed : walkBobSpeed);
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : IsSprinting ? springBobAmount : walkBobAmount),
                playerCamera.transform.localPosition.z);
        }
    }

    private void HandleZoom()
    { 
        if(Input.GetKeyDown(zoomKey))
        {
            if(zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
          zoomRoutine = StartCoroutine(ToggleZoom(true));
        }

            if(Input.GetKeyUp(zoomKey))
        {
            if(zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
          zoomRoutine = StartCoroutine(ToggleZoom(false));
        }
    }


    private void ApplyFinalMovement()
    {
        if(!characterController.isGrounded)
        moveDirection.y -= gravity * Time.deltaTime;

        if(WillSlideOnSlopes && IsSliding)
           moveDirection += new Vector3(hitPointNormal.x,  -hitPointNormal.y, hitPointNormal.z) * slopeSpeed;

        characterController.Move(moveDirection * Time.deltaTime);

    }

    private IEnumerator CrouchStand()
    {
        if(isCrouching && Physics.Raycast(playerCamera.transform.position, Vector3.up,1f))
           yield break;

        duringCrouchAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isCrouching ? standingHeight : crouchHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isCrouching ? standingCenter : crouchingCenter;
        Vector3 currentCenter = characterController.center;

        while(timeElapsed < timeToCrouch)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToCrouch);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToCrouch);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isCrouching = !isCrouching;


        duringCrouchAnimation = false;
    }

    private IEnumerator ToggleZoom(bool isEnter)
    {
      float targetFOV = isEnter ? zoomFOV : defaultFOV;
      float startingFOV = playerCamera.fieldOfView;
      float timeElapsed = 0;

      while(timeElapsed < timeToZoom)
      {
          playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
          timeElapsed += Time.deltaTime;
          yield return null;
      }

      playerCamera.fieldOfView = targetFOV;
      zoomRoutine = null;
    }
}
