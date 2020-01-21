using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndBoxMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;
    public static event Action<float> SpeedChange = delegate { };
    private Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        enemy.position = new Vector3(enemy.transform.position.x - moveSpeed, enemy.transform.position.y, 0);
    }
}
