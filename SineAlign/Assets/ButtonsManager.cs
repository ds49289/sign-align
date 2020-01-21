using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextTutorialPage()
    {
        SceneManager.LoadScene("HowToPlay2");
    }

    public void PreviousTutorialPage()
    {
        SceneManager.LoadScene("HowToPlay1");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
