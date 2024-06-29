using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject enemyPrefab;

    public float minInstantiateValue;

    public float maxInstantiateValue;

    public float enemyDestroyTime;

    [Header("Score")]
    public int score = 0;
    public TMP_Text scoreText;

    [Header("Partical Effects")]
    public GameObject explosion;
    public GameObject muzzleFlash;

    [Header("Partical Effects")]
    public GameObject pausedMenu;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetComponent<AudioSource>().Play();

        pausedMenu.SetActive(false);

        InvokeRepeating("InstantiateEnemy", 1F, 1F);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(true);
        }
    }

    void InstantiateEnemy()
    {
        Vector3 enemyPos = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 9F);
        
        GameObject enemy =  Instantiate(enemyPrefab, enemyPos, Quaternion.Euler(0F, 0F, 180F));
        Destroy(enemy, enemyDestroyTime);
    }


    public void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            pausedMenu.SetActive(true);
            Time.timeScale = 0F;
        }
        else
        {
            pausedMenu.SetActive(false);
            Time.timeScale = 1F;
        }
       
    }

    public void QuitGame()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

}
