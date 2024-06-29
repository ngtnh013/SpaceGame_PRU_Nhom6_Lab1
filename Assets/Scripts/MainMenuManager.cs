using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    [Header("Panel Manager")]
    public GameObject startMenu;
    public GameObject introductionMenu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetComponent<AudioSource>().Play();
        startMenu.SetActive(true);
        introductionMenu.SetActive(false);
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1F;
    }

    public void IntroductionButton()
    {
        startMenu.SetActive(false);
        introductionMenu.SetActive(true);
        Time.timeScale = 0F;
    }

    public void BackButton()
    {
        introductionMenu.SetActive(false);
        startMenu.SetActive(true);    
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }


}
