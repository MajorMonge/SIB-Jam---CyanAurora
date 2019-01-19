using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour {

    [SerializeField]
    private GameObject gameOverText;

    private bool isGameOver = false;

	// Use this for initialization
	void Start () {
        PlayerFrigate.OnPlayerDied += HandlePlayerDeath;
	}

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetButtonDown("Restart"))
            {
                Debug.Log("Enter Pressed!");
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    private void OnDestroy()
    {
        PlayerFrigate.OnPlayerDied -= HandlePlayerDeath;
    }

    private void HandlePlayerDeath(PlayerFrigate pf)
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

}
