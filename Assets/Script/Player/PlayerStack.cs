using UnityEngine;

public class PlayerStack : MonoBehaviour
{

    public GameObject stackablePrefab;

    private float stackHeight = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stackable")
        {
            //Create a new instance of the stackable prefab
            GameObject newStackObject = Instantiate(stackablePrefab);
            //Position the object on top of the currently stacked objects
            newStackObject.transform.position = new Vector3(transform.position.x, transform.position.y + stackHeight, transform.position.z);
            //Update the stack height
            stackHeight += newStackObject.GetComponent<Renderer>().bounds.size.y;
            //Make the new object a child of the player object
            newStackObject.transform.parent = transform;
        }
    }
}