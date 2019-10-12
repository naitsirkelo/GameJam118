using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {

    public Rigidbody rb;
    float yForce = 1.5f;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown("space")) {
            //rb.velocity = new Vector3(0, yForce, 0);
        }

    }

    public void Launch(double power) {

        rb.velocity = new Vector3(0, (float) power * yForce, 0);
        Debug.Log("LAUNCH");

    }

}
