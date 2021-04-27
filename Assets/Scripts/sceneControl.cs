using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneControl : MonoBehaviour
{
    Scene CurrentScene;
    public void loadGame()
    {
        SceneManager.LoadScene("game");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void TryAgain()
    {
        FindObjectOfType<GameSession>().ResetGame();
        /*Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);*/
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }
    public void menu()
    {
        FindObjectOfType<GameSession>().ResetGame();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
       
    }
    public void NextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
        Time.timeScale = 1;

    }
}
