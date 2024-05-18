using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    public TextMeshProUGUI current_healthy;
    public TextMeshProUGUI current_damagy;
    public TextMeshProUGUI currentdcost;
    public TextMeshProUGUI currenthcost;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI health;
    public TextMeshProUGUI damage;
    public AudioSource buysound;
    public AudioSource wrongsound;
 
  
    public GameObject shopMenuUI;
    public static bool GameIsPaused = false;

 private Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
       PlayerPrefs.SetInt("currentHealth",PlayerPrefs.GetInt("playerHealth",0));
      
       
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
          damage.text = PlayerPrefs.GetInt("playerDamage", 0).ToString();
        health.text = PlayerPrefs.GetInt("playerHealth", 0).ToString();
        coins.text = PlayerPrefs.GetInt("coins", 0).ToString();
         current_healthy.text = PlayerPrefs.GetInt("playerHealth", 0).ToString();
        current_damagy.text = PlayerPrefs.GetInt("playerDamage", 0).ToString();
        currentdcost.text = PlayerPrefs.GetInt("damagecost", 0).ToString();
        currenthcost.text = PlayerPrefs.GetInt("healthcost", 0).ToString();
         if(Input.GetKeyDown(KeyCode.E))
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
    public void UpgradeHealth()
    {
        
        if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("healthcost", 0)) 
        {
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(buysound.clip, Vector3.zero);
            Time.timeScale = 0;
            PlayerPrefs.SetInt("playerHealth",PlayerPrefs.GetInt("playerHealth",0)+50);
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - PlayerPrefs.GetInt("healthcost", 0));
            PlayerPrefs.SetInt("healthcost", PlayerPrefs.GetInt("healthcost", 0) + 50);
        }
        else{
            AudioSource.PlayClipAtPoint(wrongsound.clip, Vector3.zero);
        }
    }
    public void UpgradeDamage()
    {
       
        if(PlayerPrefs.GetInt("coins", 0) >= PlayerPrefs.GetInt("damagecost", 0)) 
        {
            Time.timeScale = 1;
            AudioSource.PlayClipAtPoint(buysound.clip, Vector3.zero);
            Time.timeScale = 0;
          
            Debug.Log("upgrade damage");
            PlayerPrefs.SetInt("playerDamage",PlayerPrefs.GetInt("playerDamage",0) + 25);
             PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) - PlayerPrefs.GetInt("damagecost", 0));
            PlayerPrefs.SetInt("damagecost", PlayerPrefs.GetInt("damagecost", 0) + 50);
        }
          else{
            AudioSource.PlayClipAtPoint(wrongsound.clip, Vector3.zero);
        }
    }

      public void Pause()
    {
        shopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
     public void Resume()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
