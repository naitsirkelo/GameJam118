using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int money = 0;
    public Text moneyText;
    public GameObject boat;
    public GameObject rocket;

    void Start() {

        boat.GetComponent<SpriteRenderer>().enabled = false;
        rocket.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update() {

        moneyText.text = "$ ";

        money = PlayerPrefs.GetInt("Money", 0);
        moneyText.text += (money).ToString();
    }

    public void UpdateMoney(double height) {

        money += (int)height * 10;
        PlayerPrefs.SetInt("Money", money);
    }

    public void Show() {

        boat.GetComponent<SpriteRenderer>().enabled = true;
        rocket.GetComponent<SpriteRenderer>().enabled = true;
    }

}
