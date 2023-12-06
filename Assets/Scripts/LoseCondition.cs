using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCondition : MonoBehaviour
{
    public GameObject loseScreen;
    [SerializeField] float delayTime = 1.5f;
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
        print("Skill Issue detected");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }
}
