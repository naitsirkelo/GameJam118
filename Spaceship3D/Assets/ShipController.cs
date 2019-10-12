using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

    public Text heightText;
    bool show;

    // Start is called before the first frame update
    void Start() {

        heightText.text = "";

    }

    // Update is called once per frame
    void Update() {

        if (show) {

            heightText.GetComponent<Text>().enabled = true;
            heightText.text = "Height: ";
            heightText.text += (transform.position.y).ToString();

        } else {

            heightText.GetComponent<Text>().enabled = false;

        }

    }

    public void ShowHeight() {

        show = true;

    }
}
