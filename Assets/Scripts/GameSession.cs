using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    public static GameSession instance;
    //configuration parameters
    //[Range(0.1f,10)][SerializeField] float GameSpeed=1f;
  //  [SerializeField] int PointsPerBlockDestroyed; 
    //state variables
    [SerializeField] int CurrentScore = 0;
    [SerializeField] TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    public bool AutoPlay = false;
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        Time.timeScale = 1f;
        if (instance == null)
            instance = this;

        ScoreText.text = CurrentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = GameSpeed; 
    }
    public void AddToScore()
    {
        CurrentScore += 150;
        ScoreText.text = CurrentScore.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
