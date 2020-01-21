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

    private float swipeStartFrequency;
    private float swipeStartAmplitude;

    [SerializeField]
    public GameObject player;
    //public Slider frequencySlider;
    //public Slider amplitudeSlider;

    private float movementSpeed = 0.01f;
    //private float newFrequency;
    private double movementFrequency;
    private float newFrequency2;
    private double sinValue;
    private float time = 0f;
    private float phaseShift = 0f;

    private SphereCollider collider;

    public static event Action<SineWaveData> OnSineWaveChange = delegate { };


    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    // Start is called before the first frame update
    void Start()
    {
        collider = player.GetComponent(typeof(SphereCollider)) as SphereCollider;
        Debug.Log(collider);
        frequency = 2;
        amplitude = 4;
        newFrequency = 2;
        newAmplitude = 4;
    }

    // Update is called once per frame
    void Update()
    {
        //if (newFrequency != frequency || amplitude != newAmplitude)
        //{
        //    if(newFrequency != frequency)
        //    {
        //        CalcNewFrequency();
        //    }
        //    amplitude = newAmplitude;            
        //}
        CalcNewFrequency();
        amplitude = newAmplitude;

        
        time += Time.deltaTime;

        SineWaveData data = new SineWaveData()
        {
            amplitude = amplitude,
            frequency = frequency,
            phaseShift = phaseShift,
            time = time
        };
        OnSineWaveChange(data);


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

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        if (data.isNewSwipe)
        {
            swipeStartFrequency = frequency;
            swipeStartAmplitude = amplitude;
        }
        newFrequency = Mathf.Clamp(swipeStartFrequency + data.frequencyAdd, 0.5f, Mathf.PI);
        newAmplitude = Mathf.Clamp(swipeStartAmplitude + data.amplitudeAdd, 0.3f, 4);
    }
}

public struct SineWaveData
{
    public float frequency;
    public float amplitude;
    public float phaseShift;
    public float time;
}