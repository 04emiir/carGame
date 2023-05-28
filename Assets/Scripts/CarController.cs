using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class CarController : MonoBehaviour {
    public enum ControlMode {
        Keyboard,
        Buttons
    };

    public enum Axel {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axel axel;
    }

    public ControlMode control;

    public float maxAcceleration = 30.0f;
    public float brakeAcceleration = 50.0f;

    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;

    public TextMeshProUGUI marchaText;

    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private Rigidbody carRb;


    void Start() {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;

    }

    void Update() {
        GetInputs();
        AnimateWheels();
        float speed = carRb.velocity.magnitude * 2;
        if (speed == 0f) {
            marchaText.text = "N";
        } else if (speed > 0f && speed <= 20f) {
            marchaText.text = "1";
        } else if (speed > 20f && speed <= 40f) {
            marchaText.text = "2";
        } else if (speed > 40f && speed <= 65f) {
            marchaText.text = "3";
        } else if (speed > 65f && speed <= 100f) {
            marchaText.text = "4";
        } else if (speed > 100f && speed <= 160f) {
            marchaText.text = "5";
        } else if (speed > 160f) {
            marchaText.text = "6";
        }



    }

    void LateUpdate() {
        Move();
        Steer();
        Brake();
    }

    public void MoveInput(float input) {
        moveInput = input;
    }

    public void SteerInput(float input) {
        steerInput = input;
    }

    void GetInputs() {
        if (control == ControlMode.Keyboard) {
            moveInput = Input.GetAxis("Vertical");
            steerInput = Input.GetAxis("Horizontal");
        }
    }

    void Move() {
        foreach (var wheel in wheels) {
            wheel.wheelCollider.motorTorque = moveInput * 600 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer() {
        foreach (var wheel in wheels) {
            if (wheel.axel == Axel.Front) {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void Brake() {
        if (Input.GetKey(KeyCode.Space) || moveInput == 0) {
            foreach (var wheel in wheels) {
                wheel.wheelCollider.brakeTorque = 300 * brakeAcceleration * Time.deltaTime;

            }

        } else {
            foreach (var wheel in wheels) {
                wheel.wheelCollider.brakeTorque = 0;
            }

        }
    }

    void AnimateWheels() {
        foreach (var wheel in wheels) {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

}
