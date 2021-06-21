using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCode : MonoBehaviour
{
    public Animator animator;
    public GameObject player;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().isJumping == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            Debug.Log("Should Jump");
        }

        if (player.GetComponent<PlayerController>().isJumping == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            Debug.Log("Should Stop Jumping");
        }

        if (player.GetComponent<PlayerController>().isWalking == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            Debug.Log("Should Walk");
        }

        if (player.GetComponent<PlayerController>().isWalking == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            Debug.Log("Should Stop Walking");
        }

        if (player.GetComponent<PlayerController>().isAttacking == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Swing", true);
            Debug.Log("Should Swing Sword");
        }

        if (player.GetComponent<PlayerController>().isAttacking == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Swing", false);
            Debug.Log("Should Stop Swinging Sword");
        }
    }
}
