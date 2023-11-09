using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class SceneManagement : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject MenuOpciones;
    public GameObject MenuIdioma;

    private List<Locale> locales;
    private int countLanguage = 2;

    private void Start()
    {
        locales = LocalizationSettings.Instance.GetAvailableLocales().Locales;
    }

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

    public void ChangeMenuLanguage()
    {
        if (MenuPrincipal.activeSelf)
        {
            MenuPrincipal.SetActive(false);
            MenuIdioma.SetActive(true);
        }
        else
        {
            MenuPrincipal.SetActive(true);
            MenuIdioma.SetActive(false);
        }
    }



    public void NextLanguage()
    {
        countLanguage++;
        if(countLanguage == 3)
        {
            countLanguage = 0;
        }

        LocalizationSettings.Instance.SetSelectedLocale(locales[countLanguage]);
    }

    public void PreviousLanguage()
    {
        countLanguage--;
        if (countLanguage == -1)
        {
            countLanguage = 2;
        }

        LocalizationSettings.Instance.SetSelectedLocale(locales[countLanguage]);
    }


    public void SetEnglish()
    {
        LocalizationSettings.Instance.SetSelectedLocale(locales[0]);
    }

    public void SetSpain()
    {
        LocalizationSettings.Instance.SetSelectedLocale(locales[2]);
    }

    public void SetFrench()
    {
        LocalizationSettings.Instance.SetSelectedLocale(locales[1]);
    }
}
