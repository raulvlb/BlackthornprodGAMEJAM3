﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class O2Timer : MonoBehaviour
{
    Image timeBar;
    public float maxTime = 10f;
    float timeLeft;
    public static float atm = 1;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        timeBar = GetComponent<Image>();
        timeLeft = maxTime;
        atm = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < 10 && player.transform.position.y > 0){
            atm = 1f;
        }else if(player.transform.position.y < 20 && player.transform.position.y > 10){
            atm = 2f;
        }else if(player.transform.position.y < 40 && player.transform.position.y > 20){
            atm = 3f;
        }else if(player.transform.position.y < 80 && player.transform.position.y > 40){
            atm = 4f;
        }else if(player.transform.position.y < 100 && player.transform.position.y > 80){
            atm = 5f;
        }else if(player.transform.position.y > 160){
            end.terminou = true;
            //Time.timeScale = 0;
            SceneManager.LoadScene("Scores");
        }

        if(timeLeft > 0){
            timeLeft -= Time.deltaTime * atm;
            timeBar.fillAmount = timeLeft / maxTime;
        }else if(Health.health >= 1){
            timeLeft = maxTime;
            Health.health -= 1;
        }else if(Health.health < 1){
            end.terminou = false;
            //Time.timeScale = 0;
            SceneManager.LoadScene("Scores");
        }
    }
}
