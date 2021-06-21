using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationCode : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public bool activateJumpAnimation;
    public bool activateWalkAnimation;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (player.GetComponent<PlayerController>().isJumping == true)
        {
            activateJumpAnimation = true;
        }
        if (player.GetComponent<PlayerController>().isWalking == true)
        {
            activateWalkAnimation = true;
        }
        if (player.GetComponent<PlayerController>().isJumping == false)
        {
            activateJumpAnimation = false;
        }
        if (player.GetComponent<PlayerController>().isWalking == false)
        {
            activateWalkAnimation = false;
        }

        if (activateJumpAnimation == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", true);
            Debug.Log("Jumping");
        }
        if (activateJumpAnimation == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            Debug.Log("Not Jumping");
        }
        if (activateWalkAnimation == true)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            Debug.Log("Walking");
        }
        if (activateWalkAnimation == false)
        {
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            Debug.Log("Not Walking");
        }
    }
}
