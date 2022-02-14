using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerStart : MonoBehaviour
{
     public Transform[] spawnPoints;
    public GameObject[] butterflyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int randEnemy = Random.Range(0, butterflyPrefab.Length);
            int randSpawPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(butterflyPrefab[0], spawnPoints[randSpawPoint].position, transform.rotation);
        }
        
    }
}
