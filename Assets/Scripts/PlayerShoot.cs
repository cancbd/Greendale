using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;

    //float timeUntilFire;
    PlayerMovement pm;


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
        
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f,angle)));
       
            
           
    }
}
