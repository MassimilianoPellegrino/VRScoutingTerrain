using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PuzzleManager : MonoBehaviour
{
  [SerializeField] private List<PuzzleSlot> slotPrefabs;
  [SerializeField] private Transform slotParent, pieceParent;
  [SerializeField] private PuzzleStar starPrefab;
  
  void Start()
  {
      Spawn();
  }


  void Spawn()
  {
      var randomSet = slotPrefabs.OrderBy(s => Random.value).ToList();

      for(int i = 0; i < randomSet.Count; i++)
      {
          var spawnedSlot = Instantiate(randomSet[i], slotParent.GetChild(i).position, Quaternion.identity);

          var spawnedPiece = Instantiate(starPrefab, pieceParent.GetChild(i).position, Quaternion.identity);
          spawnedPiece.Init(spawnedSlot);
      }


  }
}
