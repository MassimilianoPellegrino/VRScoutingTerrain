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
            if (Input.GetKeyDown(KeyCode.E) && questIndex == -1)
            {
                animator.SetBool("IsActive", true);
            }
        }

        if (Input.GetMouseButtonDown(0) && questIndex == 0)
        {
            animator.SetBool("isStopped", true);
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
        questNotOver = true;
    }

    public void StartInteracting3()
    {
        animator.SetBool("isInteracting3", true);
        questCompleted = true;
    }
}
