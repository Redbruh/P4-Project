using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public void collected(bool hasCollected)
    {
        if (hasCollected == true)
        {
            transform.gameObject.GetComponent<PlayerController>().crystalsCollected += 1;
            Destroy(gameObject);
        }
    }
}
