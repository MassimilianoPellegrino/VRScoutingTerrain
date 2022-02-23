using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator animator;
    MyQuestGiver questGiver;
    int questIndex;
    bool questNotOver;
    bool questCompleted;

    int animIndex = 0;

    public AudioSource missioneNonCompletata;
    public AudioSource missioneCompletata;

 void Start()
 {
     animator = GetComponent<Animator>();
     questGiver = GetComponent<MyQuestGiver>();
 }

 void Update()
 {
        questIndex = questGiver.getQuestIndex();

        if (Interaction.PointingNPC != null)
        {

            if (Input.GetKey(KeyCode.E))
                


            if (Input.GetKeyDown(KeyCode.E) && animIndex == 0)
            {
                

                animator.SetBool("IsActive", true);
                animIndex++;
            }
        }

        if (Input.GetMouseButtonDown(0) && animIndex == 1)
        {
            animator.SetBool("isStopped", true);
            animIndex++;
        }
        

        if (Input.GetKeyUp(KeyCode.E) && questNotOver)
        {
            animator.SetBool("isInteracting2", false);
            questNotOver = false;
        }

        if (Input.GetKeyUp(KeyCode.E) && questCompleted)
        {
            animator.SetBool("isInteracting3", false);
            questCompleted = false;
        }
        
    }

    public void StartInteracting2()
    {
        animator.SetBool("isInteracting2", true);

        missioneNonCompletata.Play();

        questNotOver = true;
    }

    public void StartInteracting3()
    {
        animator.SetBool("isInteracting3", true);

        missioneCompletata.Play();

        questCompleted = true;
    }
}
