using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text health;
    public Slider slider;
    public Slider progressMeter;
    public GameObject pauseScreen;
    public GameObject gameOverScreen;
    public static UIManager instance;
    public GameObject victoryScreen;
    // Start is called before the first frame update

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        Enemy.takeDamage += UpdateHealth;
        PickUp.pickUpItem += UpdateBar;
        health.text = Player.instance.health + "";
        slider.maxValue = Player.instance.maxProtein;
        slider.value = Player.instance.protein;
        progressMeter.maxValue = Player.instance.maxDistance;
        progressMeter.value = Player.instance.distance;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Mathf.FloorToInt(Player.instance.distance) + "m";
        progressMeter.value = Player.instance.distance;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
        
    }

    public void UpdateHealth()
    {
        Player.instance.health -= 1;
        health.text = Player.instance.health + "";
    }

    public void UpdateBar()
    {
        slider.value = Player.instance.protein;

    }



    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void PauseScreen()
    {
        if (pauseScreen.activeSelf == false)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    
}
