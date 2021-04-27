using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseCollider : MonoBehaviour
{
    [SerializeField] GameObject GameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* GameOverPanel.SetActive(true);
         Time.timeScale = 0;*/
        SceneManager.LoadScene(1);
    }
}
