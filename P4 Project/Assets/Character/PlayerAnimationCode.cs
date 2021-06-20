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
            //animator.SetBool("Jump", true);
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            Debug.Log("Jumping");
        }
        else
        {
            Debug.Log("Not Jumping");
        }


        if (player.GetComponent<PlayerController>().isWalking == true)
        {
            //animator.SetBool("Walk", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            Debug.Log("Walking");
        }
        else
        {
            Debug.Log("Not Walking");
        }
    }
}
