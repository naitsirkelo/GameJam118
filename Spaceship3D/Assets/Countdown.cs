using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour {

    public GameObject ship;
    private ShipMovement shipMovement;
    private ShipController shipController;

    public float timeLeft = 5.0f;
    public Text startText;

    public double spaceHits = 0;

    // Start is called before the first frame update
    void Start() {

        shipMovement = ship.GetComponent<ShipMovement>();
        shipController = ship.GetComponent<ShipController>();

    }

    // Update is called once per frame
    void Update() {

        timeLeft -= Time.deltaTime;
        startText.text = "T - ";
        startText.text += (timeLeft).ToString("0");

        if (timeLeft <= 5.0f && timeLeft > 0f) {

            if (Input.GetKeyDown("space")) {
                spaceHits++;
            }

        }

        if (timeLeft <= -2f) {

           startText.GetComponent<Text>().enabled = false;

       } else if (timeLeft <= -1f) {

            shipMovement.Launch(spaceHits);
            shipController.ShowHeight();
            startText.text = "LIFT OFF";

        } else if (timeLeft <= 0f) {

            startText.text = "LIFT OFF";

        }

    }

}
