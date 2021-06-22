using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public Transform player;
    public float range;
    public Vector3 rotation;

    public void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);

        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            CounterGems.theScore += 1;
            player.GetComponent<PlayerController>().crystalsCollected += 1;
            Destroy(transform.gameObject);
        }
    }
}
