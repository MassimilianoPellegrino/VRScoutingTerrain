using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
 Animator animator;
 int counter = 0;

 void Start()
 {
     animator = GetComponent<Animator>();

 }

 void Update()
 {
     if(Input.GetKey("e") && counter == 0)
     {
         animator.SetBool("IsActive", true);
     } 

     if(Input.GetMouseButtonDown(0))
     {
         animator.SetBool("isStopped",true);
         counter++;
     } 
     if(Input.GetKey("e") && counter >= 1)
     {
         animator.SetBool("isInteracting2", true);
     } else
     {
         animator.SetBool("isInteracting2", false);
     }

 }
}
