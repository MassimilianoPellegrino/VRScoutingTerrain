using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItemSet : MonoBehaviour
{
    public HashSet<string> CollectedItems { get; private set; } = new HashSet<string>();
}
