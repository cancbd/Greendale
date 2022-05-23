using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShoot : MonoBehaviour
{
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public Transform player;
    public float range, timeBTWShots;
    private float distanceToPlayer;


    private void Start()
    {
        if (distanceToPlayer <= range)
        {
            StartCoroutine(Shoot());
        }
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position,player.position);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBTWShots);
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, 180f)));
    }
}