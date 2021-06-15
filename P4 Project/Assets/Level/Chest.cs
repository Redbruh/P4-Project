using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject player;
    public GameObject crystals;
    public Vector3 spawnPos;

    void Update()
    {
        spawnPos = transform.position;
        if (GetComponent<Health>().currentHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(crystals, spawnPos, Quaternion.identity);
        }
    }
}
