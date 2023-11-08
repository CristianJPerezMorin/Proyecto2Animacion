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
    private Locale actualLanguage;

    private void Update()
    {
        actualLanguage = LocalizationSettings.SelectedLocale;
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
        if(actualLanguage.Formatter.ToString() == "es")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("en");
            LocalizationSettings.SelectedLocale = _language;
        }
        else if (actualLanguage.Formatter.ToString() == "en")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("fr");
            LocalizationSettings.SelectedLocale = _language;
        }
        else if (actualLanguage.Formatter.ToString() == "fr")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("es");
            LocalizationSettings.SelectedLocale = _language;
        }
    }

    public void PreviousLanguage()
    {
        if (actualLanguage.Formatter.ToString() == "es")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("fr");
            LocalizationSettings.SelectedLocale = _language;
        }
        else if (actualLanguage.Formatter.ToString() == "en")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("es");
            LocalizationSettings.SelectedLocale = _language;
        }
        else if (actualLanguage.Formatter.ToString() == "fr")
        {
            Locale _language = LocalizationSettings.AvailableLocales.GetLocale("en");
            LocalizationSettings.SelectedLocale = _language;
        }
    }


    public void SetEnglish()
    {
        Locale _language = LocalizationSettings.AvailableLocales.GetLocale("en");
        LocalizationSettings.SelectedLocale = _language;
    }

    public void SetSpain()
    {
        Locale _language = LocalizationSettings.AvailableLocales.GetLocale("es");
        LocalizationSettings.SelectedLocale = _language;
    }

    public void SetFrench()
    {
        Locale _language = LocalizationSettings.AvailableLocales.GetLocale("fr");
        LocalizationSettings.SelectedLocale = _language;
    }
}
