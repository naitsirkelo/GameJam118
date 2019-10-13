using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

    public Rigidbody rb;

    Vector3 launch;
    float xForce = 4f;
    float yForce = 10f;

    bool detach = false;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
        launch = new Vector3(xForce, yForce, 0);
    }

    void FixedUpdate() {

        if (!detach) {

            rb.AddForce(xForce, yForce, 0, ForceMode.Impulse);
            detach = true;
        }

    }

}
