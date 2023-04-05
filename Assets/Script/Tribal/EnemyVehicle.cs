using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour
{
    private GameObject target; 
    public float speed = 5f;
    private float stoppingDistance = 5f;


    private Rigidbody vehicleRb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        vehicleRb = GetComponent<Rigidbody>();
        speed = Random.Range(6f, 7f);

    }

    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);



        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            float distance = direction.magnitude;
            if (distance > stoppingDistance)
            {
                Vector3 velocity = direction.normalized * speed;
                vehicleRb.velocity = velocity;
            }
            else
            {
                vehicleRb.velocity = Vector3.zero;
            }
        }
        transform.LookAt(target.transform.position);
    }
}
