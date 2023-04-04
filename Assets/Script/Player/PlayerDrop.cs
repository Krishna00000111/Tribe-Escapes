using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    
    public int requiredLog;

    public GameObject boatPrefab;
    public GameObject realPlayer;
    public Transform boatSeat;

    [HideInInspector]
    public int requiredLogText;

    [HideInInspector]
    public bool onBoat;

    [HideInInspector]
    public bool missionCompleted = false;

    private int currentLogDetected;

    private void Start()
    {
        currentLogDetected = 0;
        requiredLogText = requiredLog;
        boatPrefab.SetActive(false);
    }

    private void Update()
    {
        if(currentLogDetected == requiredLog)
        {
            missionCompleted = true;
            boatPrefab.SetActive(true);
            onBoat = true;
            realPlayer.transform.position = boatSeat.position;
            realPlayer.transform.parent = boatSeat.transform;

           ///Do whatever it takes
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickable"))
        {
            currentLogDetected = currentLogDetected + 5;
            requiredLogText = requiredLog - 5;
        }
        
       
    }
}
