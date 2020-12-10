using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    PolygonCollider2D shadowCollider;
    // Start is called before the first frame update
    void Start()
    {
        shadowCollider = gameObject.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Turret")
        {
            LevelLoader.instance.Reset();
        }
    }
}
