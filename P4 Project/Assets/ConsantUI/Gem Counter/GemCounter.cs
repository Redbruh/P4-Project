using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour
{    
    public Text scoreText;
    public  int scoreNum;

    public GameObject winMessage;
    public GameObject flagPole;

    public void Start()
    {
        scoreNum = 0;        
        UpdateScoreText();
    }

    public void Update()
    {
        if(scoreNum >= 53)
        {
            flagPole.SetActive(true);
            winMessage.SetActive(true);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Crystal"))
        {
            collider.gameObject.SetActive(false);
            scoreNum++;
            UpdateScoreText();
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = "53/" + scoreNum;
    }
}
