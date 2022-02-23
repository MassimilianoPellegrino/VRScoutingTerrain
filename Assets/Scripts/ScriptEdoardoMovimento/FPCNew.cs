using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
#pragma warning disable 618, 649
namespace UnityStandardAssets.Characters.FirstPerson {
    [RequireComponent(typeof (CharacterController))]
    [RequireComponent(typeof (AudioSource))]
    
    public class FPCNew : MonoBehaviour
    {
    //VALORI SERIALI FIRSTPERSONCONTROLLER
//NUOVO 
    [SerializeField] private float m_JumpSpeed;
    [SerializeField] private float m_StickToGroundForce;
    [SerializeField] private float m_GravityMultiplier;
    private bool m_Jump;
    private bool m_PreviouslyGrounded;
    private Vector3 m_OriginalCameraPosition;
    private bool m_Jumping;
//NUOVO
    //FINE VALORI SERIALI FIRSTPERSONCONTROLLER

//VALORI SERIALI FPC
   public bool CanMove {get; private set; } = true;
   private bool IsSprinting => canSprint && Input.GetKey(sprintKey);
   private bool ShouldJump=> Input.GetKey(jumpKey) && characterController.isGrounded;
   private bool ShouldCrouch => Input.GetKey(crouchKey) && !duringCrouchAnimation && characterController.isGrounded;
   private bool ShouldSleep => Input.GetKey(sleepKey) && !duringSleepAnimation && characterController.isGrounded;
   
   [Header("Functional Options")]
   [SerializeField] private bool canSprint = true;
   [SerializeField] private bool canJump = true;
   [SerializeField] private bool canCrouch = true;
   [SerializeField] private bool canSleep = true;
   [SerializeField] private bool canUseHeadbob = true;
   [SerializeField] private bool WillSlideOnSlopes = true;
   [SerializeField] private bool canZoom = true;
   [SerializeField] private bool useFootSteps = true;


   [Header("Controls")]
   [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;
   [SerializeField] private KeyCode jumpKey = KeyCode.Alpha1;
   [SerializeField] private KeyCode crouchKey = KeyCode.Space;
   [SerializeField] private KeyCode sleepKey = KeyCode.Z;
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
   [SerializeField, Range(1,100)] private float upperLookLimitSleep = 40.0f;
   [SerializeField, Range(1,100)] private float lowerLookLimitSleep = 40.0f;
   [SerializeField, Range(1,100)] private float LookSleep = 40.0f;

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

   [Header("Sleep Parameters")]
   [SerializeField] private float sleepHeight = 0.1f;    //Sleep height
   [SerializeField] private float standingHeightNotSleep = 2f;     // Stand Height
   private bool isSleeping;    // Is sleeping

   private bool dialogueON;
   private bool diaryON;
   private bool inventoryON;
   private bool pauseON;

   private bool duringSleepAnimation;    //Is in sleep animation
   [SerializeField] private float timeToSleep = 0.5f;  //Time to sleep/stand
   [SerializeField] private Vector3 standingCenterNotSleep = new Vector3(0,0,0);  //standing center point
   [SerializeField] private Vector3 sleepingCenter = new Vector3(0,0.1f,0); // sleeping center point
   

   [Header("Headbob Parameters")]
   [SerializeField] private float walkBobSpeed = 14f;
   [SerializeField] private float walkBobAmount = 0.05f;
   [SerializeField] private float springBobSpeed = 18f;
   [SerializeField] private float springBobAmount = 0.1f;
   [SerializeField] private float crouchBobSpeed = 8f;
   [SerializeField] private float crouchBobAmount = 0.025f;
   [SerializeField] private float sleepBobAmount = 0.025f;
   private float defaultYPos = 0;
   private float timer;

   [Header("Zoom Parameters")]
   [SerializeField] private float timeToZoom = 0.3f;
   [SerializeField] private float zoomFOV = 30f;
   private float defaultFOV;
   private Coroutine zoomRoutine;

   [Header("Footstep Parameters")]
   [SerializeField] private float baseStepSpeed = 0.5f;
   [SerializeField] private float crouchStepMultipler = 1.5f;
   [SerializeField] private float sprintStepMultipler = 0.6f;
   [SerializeField] private float sleepStepMultipler = 2f;
   [SerializeField] private AudioSource footstepAudioSource = default;
   [SerializeField] private AudioClip[] grassClips = default;
   [SerializeField] private AudioClip[] metalClips = default;
   [SerializeField] private AudioClip[] woodClips = default;
   [SerializeField] private AudioClip[] terrainClips = default;
   [SerializeField] private AudioClip[] gravelClips = default;
   [SerializeField] private AudioClip[] sandClips = default;
   [SerializeField] private AudioClip[] m_JumpSound = default;           // the sound played when character leaves the ground.
   [SerializeField] private AudioClip[] m_LandSound = default;           // the sound played when character touches back on ground.

   private float footstepTimer = 0;
   private float GetCurrentOffset => isCrouching ? baseStepSpeed * crouchStepMultipler : IsSprinting ? baseStepSpeed * sprintStepMultipler : isSleeping ? baseStepSpeed*sleepStepMultipler : baseStepSpeed;


   //SLIDING PARAMETERS
   private Vector3 hitPointNormal; // normal position della superficie, angolo floor
   //FINE VALORI SERIALI FPC

   //AWAKE FPC
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
   private float rotationY = 0;


    void Awake()
    {
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        defaultYPos = playerCamera.transform.localPosition.y;
        defaultFOV = playerCamera.fieldOfView;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
//NUOVO
   //PARAMETRI FIRSTPERSONCONTROLLER
        m_Jumping = false;
    //FINE PARAMETRI FIRSTPERSONCONTROLLER
//NUOVO  
    }
    //FINE AWAKE FPC

    // Update is called once per frame
    void Update()
    {
        //UPDATE FPC
           if(CanMove)
        {
            if (MyDialogueSystem.dialogueON)
                dialogueON = true;
            else
                dialogueON = false;

            if (InventoryUI.InventarioON)
                inventoryON = true;
            else
                inventoryON = false;

            if (Diary.DiarioON)
                diaryON = true;
            else
                diaryON = false;

            if (PauseMenu.GameIsPaused)
                pauseON = true;
            else
                pauseON = false;

            HandleMovementInput();
            HandleMouseLock();

            HandleUIMouseLock(dialogueON);
            HandleUIMouseLock(inventoryON);
            HandleUIMouseLock(diaryON);
            HandleUIMouseLock(pauseON);

            if (canJump)
               HandleJump();

            if(canCrouch)
              HandleCrouch();
            
           if(canSleep)
              HandleSleep();

            if(canUseHeadbob)
              HandleHeadbob();

            if(canZoom)
              HandleZoom();

            if(useFootSteps)
              Handle_Footsteps();
         
          
            ApplyFinalMovement();

        }
        //FINE UPDATE FPC

        //UPDATE FIRSTPERSONCONTROLLER
        if (!m_PreviouslyGrounded && characterController.isGrounded)
        {   
            PlayLandingSound(); 
            m_Jumping = false;
            Debug.Log("Land Sound");  
        }
       
        m_PreviouslyGrounded = characterController.isGrounded;
        //FINE UPDTATE FIRSTPERSONCONTROLLER     
    }

    //FUNZIONI FIRSTPERSONCONTROLLER
            private void PlayLandingSound()
        {
               footstepAudioSource.PlayOneShot(m_LandSound[Random.Range(0,m_LandSound.Length-1)]);    
 
        }

        private void FixedUpdate()
        {

            if (characterController.isGrounded)
            {
                if (m_Jump)
                {
                    PlayJumpSound();
                    m_Jump = false;
                    m_Jumping = true;
                    Debug.Log("Jump Sound");
                }
            }
   
        }

        private void PlayJumpSound()
        {
            footstepAudioSource.PlayOneShot(m_JumpSound[Random.Range(0,m_JumpSound.Length-1)]);
            
        }

    //FINE FUNZIONI FIRST PERSONCONTROLLER
    
    //INIZIO FUNIONI FPC
      private void HandleMovementInput()
    {
        currentInput = new Vector2((IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : isCrouching ? crouchSpeed : walkSpeed) * Input.GetAxis("Horizontal"));
        
        float moveDirectionY = moveDirection.y;
        moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
        moveDirection.y = moveDirectionY;
    }

    private bool UIInactive()
    {
        if (!isSleeping && !dialogueON && !diaryON && !inventoryON && !pauseON)
            return true;
        else
            return false;
    }

    private void HandleMouseLock()
    {
      if(UIInactive())
       {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX,0,0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
       }
      else if(isSleeping)
      {
        rotationY -= Input.GetAxis("Mouse X") * lookSpeedX;
        rotationY = Mathf.Clamp(-upperLookLimitSleep, lowerLookLimitSleep, rotationY);
        playerCamera.transform.localRotation = Quaternion.Euler(-LookSleep,0,0);
        transform.rotation *= Quaternion.Euler(0, 0,0);
       }

    }

    private void HandleUIMouseLock(bool isUIActive)
    {
        if (isUIActive)
        {
            float camerax = Camera.main.transform.eulerAngles.x;

            rotationY -= Input.GetAxis("Mouse X") * lookSpeedX;
            rotationY = Mathf.Clamp(-upperLookLimitSleep, lowerLookLimitSleep, rotationY);
            playerCamera.transform.localRotation = Quaternion.Euler(camerax, 0, 0);
            transform.rotation *= Quaternion.Euler(0, 0, 0);
        }
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

    private void HandleSleep()
    {
        if(ShouldSleep)
        StartCoroutine(SleepStand());
    
    }

    private void HandleHeadbob()
    {
        if(!characterController.isGrounded) return;

        if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
        {
            timer += Time.deltaTime * (isCrouching ? crouchBobSpeed : IsSprinting ? springBobSpeed : isSleeping ? sleepBobAmount : walkBobSpeed );
            playerCamera.transform.localPosition = new Vector3(
            playerCamera.transform.localPosition.x,
            defaultYPos + Mathf.Sin(timer) * (isCrouching ? crouchBobAmount : IsSprinting ? springBobAmount : isSleeping ? sleepBobAmount : walkBobAmount),
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

     private void Handle_Footsteps()
    {
        if(!characterController.isGrounded) return;
        if(currentInput == Vector2.zero) return;

        footstepTimer -= Time.deltaTime;

        if(footstepTimer <= 0)
        {
            if(Physics.Raycast(playerCamera.transform.position, Vector3.down, out RaycastHit hit,2))
            {
                switch(hit.collider.tag)
                {
                    case "Footsteps/WOOD":
                    footstepAudioSource.PlayOneShot(woodClips[Random.Range(0,woodClips.Length-1)]);
                    break;
                    case "Footsteps/GRAVEL":
                    footstepAudioSource.PlayOneShot(gravelClips[Random.Range(0,gravelClips.Length-1)]);
                    break;
                    case "Footsteps/METAL":
                    footstepAudioSource.PlayOneShot(metalClips[Random.Range(0,metalClips.Length-1)]);
                    break;
                    case "Footsteps/TERRAIN":
                    footstepAudioSource.PlayOneShot(terrainClips[Random.Range(0,terrainClips.Length-1)]);
                    break;
                    case "Footsteps/SAND":
                    footstepAudioSource.PlayOneShot(sandClips[Random.Range(0,sandClips.Length-1)]);
                    break;
                    case "Footsteps/GRASS":
                    footstepAudioSource.PlayOneShot(grassClips[Random.Range(0,grassClips.Length-1)]);
                    break;
                    default:
                    footstepAudioSource.PlayOneShot(grassClips[Random.Range(0,grassClips.Length-1)]);
                    break;
                }
            }

         footstepTimer = GetCurrentOffset;
        }
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

    private IEnumerator SleepStand()
    {
        if(isSleeping && Physics.Raycast(Vector3.up, playerCamera.transform.position, 1f))
           yield break;

        duringSleepAnimation = true;

        float timeElapsed = 0;
        float targetHeight = isSleeping ? standingHeightNotSleep : sleepHeight;
        float currentHeight = characterController.height;
        Vector3 targetCenter = isSleeping ? standingCenterNotSleep : sleepingCenter;
        Vector3 currentCenter = characterController.center;

        while(timeElapsed < timeToSleep)
        {
            characterController.height = Mathf.Lerp(currentHeight, targetHeight, timeElapsed/timeToSleep);
            characterController.center = Vector3.Lerp(currentCenter, targetCenter, timeElapsed/timeToSleep);
            timeElapsed += Time.deltaTime;
            
            yield return null;
        }

        characterController.height = targetHeight;
        characterController.center = targetCenter;

        isSleeping = !isSleeping;


        duringSleepAnimation = false;
       
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
    //FINE FUNZIONI FPC
    }
}


