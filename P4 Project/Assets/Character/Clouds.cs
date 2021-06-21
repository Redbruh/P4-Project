using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public Transform player;
    public float despawn;
    public float cloudMoveSpeed;

    void Update()
    {
        GetComponent<Transform>().Translate(Vector3.up * Time.deltaTime * cloudMoveSpeed);

        transform.LookAt(player);

        despawn += 1 * Time.deltaTime;

        if(despawn >= 0.5)
        {
            Destroy(transform.gameObject);
        }
    }
}
