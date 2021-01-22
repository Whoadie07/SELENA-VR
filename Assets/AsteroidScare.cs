using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScare : MonoBehaviour
{
    public GameObject asteroid;
    public float speed = 1f;
    private Vector3 startPos;
    private Vector3 playerPos;
    public bool movingToTarget = false;
    private void Start()
    {

    }
    private void Update()
    {
        Vector3 destination;
        if (movingToTarget)
            destination = (startPos + playerPos) * 2f ;
        else
            destination = startPos;
        Vector3 movement = destination - transform.position;
        float distance = speed * Time.fixedDeltaTime;
        if (movement.magnitude > distance)
            movement = movement.normalized * distance;
        GetComponent<Rigidbody>().MovePosition(transform.position + movement);
    }
    private void OnTriggerEnter(Collider other)
    {
            asteroid = GameObject.Find("MovingAsteroid");
            movingToTarget = true;
            startPos = asteroid.transform.position;
            playerPos = other.transform.position;
    }
}
