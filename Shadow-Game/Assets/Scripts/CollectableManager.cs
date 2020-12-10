 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager instance;
    public int numCollected;
    private GameObject[] gos;
    public int numInScene;
    public bool allCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        gos = GameObject.FindGameObjectsWithTag("Collectable");
        numInScene = gos.Length;
    }

    public void Collect()
    {
        numCollected++;
    }

    void Update()
    {
        if(numCollected == numInScene)
            allCollected = true;
        else
            allCollected = false;
    }
}
