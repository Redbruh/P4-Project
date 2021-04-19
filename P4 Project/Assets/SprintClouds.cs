using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintClouds : MonoBehaviour
{
    public float cloudMoveSpeed;
    public float cloudLife;
    public GameObject cloud;

    void Update()
    {
        GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * cloudMoveSpeed);

        cloudLife -= Time.deltaTime;
        if (cloudLife <= 0)
        {
            Destroy(cloud);
        }
    }
}
