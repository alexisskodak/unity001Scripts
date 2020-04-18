using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   
    public float offset;
    public int bulletCount;
    public Transform FirePoint;
    public Transform BulletPrefab;
    public Animator animator;
    //private float timeBtwShots;
    //public float startTimeBtwShots;



    // Update is called once per frame
    void Update()
    {   
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(bulletCount > 0)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Shoot();
                animator.SetBool("IsShooting", true);
            }

            if(Input.GetButtonUp("Fire1"))
            {
                animator.SetBool("IsShooting", false);
            }
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);

        bulletCount -= 1;
    }
}
