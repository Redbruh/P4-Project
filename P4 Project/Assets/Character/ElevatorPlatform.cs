using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPlatform : MonoBehaviour
{
    public float moveSpeed;
    public bool elevatorIsActive;
    public bool elevatorGoesDown;

    void Update()
    {
        Vector3 up = new Vector3(0, moveSpeed, 0);
        Vector3 down = new Vector3(0, -moveSpeed, 0);

        if (transform.position.y > 2)
        {
            elevatorIsActive = false;
        }
        if (transform.position.y < -11)
        {
            elevatorGoesDown = false;
        }

        if (elevatorIsActive == true)
        {
            transform.Translate(up * Time.deltaTime);
            elevatorGoesDown = false;
        }

        if (elevatorGoesDown == true)
        {
            transform.Translate(down * Time.deltaTime);
            elevatorIsActive = false;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            elevatorIsActive = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        elevatorIsActive = false;
        elevatorGoesDown = true;
    }
}
