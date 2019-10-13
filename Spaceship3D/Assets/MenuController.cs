using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject audio;

    void Start() {

        DontDestroyOnLoad(this.audio);
    }

    public void Play() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() {

        Application.Quit();
    }

}
