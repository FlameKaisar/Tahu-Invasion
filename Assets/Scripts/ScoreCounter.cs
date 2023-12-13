using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static float currentScore;
    private int startScore;

    public float transitionSpeed = 100;
    public static float displayScore;

    private void Awake()
    {
        
    }


    // Start is called before the first frame update
    void Start()
    {
        currentScore = startScore;
        startScore = 0;
        if (PlayerPrefs.GetFloat("score") > 0)
        {
            currentScore = PlayerPrefs.GetFloat("score");
        }
        scoreText.text = currentScore.ToString("00000");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        displayScore = Mathf.MoveTowards(displayScore, currentScore, transitionSpeed * Time.deltaTime);
        scoreText.text = displayScore.ToString("00000");
    }


}
