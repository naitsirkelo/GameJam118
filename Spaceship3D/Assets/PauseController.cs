using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public static bool gamePaused = false;

    public GameObject pauseMenu;

    void Start() {

        Resume();

    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (gamePaused) {

                Resume();

            } else {

                Pause();

            }
        }
    }

    public void Resume() {

        pauseMenu.SetActive(false);
        Time.timeScale = 0.75f;
        gamePaused = false;

    }

    public void Pause() {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;

    }

    public void QuitFromPause() {

        Application.Quit();

    }

    public void RestartFromPause() {

        Time.timeScale = 0.75f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
