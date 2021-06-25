using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject player;
    public GameObject crystals;
    public Vector3 spawnPos1;
    public Vector3 spawnPos2;
    public Vector3 spawnPos3;
    public Vector3 spawnPos4;

    void Update()
    {
        spawnPos1 = transform.position + new Vector3(1, 0, 0);
        spawnPos2 = transform.position + new Vector3(-1, 0, 0);
        spawnPos3 = transform.position + new Vector3(0, 0, 1);
        spawnPos4 = transform.position + new Vector3(0, 0, -1);

        if (GetComponent<Health>().health <= 0)
        {
            Destroy(transform.gameObject);
            Instantiate(crystals, spawnPos1, Quaternion.identity);
            Instantiate(crystals, spawnPos2, Quaternion.identity);
            Instantiate(crystals, spawnPos3, Quaternion.identity);
            Instantiate(crystals, spawnPos4, Quaternion.identity);
        }
    }
}
