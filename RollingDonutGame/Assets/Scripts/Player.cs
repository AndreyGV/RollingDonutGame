using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
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
        transform.RotateAround(cupOfCoffe.transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
