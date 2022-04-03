using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    PlayerMovement pm;
    int bulletLimit = 5;
    int bulletCount = 0;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletCount < bulletLimit)
        {
            float angle = pm.isFacingRight ? 0f : 180f;
            //Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            bulletCount++;
        }       
           
    }
}
