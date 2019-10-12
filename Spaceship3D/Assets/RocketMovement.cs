using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour {

    public Rigidbody rb;
    float xForce = 1f;
    float yForce = 2f;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();
    }

    public void Launch() {

        rb.velocity = new Vector3(xForce, yForce, 0);
    }
}
