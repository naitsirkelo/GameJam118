using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreController : MonoBehaviour {

    public int defaultPrice = 400;
    public Text powerText;
    public Text upgradeText;
    public Text priceText;
    public GameObject storeMenu;

    void Start() {

        storeMenu.SetActive(false);
    }

    public void ToStore() {

        storeMenu.SetActive(true);
        upgradeText.text = "Upgrade power";

        UpdateText();
    }

    public void UpgradePower() {

        int money = PlayerPrefs.GetInt("Money", 0);
        int power = PlayerPrefs.GetInt("Power", 1);
        int price = PlayerPrefs.GetInt("Price", defaultPrice);

        if ((float)money >= price) {

            money -= (int)price;
            PlayerPrefs.SetInt("Money", money);

            power++;
            PlayerPrefs.SetInt("Power", power);

            price = defaultPrice * power;
            PlayerPrefs.SetInt("Price", price);

            UpdateText();

        } else {

            upgradeText.text = "Too poor";

            UpdateText();
        }
    }

    public void RestartFromStore() {

        Time.timeScale = 0.75f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetPlayerData() {

        PlayerPrefs.SetInt("Power", 1);
        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("Price", defaultPrice);

        UpdateText();
    }

    void UpdateText() {

        powerText.text = "Rocket power: Level ";
        powerText.text += (PlayerPrefs.GetInt("Power", 1)).ToString();

        priceText.text = "Upgrade price: \n$ ";
        priceText.text +=  (PlayerPrefs.GetInt("Price", defaultPrice)).ToString();
    }

}
