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

    private void FixedUpdate()
    {
        if (playerDrop.onBoat)
        {
            for (int i = 0; i < boatSpawnPos.Length; i++)
            {
                GameObject prefabs = Instantiate(enemyBoatPrefab, boatSpawnPos[i].position, boatSpawnPos[i].rotation);

                prefabs.transform.position = Vector3.MoveTowards(prefabs.transform.position, target.transform.position, chaseSpeed * Time.deltaTime);
            }

            
        }
        else
        {
            return;
        }
    }
}
