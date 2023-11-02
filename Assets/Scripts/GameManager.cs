using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    float tiempo;
    public TMP_Text textoContador;
    public TMP_Text FinalTexto;
    private bool gameEnded = false;
    public GameObject panel;
    GameObject Terrain, Player, Enemy;

    public bool GameEnded
    {
        get { return gameEnded; }
    }

    public void EndGame()
    {
        gameEnded = true;
    }

    void RestartTime()
    {
        Time.timeScale = 1;
    }

    public void SetFinalMode(bool enemyCatch)
    {
        Terrain.SetActive(false);
        Player.SetActive(false);
        Enemy.SetActive(false);

        if (!enemyCatch)
        {
            tiempo += Time.deltaTime;
            double _ = Math.Round(tiempo, 2);
            FinalTexto.text = "Felicidades por terminar el juego, tu tiempo ha sido de " + _ + " segundos.";
        }

        panel.SetActive(true);
        gameEnded = false;
        Time.timeScale = 0;
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Menu");
    }

    void Start()
    {
        Terrain = GameObject.Find("Suelo");
        Player = GameObject.Find("Jugador");
        Enemy = GameObject.Find("Enemigo");
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
            SetFinalMode(false);
        }
        
        if(Time.timeScale != 1)
        {
            Invoke("RestartTime", 3);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMenu();
        }
    }
}
