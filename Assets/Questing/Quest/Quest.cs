using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour
{
    public List<Goals> GoalList {get; set;} = new List<Goals>();
    public string QuestName {get; set;} 
    public string Description {get; set;}
    public Item ItemReward {get; set;}
    public bool Completed {get; set;}

    public void CheckGoals()
    {
        Completed = GoalList.All(g => g.Completed);
        //if(Completed) GiveReward();

       
    }

    void GiveReward()
    {
       //Massimo con questa funzione devi lanciare nell'ambiente la medaglia che sia raccoglibile
        //if(ItemReward != null)
        //InventoryController.Instance.GiveItem(ItemReward);
        //Prende da un inventario un oggetto, come hai fatto con tenda e fuoco
    }

    

}
