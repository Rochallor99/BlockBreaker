using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
   [SerializeField] int breakableBlocks; //serialized for debugging

    
    sceneControl sceneLoader;
    [SerializeField] GameObject winnerPanel;

    private void Start()
    {
        sceneLoader = FindObjectOfType<sceneControl>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            winnerPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
