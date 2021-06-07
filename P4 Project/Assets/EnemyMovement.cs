using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed;
    public float range;
    public bool playerCanAttack;
    public float playerCanAttackRange;

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

        if (Vector3.Distance(player.position, transform.position) <= playerCanAttackRange)
        {
            playerCanAttack = true;
        }
        else
        {
            playerCanAttack = false;
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
