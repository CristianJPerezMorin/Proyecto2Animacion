using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject MenuOpciones;
    AnimationButton animacion;

    public void StartGame()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene("Juego");
    }

    public void ChangeMenu()
    {
        if (MenuPrincipal.activeSelf)
        {
            MenuPrincipal.SetActive(false);
            MenuOpciones.SetActive(true);
        }
        else
        {
            MenuPrincipal.SetActive(true);
            MenuOpciones.SetActive(false);
        }
    }
}
