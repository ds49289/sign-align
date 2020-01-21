using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class SineRenderer : MonoBehaviour
{
    [SerializeField]
    private int numberOfPoints = 10;

    public float waveWidth = 0.5f;
    public float length = 50;
    public float waveHeight = 10;

    private LineRenderer lineRenderer;
    private List<Vector3> points = new List<Vector3>(); // Generated points before Simplify is used.

    [SerializeField]
    Color sineColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement.OnSineWaveChange += OnSineWaveChange;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = sineColor;
        lineRenderer.endColor = sineColor;
        lineRenderer.startWidth = waveWidth;
        lineRenderer.endWidth = waveWidth;
        var data = new SineWaveData()
        {
            amplitude = 4,
            frequency = 2,
            phaseShift = 0
        };
        GeneratePoints(data);
        lineRenderer.SetPositions(points.ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        var array = points.ToArray();
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(array);
    }

    public void GeneratePoints(SineWaveData data)
    {
        points.Clear();
        float step = length / numberOfPoints;
        for (int i = -5; i < numberOfPoints; ++i)
        {
            points.Add(new Vector3(i * step, Mathf.Sin(i * step * data.frequency + data.phaseShift + data.time * data.frequency) * data.amplitude, 0));
        }
    }

    private void OnSineWaveChange(SineWaveData data)
    {
        GeneratePoints(data);
    }
}
