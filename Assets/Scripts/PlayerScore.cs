using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private PlayerMobileControll playerMovement;
    [SerializeField] private Dash dash;
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private TextMeshProUGUI tmpHighscore;
    
    private float score;
    private float highScore;

    private bool gameEnd;
    private bool gameStarted;

    private void Start()
    {
        tmp.gameObject.SetActive(false);
        tmpHighscore.gameObject.SetActive(true);

        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetFloat("highscore");
            tmpHighscore.text = "Highscore: " + ((int)highScore).ToString();
            return;
        }

        highScore = 0;
        PlayerPrefs.SetFloat("highscore", highScore);
    }

    private void Update()
    {
        if (gameEnd)
            return;

        if (!gameStarted && playerMovement.speed > 0)
            GameStart();

        SetScoreText();
    }

    private void SetScoreText()
    {
        score += playerMovement.speed * 0.5f * Time.deltaTime;
        tmp.text = ((int)score).ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Candy")
            TakeCandy();
    }

    private void TakeCandy()
    {
        score += 100;
        //dash.StartDash();
    }
    
    private void GameStart()
    {
        tmp.gameObject.SetActive(true);
        tmpHighscore.gameObject.SetActive(false);
        gameStarted = true;
    }

    public void PlayerLoose()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highscore", highScore);
        }
        gameEnd = true;
    }
}
