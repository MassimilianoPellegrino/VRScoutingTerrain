using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals
{
    //sarebbe lo script di verifica delle missioni
  public Quest Quest {get; set;}  //chiama quest e devo assegnare al goal
  public string Description {get; set; }
  public bool Completed {get; set; }
  public int CurrentAmount {get; set; }
  public int RequiredAmount {get; set; }

  public virtual void Init()
  {
      //default init stuff
  }

  public void Evaluate()
  {
      if(CurrentAmount >= RequiredAmount)
      {
          Complete();
      }
  }

  public void Complete()
  {
      Quest.CheckGoals();
      Completed = true;
  }




}
