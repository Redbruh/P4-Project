﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public float range;

    void Update()
    {
        if (transform.position.y <= -10)
        {
            transform.gameObject.GetComponent<Health>().DoDamage(1);
        }

        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            transform.LookAt(player);
            GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (GetComponent<Health>().health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().DoDamage(1);
        }
    }
}
