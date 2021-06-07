using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    //public Transform player;
    public GameObject player;
    public bool playerIsAttacking;
    public float playerCanAttackRange;
    public Transform playerAttackRange;
    public GameObject crystals;
    public Vector3 spawnPos;

    void Update()
    {
        spawnPos = transform.position;
        if (Vector3.Distance(playerAttackRange.position, transform.position) <= playerCanAttackRange)
        {
            if (player.GetComponent<PlayerController>().isAttackingChest == true)
            {
                Destroy(gameObject);
                Instantiate(crystals, spawnPos, Quaternion.identity);
            }
        }
    }
}
