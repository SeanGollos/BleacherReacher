using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] int curInventory = 0;
    [SerializeField] int maxInventory = 4;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.GetComponent<Valuable>())
        {
            if(curInventory<maxInventory)
            {
                curInventory++;
                Destroy(otherObject.gameObject);
            }
        }
    }
}