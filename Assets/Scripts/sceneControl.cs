using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneControl : MonoBehaviour
{
    Scene CurrentScene;
    [SerializeField] GameObject GameOverPanel;
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
        /*CurrentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(CurrentScene.buildIndex,LoadSceneMode.Single);*/
        FindObjectOfType<GameSession>().ResetGame();
        /*Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);*/
        SceneManager.LoadScene("game");
        Time.timeScale = 1;
        //GameOverPanel.SetActive(false);
    }
    public void menu()
    {
        //GameOverPanel.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
       
    }
    public void NextScene()
    {
        int mevcutSahneninIndeksi = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(mevcutSahneninIndeksi + 1);
        Time.timeScale = 1;

    }
}
