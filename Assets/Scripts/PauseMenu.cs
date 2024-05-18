using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PauseMenu : MonoBehaviour


{
    public TextMeshProUGUI coins;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public GameObject pauseMenuUI;
    public static bool GameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        coins.text = PlayerPrefs.GetInt("coins", 0).ToString();
        damage.text = PlayerPrefs.GetInt("playerDamage", 0).ToString();
        health.text = PlayerPrefs.GetInt("currentHealth", 0).ToString();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
         SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
