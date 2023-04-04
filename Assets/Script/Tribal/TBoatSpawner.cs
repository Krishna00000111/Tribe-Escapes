using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBoatSpawner : MonoBehaviour
{
    public GameObject enemyBoatPrefab;
    public Transform[] boatSpawnPos;

    public float chaseSpeed;

    public GameObject target;

    public PlayerDrop playerDrop;

    private bool geneEnemy;

    private void FixedUpdate()
    {
        if (playerDrop.onBoat)
        {
            for (int i = 0; i < boatSpawnPos.Length; i++)
            {
               Instantiate(enemyBoatPrefab, boatSpawnPos[i].position, boatSpawnPos[i].rotation);
                
            }

            
        }
        else
        {
            return;
        }
    }

    private void GenerateEnemyVehicle()
    {
        if (playerDrop.onBoat)
        {

        }
    }
}
