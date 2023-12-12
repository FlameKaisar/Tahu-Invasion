using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossDetection : MonoBehaviour
{
    public GameObject boss;
    public GameObject winScreen;
    [SerializeField] float delayBeforeWin = 1.5f;

    public TextMeshProUGUI highScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            StartCoroutine("WinScreen");
        }
    }
    IEnumerator WinScreen()
    {
        yield return new WaitForSeconds(delayBeforeWin);
        Time.timeScale = 0f;
        winScreen.SetActive(true);
        highScore.text = ScoreCounter.displayScore.ToString("00000");
        Debug.Log("Hore Menang");
    }

}
