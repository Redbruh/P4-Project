using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform toFollow;
    public float moveSpeed;

    void Update()
    {
        transform.LookAt(toFollow);
        GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * moveSpeed);
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
