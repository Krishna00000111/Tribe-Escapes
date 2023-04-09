using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public Transform handTransform; // The transform of the player's hand
    public float maxDistance = 1f; // The maximum distance for collecting objects
    public float collectingSpeed = 5f; // The speed at which objects will be collected
    public LayerMask collectableLayer; // The layer of objects that can be collected

    private List<GameObject> collectedObjects = new List<GameObject>(); // List of collected objects

    private void Update()
    {
        // Check for nearby objects to collect
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, maxDistance);
        foreach (Collider collider in hitColliders)
        {
            if (collectedObjects.Contains(collider.gameObject)) continue; // Skip objects that have already been collected
            if ((collectableLayer.value & (1 << collider.gameObject.layer)) == 0) continue; // Skip objects that are not on the collectable layer
            CollectObject(collider.gameObject);
        }

        // Move collected objects to player's hand and stack them
        Vector3 stackOffset = Vector3.zero;
        foreach (GameObject collectedObject in collectedObjects)
        {
            collectedObject.transform.position = Vector3.Lerp(collectedObject.transform.position, handTransform.position + stackOffset, Time.deltaTime * collectingSpeed);
            stackOffset += Vector3.up * 1; // Add the height of the object to the stack offset

            // Rotate object in the direction the player is facing
            Vector3 lookDirection = transform.forward;
            lookDirection.y = 0f; // Zero out the y component to avoid tilting the object
            collectedObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
    }

    private void CollectObject(GameObject obj)
    {
        collectedObjects.Add(obj);

        // Move object to player's hand
        obj.transform.position = transform.position;

        // Disable collider and rigidbody so the object no longer interacts with the environment
        Collider collider = obj.GetComponent<Collider>();
        if (collider != null) collider.enabled = false;

        Rigidbody rigidbody = obj.GetComponent<Rigidbody>();
        if (rigidbody != null) rigidbody.isKinematic = true;
    }
}
