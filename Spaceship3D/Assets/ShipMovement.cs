using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public Rigidbody rb;
    float yForce = 10f;
    bool launched = false;
    float winHeight = 20f;

    public GameObject ship;
    private GameController gameController;
    private CameraController cameraController;
    private GameOverController gameOver;
    private ShipController shipController;
    private RocketMovement rocketMovement;

    public bool movingDown;
    public Vector3 LastPOS;
    public Vector3 NextPOS;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {

            gameController = gameControllerObject.GetComponent<GameController>();
        } else {

            Debug.Log("No GameController");
        }

        GameObject rocketObject = GameObject.FindWithTag("Rocket");
        if (rocketObject != null) {

            rocketMovement = rocketObject.GetComponent<RocketMovement>();
        } else {

            Debug.Log("No RocketMovement");
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

    public void Launch(double power) {

        launched = true;
        rb.velocity = new Vector3(0, (float) power * yForce, 0);
        Time.timeScale = 0.75f;
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
            //rocketMovement.Launch();
        }

    }

}
