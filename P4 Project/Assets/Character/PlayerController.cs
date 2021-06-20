using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float runningTimer;
    public float maxRunningTimer;
    public float minRunningTimer;
    public float jumpHeight;
    public float gravity;
    public bool isWalking;
    public bool isSprinting;
    public bool isGrounded;
    public bool isFalling;
    public Vector3 checkpoint;
    public GameObject cloudsToSpawn;
    public float cloudTimer;
    public float maxCloudTimer;
    public int crystalsCollected;
    public int crystalsNeeded;
    public GameObject sword;
    public Vector3 swordRotation;
    public GameObject flagPole;
    public bool isAttacking;
    public bool isAttackingChest;
    public bool isAttackingEnemy;
    public GameObject attackRadiusOn;
    public float lifes;
    public RaycastHit rayHit;
    public bool isJumping;

    private void Start()
    {
        lifes = 5;
        rb = GetComponent<Rigidbody>();
        flagPole.SetActive(false);
        attackRadiusOn.SetActive(false);
    }
    void Update()
    {

        Vector3 cloudSpawnRandomizer = new Vector3(Random.Range(-0.5f, 0.5f), -0.5f, Random.Range(-0.5f, 0.5f));
        Vector3 cloudSpawnPosition = transform.position + cloudSpawnRandomizer;

        if (GetComponent<Health>().health <= 0)
        {
            gameObject.transform.position = checkpoint;
            GetComponent<Health>().health = 5;
            lifes -= 1;
        }

        if (lifes <= 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.y <= -10)
        {
            transform.gameObject.GetComponent<Health>().DoDamage(1);
        }

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 5))
        {
            if (rayHit.collider.gameObject.tag == "Chest")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    rayHit.collider.GetComponent<Health>().DoDamage(1);
                }
            }

            if (rayHit.collider.gameObject.tag == "Enemy")
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    rayHit.collider.GetComponent<Health>().DoDamage(1);
                }
            }
        }

        else
        {
            isAttacking = false;
        }

        if (isAttacking == true)
        {
            attackRadiusOn.SetActive(true);
        }
        else
        {
            attackRadiusOn.SetActive(false);
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
            isJumping = true;
            rb.velocity = new Vector3(0, jumpHeight, 0);
            isGrounded = false;
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
            moveSpeed = 15;
            jumpHeight = 9;
            if (isGrounded == true && isSprinting == true)
            {
                cloudTimer += Time.deltaTime;
                if (cloudTimer >= maxCloudTimer)
                {
                    cloudTimer = 0;
                    Instantiate(cloudsToSpawn, cloudSpawnPosition, Quaternion.identity);
                }
            }

            if (rb.IsSleeping() && isGrounded)
            {
                runningTimer = 0;
            }
        }
        else
        {
            moveSpeed = 10;
            jumpHeight = 10;
        }

        if (runningTimer >= 2)
        {
            moveSpeed = 20;
            jumpHeight = 8;
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
            moveSpeed = 25;
            jumpHeight = 7;
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

        if (crystalsCollected >= crystalsNeeded)
        {
            flagPole.SetActive(true);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            isGrounded = true;
            isJumping = false;
        }
        else
        {
            isGrounded = false;
        }

        if (collision.gameObject.tag == "Ground")
        {
            runningTimer = 0;
        }
    }
}
