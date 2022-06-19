using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float attractionForce;
    public float repulsionForce;

    private Rigidbody playerRb;
    private GameObject cupOfCoffe;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        cupOfCoffe = GameObject.Find("Cup");
        
    }

    // Update is called once per frame
    void Update()
    {

        //Vector from the player to the object
        Vector3 attractionDirection = (cupOfCoffe.transform.position - playerRb.transform.position).normalized;

        // Rotation player around the object
        transform.RotateAround(cupOfCoffe.transform.position, Vector3.down, speed * Time.deltaTime);
        
        //Attraction to the center with the AddForce (doesnt work good)
        //playerRb.AddForce(attractionDirection * attrectionForce);

        // Attraction to the center by the transform.Translate
        transform.Translate(attractionDirection * attractionForce * Time.deltaTime,Space.World);

        if (Input.GetKeyUp(KeyCode.Space))
        { 
            //transform.Translate(-attractionDirection * repulsionForce * Time.deltaTime, Space.World);
            playerRb.AddForce(-attractionDirection * repulsionForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
