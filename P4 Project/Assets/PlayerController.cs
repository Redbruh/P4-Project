using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float runningTimer;
    public float normalMoveSpeed;
    public float runSpeedFirst;
    public float runSpeedSecond;
    public float runSpeedThird;
    public float jumpHeight;
    public float gravity;
    public bool isWalking;
    public bool isSprinting;
    public bool isGrounded;
    public bool isFalling;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3();
        move.x = h;
        move.z = v;

        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (rb.transform.hasChanged)
        {
            isWalking = true;
            rb.transform.hasChanged = false;
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetButton("Fire3"))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true && isWalking == true)
        {
            runningTimer += 1 * Time.deltaTime;
        }
        else
        {
            runningTimer = 0;
        }

        if (runningTimer > 0)
        {
            moveSpeed = runSpeedFirst;
        }
        else
        {
            moveSpeed = normalMoveSpeed;
        }

        if (runningTimer >= 1)
        {
            moveSpeed = runSpeedSecond;
        }
        if (runningTimer >= 2)
        {
            moveSpeed = runSpeedThird;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
            isGrounded = false;
        }

        if (rb.velocity.y <= 0f && isGrounded == false)
        {
            isFalling = true;
        }
        else
        {
            isFalling = false;
        }

        float fallSpeed = gravity * Time.deltaTime;

        if (isFalling == true && isGrounded == false)
        {
            rb.velocity -= new Vector3(0, fallSpeed, 0);
        }

        if (isGrounded == true && rb.velocity.y < 0f)
        {
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
