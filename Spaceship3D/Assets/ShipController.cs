using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

    public Text heightText;
    bool show;
    float height = 0f;

    // Start is called before the first frame update
    void Start() {

        heightText.text = "";
    }

    // Update is called once per frame
    void Update() {

        if (show) {

            heightText.GetComponent<Text>().enabled = true;
            //heightText.text = "Height:\n";
            heightText.text = System.Math.Round(height).ToString();

        } else {

            heightText.GetComponent<Text>().enabled = false;
        }

        if (transform.position.y > height) {

            height = transform.position.y;
        }

    }

    public void ShowHeight() {

        show = true;
    }

    public float GetHeight() {

        return height;
    }
}
