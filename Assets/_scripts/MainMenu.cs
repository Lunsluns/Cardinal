using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public GameObject OptionsMenu, CreditsMenu;

    public void Begin()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        OptionsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void creditMenu()
    {
        CreditsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
