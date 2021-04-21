using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float runningTimer;
    public float maxRunningTimer;
    public float minRunningTimer;
    public float normalMoveSpeed;
    public float runSpeedFirst;
    public float runSpeedSecond;
    public float runSpeedThird;
    public float jumpHeight;
    public float jumpDistance;
    public bool applyForwardMomentum;
    public float gravity;
    public bool isWalking;
    public bool isSprinting;
    public GameObject cloudsToSpawn;
    public float cloudTimer;
    public float maxCloudTimer;
    public bool isGrounded;
    public bool isFalling;
    public Rigidbody rb;
    public RaycastHit hit;
    public int crystalsCollected;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 cloudSpawnRandomizer = new Vector3(Random.Range(-0.5f, 0.5f), -0.5f, Random.Range(-0.5f, 0.5f));
        Vector3 cloudSpawnPosition = transform.position + cloudSpawnRandomizer;

        if (transform.position.y <= -25)
        {
            transform.gameObject.GetComponent<Health>().DoDamage(1);
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    hit.collider.GetComponent<Health>().DoDamage(1);
                }
            }
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3();
        move.x = h;
        move.z = v;

        transform.Translate(move * moveSpeed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 && isGrounded)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(0, jumpHeight, 0);
            applyForwardMomentum = true;
            isGrounded = false;
            Instantiate(cloudsToSpawn, cloudSpawnPosition, Quaternion.identity);
        }

        if (Input.GetButtonUp("Jump"))
        {
            applyForwardMomentum = false;
        }

        if (applyForwardMomentum == true)
        {
            rb.AddForce(transform.forward * jumpDistance);
        }

        if (Input.GetButton("Fire3") && isWalking == true)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if(isWalking == false)
        {
            isSprinting = false;
        }

        if (isSprinting == true && isWalking == true && isGrounded == true)
        {
            runningTimer += 1 * Time.deltaTime;
        }

        if (runningTimer >= maxRunningTimer)
        {
            runningTimer = maxRunningTimer;
        }
        if (runningTimer <= minRunningTimer)
        {
            runningTimer = minRunningTimer;
        }

        if (runningTimer > 0)
        {
            if (rb.IsSleeping() && isGrounded)
            {
                runningTimer = 0;
            }
        }

        if (runningTimer > 0)
        {
            moveSpeed = runSpeedFirst;
            jumpHeight = 7;
            jumpDistance = 3;
            if (isGrounded == true && isSprinting == true)
            {
                cloudTimer += Time.deltaTime;
                if (cloudTimer >= maxCloudTimer)
                {
                    cloudTimer = 0;
                    Instantiate(cloudsToSpawn, cloudSpawnPosition, Quaternion.identity);
                }
            }
        }
        else
        {
            moveSpeed = normalMoveSpeed;
            jumpHeight = 8;
            jumpDistance = 0;
        }

        if (runningTimer >= 2)
        {
            moveSpeed = runSpeedSecond;
            jumpHeight = 6;
            jumpDistance = 6;
            if (isGrounded == true && isSprinting == true)
            {
                cloudTimer += Time.deltaTime;
                if (cloudTimer >= maxCloudTimer)
                {
                    cloudTimer = 0;
                    Instantiate(cloudsToSpawn, cloudSpawnPosition, Quaternion.identity);
                }
            }
        }
        if (runningTimer >= 4)
        {
            moveSpeed = runSpeedThird;
            jumpHeight = 5;
            jumpDistance = 9;
            if (isGrounded == true && isSprinting == true)
            {
                cloudTimer += Time.deltaTime;
                if (cloudTimer >= maxCloudTimer)
                {
                    cloudTimer = 0;
                    Instantiate(cloudsToSpawn, cloudSpawnPosition, Quaternion.identity);
                }
            }
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

        if (isGrounded == true && rb.velocity.y < -2f)
        {
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            runningTimer = 0;
        }
        else
        {
            isGrounded = false;
        }
    }
}
