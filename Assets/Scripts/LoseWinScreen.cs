using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LoseWinScreen : MonoBehaviour
{
    public GameObject loseScreen;
    [SerializeField] float delayTime = 1.5f;
    public TextMeshProUGUI highScore;

    public SoundEffectPlayer sfxplayer;
    public AudioMixer bgm;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player.currentHealth <= 0)
        {
            StartCoroutine(Lose());
        }
    }

    IEnumerator Lose()
    {
        yield return new WaitForSeconds(delayTime);
        Time.timeScale = 0f;
        loseScreen.SetActive(true);
        sfxplayer.hoverButton();
        bgm.SetFloat("volume", -80);
        highScore.text = ScoreCounter.displayScore.ToString("00000");
        print("Skill Issue detected");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
        PlayerPrefs.DeleteKey("score");
        Time.timeScale = 1.0f;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
        PlayerPrefs.SetFloat("score", ScoreCounter.currentScore);
        Debug.Log(PlayerPrefs.GetFloat("score"));
    }
}
