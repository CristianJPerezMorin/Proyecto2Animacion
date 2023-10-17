using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    float tiempo;
    public TMP_Text textoContador;
    public TMP_Text FinalTexto;
    private bool gameEnded = false;
    public GameObject panel;
    GameObject Terrain, Player, Enemy, Obstacle;
    GameObject[] listOfItems;

    public bool GameEnded
    {
        get { return gameEnded; }
    }

    public void EndGame()
    {
        gameEnded = true;
    }

    public void SetFinalMode()
    {
        Terrain.SetActive(false);
        Player.SetActive(false);
        Enemy.SetActive(false);
        Obstacle.SetActive(false);

        tiempo += Time.deltaTime;
        double _ = Math.Round(tiempo, 2);
        FinalTexto.text = "Felicidades por terminar el juego, tu tiempo ha sido de " + _ + " segundos.";

        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetFinalMode(GameObject[] listObjects)
    {
        Terrain.SetActive(false);
        Player.SetActive(false);
        Enemy.SetActive(false);
        Obstacle.SetActive(false);
        foreach(var item in listObjects)
        {
            item.SetActive(false);
        }

        panel.SetActive(true);
        Time.timeScale = 0;
    }

    void Start()
    {
        Terrain = GameObject.Find("Suelo");
        Player = GameObject.Find("Jugador");
        Enemy = GameObject.Find("Enemigo");
        Obstacle = GameObject.Find("Obstaculo");
    }

    void Update()
    {
        if (!GameEnded)
        {
            tiempo += Time.deltaTime;
            double _ = Math.Round(tiempo, 2);
            textoContador.text = _.ToString();
        }
        if (GameEnded)
        {
            SetFinalMode();
        }
    }

}
