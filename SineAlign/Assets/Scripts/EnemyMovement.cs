using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private float ringOfDoomSpeedIncrease = 0.5f;

    [SerializeField]
    private float ringOfBloomSpeedDecrease = -0.5f;

    public static event Action<float> SpeedChange = delegate { };


    private Transform enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpeedChange += OnSpeedChange;
        enemy = GetComponent<Transform>();
        Debug.Log(this.enemy.tag);
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

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Tag: " + enemy.tag);
        if (enemy.tag.Equals("RingOfDoom"))
        {
            Debug.Log("speed increase should be called");
            SpeedChange(ringOfDoomSpeedIncrease);
        }
        if (enemy.tag.Equals("RingOfBloom"))
        {
            Debug.Log("speed descrease should be called");

            SpeedChange(ringOfBloomSpeedDecrease);
        }
        Destroy(enemy.gameObject);
    }

    private void OnSpeedChange(float speedAdd)
    {
        moveSpeed += speedAdd;
    }


}
