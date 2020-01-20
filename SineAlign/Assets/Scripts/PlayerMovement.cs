using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerMovement : MonoBehaviour
{
    private float frequency;
    private float amplitude;
    private float newFrequency;
    private float newAmplitude;

    public GameObject player;
    public Slider frequencySlider;
    public Slider amplitudeSlider;

    private float movementSpeed = 0.01f;
    //private float newFrequency;
    private double movementFrequency;
    private float newFrequency2;
    private double sinValue;
    private float time = 0f;
    private float phaseShift = 0f;

    private CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = player.GetComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        Debug.Log(collider);
        frequency = 2;
        amplitude = 2;
        amplitudeSlider.value = amplitude;
        frequencySlider.value = frequency;
    }

    // Update is called once per frame
    void Update()
    {

        newFrequency = frequencySlider.value;
        newAmplitude = amplitudeSlider.value;

        if (newFrequency != frequency)
        {
            CalcNewFrequency();
        }

        time += Time.deltaTime;
        amplitude = newAmplitude;

        var newPosition = amplitude * Mathf.Sin(frequency * time + phaseShift);

        player.transform.position = new Vector3(0, newPosition, 0);

    }

    public void CalcNewFrequency()
    {
        float curr = (time * frequency + phaseShift) % (2.0f * Mathf.PI);
        float next = (time * newFrequency) % (2.0f * Mathf.PI);
        phaseShift = curr - next;
        frequency = newFrequency;
    }

}