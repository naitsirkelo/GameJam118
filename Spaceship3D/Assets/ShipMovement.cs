using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public Rigidbody rb;
    float yForce = 5.75f;
    bool launched = false;
    float winHeight = 1420f;
    bool detach = false;

    public GameObject ship;
    public GameObject rocket;
    private GameController gameController;
    private CameraController cameraController;
    private GameOverController gameOver;
    private ShipController shipController;

    public bool movingDown;
    public Vector3 LastPOS;
    public Vector3 NextPOS;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {

            gameController = gameControllerObject.GetComponent<GameController>();
        } else {

            Debug.Log("No GameController");
        }

        GameObject gameOverObject = GameObject.FindWithTag("GameOverController");
        if (gameOverObject != null) {

            gameOver = gameOverObject.GetComponent<GameOverController>();
        } else {

            Debug.Log("No GameOverController");
        }

        GameObject cameraObject = GameObject.FindWithTag("MainCamera");
        if (cameraObject != null) {

            cameraController = cameraObject.GetComponent<CameraController>();
        } else {

            Debug.Log("No CameraController");
        }

        shipController = ship.GetComponent<ShipController>();

        NextPOS.y = transform.position.y;
    }

    public void Launch(double hits) {

        launched = true;
        int powerLevel = PlayerPrefs.GetInt("Power", 1);
        rb.velocity = new Vector3(0, (float) (hits * yForce * powerLevel), 0);
        Time.timeScale = 0.75f;
    }

    public void LaunchAudio() {

        audioSource.Play();
    }

    void LateUpdate() {

        if (launched) {

            NextPOS.y = transform.position.y;

            if (LastPOS.y > NextPOS.y) {

                if (!movingDown) {

                    gameController.UpdateMoney(shipController.GetHeight());
                    gameOver.GameOver(shipController.GetHeight());
                    movingDown = true;
                }
            }

            LastPOS.y = NextPOS.y;
        }

        if (transform.position.y > winHeight) {

            ship.GetComponent<SpriteRenderer>().enabled = false;

            cameraController.ReachedTop();
            gameController.Show();

            if (!detach) {

                Instantiate(rocket, new Vector3(1, winHeight, 0.4f), Quaternion.identity);
                detach = true;
            }

        }

    }

}
