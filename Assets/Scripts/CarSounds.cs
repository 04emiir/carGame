using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSounds : MonoBehaviour {
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody carRb;
    private AudioSource carAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;


    private bool primeraM = false;
    private bool segundaM = true;
    private bool terceraM = true;
    private bool cuartaM = true;
    private bool quintaM = true;
    private bool sextaM = true;
    public AudioSource marcha;

    void Start() {
        carAudio = GetComponent<AudioSource>();
        carRb = GetComponent<Rigidbody>();
    }

    void Update() {
        EngineSound();
    }

    void EngineSound() {
        currentSpeed = carRb.velocity.magnitude *2f;

        if (currentSpeed == 0f) {
            carAudio.pitch = minPitch;
        } else if (currentSpeed > 0f && currentSpeed <= 20f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 15f;
            carAudio.pitch = minPitch + pitchFromCar;

            if(primeraM) {
                marcha.Play();
            }
            primeraM = false;
            segundaM = true;
            terceraM = true;
            cuartaM = true;
            quintaM = true;
            sextaM = true;
} else if (currentSpeed > 20f && currentSpeed <= 40f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 30f;
            carAudio.pitch = minPitch + pitchFromCar;
            if (segundaM) {
                marcha.Play();
            }
            primeraM = true;
            segundaM = false;
            terceraM = true;
            cuartaM = true;
            quintaM = true;
            sextaM = true;
        } else if (currentSpeed > 40f && currentSpeed <= 65f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 45f;
            carAudio.pitch = minPitch + pitchFromCar;
            if (terceraM) {
                marcha.Play();
            }
            primeraM = true;
            segundaM = true;
            terceraM = false;
            cuartaM = true;
            quintaM = true;
            sextaM = true;
        } else if (currentSpeed > 65f && currentSpeed <= 100f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 60f;
            carAudio.pitch = minPitch + pitchFromCar;
            if (cuartaM) {
                marcha.Play();
            }
            primeraM = true;
            segundaM = true;
            terceraM = true;
            cuartaM = false;
            quintaM = true;
            sextaM = true;
        } else if (currentSpeed > 100f && currentSpeed <= 160f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 75f;
            carAudio.pitch = minPitch + pitchFromCar;
            if (quintaM) {
                marcha.Play();
            }
            primeraM = true;
            segundaM = true;
            terceraM = true;
            cuartaM = true;
            quintaM = false;
            sextaM = true;
        } else if (currentSpeed > 160f) {
            pitchFromCar = carRb.velocity.magnitude * 2f / 90f;
            carAudio.pitch = minPitch + pitchFromCar;
            if (sextaM) {
                marcha.Play();
            }
            primeraM = true;
            segundaM = true;
            terceraM = true;
            cuartaM = true;
            quintaM = true;
            sextaM = false;
        }
    }

}