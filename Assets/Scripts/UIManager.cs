using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text health;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.takeDamage += UpdateHealth;
        PickUp.pickUpItem += UpdateBar;
        health.text = Player.instance.health + "";
        slider.maxValue = Player.instance.maxProtein;
        slider.value = Player.instance.protein;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = Mathf.FloorToInt(Player.instance.distance) + "m";
        
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

    
}
