using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private float minDistanceForSwipe = 5f;
    private bool isNewSwipe = true;

    public static event Action<SwipeData> OnSwipe = delegate { };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
                isNewSwipe = true;
                SendSwipe(0, 0, true);
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                isNewSwipe = false;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceMet())
        {
            var amplitudeAdd = (fingerDownPosition.y - fingerUpPosition.y)  / Screen.dpi;
            var frequencyAdd = (fingerDownPosition.x - fingerUpPosition.x)  / (2 * Screen.dpi);
            if (amplitudeAdd < 0.1f && amplitudeAdd > -0.1f)
            {
                amplitudeAdd = 0;
            }
            if (frequencyAdd < 0.05f && frequencyAdd > -0.05f && amplitudeAdd != 0)
            {
                frequencyAdd = 0;
            }
            
            SendSwipe(amplitudeAdd, frequencyAdd, isNewSwipe);
        }
    }

    private bool SwipeDistanceMet()
    {
        if (Mathf.Sqrt(Mathf.Pow((fingerDownPosition.y - fingerUpPosition.y), 2) + Mathf.Pow(fingerDownPosition.x - fingerUpPosition.x, 2)) > minDistanceForSwipe)
        {
            return true;
        }
        return false;
    }

    private void SendSwipe(float amplitudeAdd, float frequencyAdd, bool isNewSwipe)
    {
        SwipeData data = new SwipeData()
        {
            amplitudeAdd = amplitudeAdd,
            frequencyAdd = frequencyAdd,
            isNewSwipe = isNewSwipe
        };
        OnSwipe(data);
    }
}

public struct SwipeData
{
    public float frequencyAdd;
    public float amplitudeAdd;
    public bool isNewSwipe;
}

