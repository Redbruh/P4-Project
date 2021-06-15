using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public Transform player;
    public float range;

    public void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            player.GetComponent<PlayerController>().crystalsCollected += 1;
            Destroy(gameObject);
        }
    }
}
