using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyAIMovement : MonoBehaviour
{
    Animator animator;
    int countTrue = 0;
    int countFalse = 0;
    public float movementSpeed = 200f;
    public float rotationSpeed = 100f;

    private bool isMoving = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;

    Rigidbody rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving == false)
        {
            StartCoroutine(Moving());
        }
        if(isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if(isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if(isMoving == true)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }

    }

    IEnumerator Moving()
    {
        int rotationTime = Random.Range(1,3);
        int rotateWait = Random.Range(1,3);
        int rotateDirection = Random.Range(1,3);
        int moveWait = Random.Range(1,3);
        int moveTime = Random.Range(1,3);

        isMoving = true;

        yield return new WaitForSeconds(moveWait);

        isMoving = true;

        yield return new WaitForSeconds(moveTime);

        isMoving = false;

        yield return new WaitForSeconds(rotateWait);

        if(rotateDirection == 1)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingLeft = false;
            Debug.Log("+1 con 1");
            countTrue += 2;
            countFalse--;
        
        }

        if(rotateDirection == 2)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotationTime);
            isRotatingRight = false;
            Debug.Log("+1 con 2");
            countTrue--;
            countFalse++;      
        }

        if(countTrue >= 2)
        {
            Debug.Log("Switch true");
            animator.SetBool("IsMoving", true);
        } else
        {
            Debug.Log("No switch");
            animator.SetBool("IsMoving", false);
        }
        if(countFalse >= 3)
        {
            Debug.Log("Switch false");
            animator.SetBool("IsMoving", false);
        } else
        {
            Debug.Log("No switch");
            animator.SetBool("IsMoving", true);
        }

        isMoving = false;
    
    }
}
