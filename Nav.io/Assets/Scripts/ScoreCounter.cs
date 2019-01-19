using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private HighScoreCounter highScoreCounter;

    private int score = 0;
	
	void Start () {
        EnemyBase.OnAnyEnemyKilled += IncreaseScore;
        PlayerFrigate.OnPlayerDied += SaveHighScore;
	}

    private void IncreaseScore(EnemyBase enemy, GameObject killer)
    {
        if (killer.CompareTag("Bullet"))
        {
            Bullet bullet = killer.GetComponent<Bullet>();

            if (bullet.Owner.CompareTag("Player"))
            {
                score += enemy.ScoreOnKill;
                scoreText.text = score.ToString();
            }

        }

    }

    private void SaveHighScore(PlayerFrigate player)
    {
        int hScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > hScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreCounter.SetHighScore(score);
        }
    }

    private void OnDestroy()
    {
        EnemyBase.OnAnyEnemyKilled -= IncreaseScore;
        PlayerFrigate.OnPlayerDied -= SaveHighScore;
    }
}
