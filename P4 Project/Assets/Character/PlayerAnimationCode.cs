using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCode : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().isJumping == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            Debug.Log("Jumping");
        }

        if (player.GetComponent<PlayerController>().isWalking == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            Debug.Log("Walking");
        }

        if (player.GetComponent<PlayerController>().isJumping == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            Debug.Log("Not Jumping");
        }

        if (player.GetComponent<PlayerController>().isWalking == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            Debug.Log("Not Walking");
        }
    }
}
