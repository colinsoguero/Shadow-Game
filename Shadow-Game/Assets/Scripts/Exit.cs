using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && CollectableManager.instance.allCollected)
        {
            LevelLoader.instance.LoadNextLevel();
        }
    }
}
