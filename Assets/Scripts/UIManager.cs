using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text score;
    public TMP_Text health;
    // Start is called before the first frame update
    void Start()
    {
        Enemy.takeDamgage += UpdateHealth;
        health.text = Player.instance.health + "";
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
    
}
