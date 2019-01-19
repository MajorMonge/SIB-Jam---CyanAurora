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
            if (Input.GetButtonDown("Fire1"))
            {
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
        StartCoroutine(Wait(0.8f));
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        isGameOver = true;
        gameOverText.SetActive(true);
    }

}
