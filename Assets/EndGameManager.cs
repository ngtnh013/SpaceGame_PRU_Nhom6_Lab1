using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager instance;

    [Header("EndGameMemu Manage")]
    public GameObject endGameMenu;
    public TMP_Text endGameMenuScore;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetComponent<AudioSource>().Play();
        endGameMenuScore.SetText(string.Concat("Score: ", GameManager.instance.score));
        endGameMenu.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1F;
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
