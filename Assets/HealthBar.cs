using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public GameObject healthbar;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = healthbar.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
