using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{    
    public Text scoreText;
    public static int scoreNum;

    public void Start()
    {
        scoreNum = 0;
        scoreText.text = "53/" + scoreNum;
    }

    public void OnTriggerEnter(Collider Crystal)
    {
        if(Crystal.tag == "Gemsss")
        {
            scoreNum ++;
            scoreText.text = "53/" + scoreNum;           
        }
    }

}
