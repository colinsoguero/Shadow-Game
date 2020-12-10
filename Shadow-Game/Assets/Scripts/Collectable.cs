using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collectable trigger");
        if(other.tag == "Player")
        {
            CollectableManager.instance.Collect();
            Destroy(gameObject);
        }
    }
}
