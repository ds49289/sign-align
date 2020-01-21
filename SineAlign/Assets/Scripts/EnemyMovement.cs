using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 0.1f;

    [SerializeField]
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PerformMovement();
    }

    private void PerformMovement()
    {
        enemy.transform.position = new Vector3(enemy.transform.position.x - moveSpeed, enemy.transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger enter");
        Destroy(enemy);
    }
}
