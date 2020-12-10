using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Turret : MonoBehaviour
{
    public float range;
    public Transform target;
    bool detected = false;
    Vector2 direction;
    public GameObject indicator;
    public GameObject gun;
    public GameObject bullet;
    public float fireRate;
    float nextTimeToFire = 0;
    public Transform shootPoint;
    public float force;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, direction, range);
        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                //Debug.Log(rayInfo.collider.name);
                if (detected == false)
                {
                    detected = true;
                    indicator.GetComponent<SpriteRenderer>().color = Color.red; 
                }
            }
        }
        else
        {
            if (detected == true)
            {
                detected = false;
                indicator.GetComponent<SpriteRenderer>().color = Color.green; 
            }
        }
        if (detected)
        {
            gun.transform.up = -direction;
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        GameObject bulletIns = Instantiate(bullet, shootPoint.position, Quaternion.identity);
        bulletIns.GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
