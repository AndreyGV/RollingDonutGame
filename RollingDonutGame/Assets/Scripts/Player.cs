using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float attractionForce;
    public float repulsionForce;

    private float smoothTime = 3;
    private Rigidbody playerRb;
    private GameObject cupOfCoffe;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cupOfCoffe = GameObject.Find("Cup");
        
    }

    void Update()
    {
        transform.RotateAround(cupOfCoffe.transform.position, Vector3.down, speed * Time.deltaTime); 
        transform.Translate(Attraction() * attractionForce * Time.deltaTime,Space.World);
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(-Attraction() * repulsionForce);

        }
    }

    private Vector3 Attraction()
    {
        Vector3 playerPosition = playerRb.transform.position;
        Vector3 cupPosition = cupOfCoffe.transform.position;
        Vector3 attractionDirection = (cupPosition - playerPosition).normalized;
        return attractionDirection;
    }
}
