using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool haveplayed;
   
    void Start()
    {
        if(PlayerPrefs.GetInt("playerHealth", 0) < 100)
        {
            haveplayed = false;
        }
        else if (PlayerPrefs.GetInt("playerHealth", 150) >= 150)
        {
            haveplayed = true;
        }
    }
    public void NewGame()
    {
       
       
            PlayerPrefs.SetInt("playerDamage", 10);
            PlayerPrefs.SetInt("playerHealth", 150);
            PlayerPrefs.SetInt("currentHealth", 150);
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("damagecost",50);
            PlayerPrefs.SetInt("healthcost",50);
            Time.timeScale = 1f;
        SceneManager.LoadScene(1);
      
    }
    public void PlayGame()
    {
        if(haveplayed == true)
        {
            SceneManager.LoadScene(1);
        }
      
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
