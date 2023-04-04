using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBoatSpawner : MonoBehaviour
{
    public GameObject enemyBoatPrefab;
    public Transform[] boatSpawnPos;

    public PlayerDrop playerDrop;

    private void FixedUpdate()
    {
        if (playerDrop.onBoat)
        {
            Instantiate(enemyBoatPrefab, boatSpawnPos[0].position, boatSpawnPos[0].rotation);
        }
        else
        {
            return;
        }
    }
}
