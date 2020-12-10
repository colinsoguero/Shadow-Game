using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Respawn")
        {
            LevelLoader.instance.Reset();
        }
        if(other.tag == "Collectable")
        {
            CollectableManager.instance.Collect();
            Destroy(other.gameObject);
        }
    }
}
