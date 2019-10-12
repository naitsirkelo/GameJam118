using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public Rigidbody rb;
    float yForce = 4f;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

    }

    public void Launch(double power) {

        rb.velocity = new Vector3(0, (float) power * yForce, 0);
        Time.timeScale = 0.75f;
        Debug.Log("LAUNCH");

    }

}
