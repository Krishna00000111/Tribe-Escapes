using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStack : MonoBehaviour
{
    public Transform holderParent;

    Stack<Transform> collectedTrans = new Stack<Transform>();
    bool isIndropArea;
    Vector3 DropPos;
    //unlock Reward/Item

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            isIndropArea = true;
            DropPos = other.transform.position;
            //other.TryGetComponent(out unlockItemSrc);

            StartCoroutine(DropSlow(0.5f));
        }

        else
        {
            Item localItem = null;
            if (other.gameObject.CompareTag("Pickable") && localItem && !localItem.isCollected)
            {
                other.transform.SetParent(holderParent);
                other.transform.localPosition = new Vector3(0, collectedTrans.Count * .25f, 0.1f);
                other.transform.localRotation = holderParent.rotation;

                collectedTrans.Push(other.transform);
                localItem.isCollected = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Drop"))
        {
            isIndropArea = false;
        }
    }

    IEnumerator DropSlow(float _delay = 0)
    {
        while (isIndropArea)
        {
            yield return new WaitForSeconds(_delay);
            if (collectedTrans.Count > 0)
            {
                Transform newItem = collectedTrans.Pop();
                newItem.parent = null;
            }
        }

        yield return null;
    }
}