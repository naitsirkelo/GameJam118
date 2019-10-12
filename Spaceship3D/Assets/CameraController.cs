﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    float ZoomAmount = 0f;
    float MaxToClamp = 10f;
    float ROTSpeed = 10f;

    Transform cam;
    public Transform target;

    // Start is called before the first frame update
    void Start() {

        cam = Camera.main.transform;

    }

    // Update is called once per frame
    void Update() {

        Vector3 targetPosition = new Vector3(target.position.x + 1.24f, target.position.y, cam.position.z);
        cam.position = targetPosition;

        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        gameObject.transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

    }

}