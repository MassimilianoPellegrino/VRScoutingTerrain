using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1
{
   public enum ItemType
    {
        Pietra,
        Ramo,
        Accendino,
        Torcia,
        Telo,
        Corda,

    }

    public ItemType itemType;
    public int amount;
}
