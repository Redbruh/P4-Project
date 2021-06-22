using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterGems : MonoBehaviour
{
    public GameObject scoreText;
    public static int theScore;

    public void OnTriggerEnter(Collider other)
    {        
        scoreText.GetComponent<Text>().text = "SCORE" + theScore;
    }
}
