using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    public void Collected(bool HasCollected)
    {
        if (HasCollected == true)
        {
            transform.gameObject.GetComponent<PlayerController>().crystalsCollected += 1;
            Destroy(gameObject);
        }
    }
}
