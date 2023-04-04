using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
    private GameObject target; 
    public float speed = 5f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        transform.LookAt(target.transform.position); 
    }
}
