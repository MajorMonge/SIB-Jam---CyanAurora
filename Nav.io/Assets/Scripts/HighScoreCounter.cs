using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreCounter : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void SetHighScore(int score)
    {
        highScoreText.text = score.ToString();
    }

    [ContextMenu("Reset HighScore")]
    private void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        Debug.Log("HighScore reset.");
    }
}
