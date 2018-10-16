using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static bool beginStartOverCountdown = false;
    float countdownToStartOver = 3.0f;
    float maxCountdownTime = 3.0f;

    public static UnityEngine.UI.Text gameOverText = null;
    static int score = 0;
    static bool gameover = false;

	// Use this for initialization
	void Start () {
        countdownToStartOver = maxCountdownTime;
        gameOverText = GameObject.Find("gameOverText").GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(beginStartOverCountdown)
        {
            if((countdownToStartOver -= Time.deltaTime) <= 0.0f)
            {
                beginStartOverCountdown = false;
                countdownToStartOver = maxCountdownTime;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if(gameover && Input.anyKeyDown)
        {
            Application.Quit();
        }
	}

    public static void StartOver()
    {
        beginStartOverCountdown = true;
    }

    public static void SetScore(int pScore)
    {
        pScore = pScore;
        gameOverText.text = "You have escaped the dreaded Simbu with a score of " + pScore.ToString() + " press any key to exit";
        gameover = true;
    }
}
