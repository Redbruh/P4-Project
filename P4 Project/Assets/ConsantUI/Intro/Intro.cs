using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    public GameObject moveIntro;
    public GameObject hitIntro;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveIntro.SetActive(false);
            hitIntro.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {            
            hitIntro.SetActive(false);
        }
    }
}
