using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public int quantity = 0;
    public bool isDefaultItem = false;
    public GameObject prefab = null;
    public bool toPlaceInHand = false;
    public bool neededForBonfire = false;
    public bool neededForTent = false;


}
