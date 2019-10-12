using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public GameObject gameOverMenu;
    public Text heightText;

    public void Start() {

        gameOverMenu.SetActive(false);
    }

    public void GameOver(double height) {

        gameOverMenu.SetActive(true);
        heightText.text = "You reached ";
        heightText.text += System.Math.Round(height).ToString();
        heightText.text += " meters!";
    }

    public void ToStore() {


    }

    public void RestartFromGameOver() {

        Time.timeScale = 0.75f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
