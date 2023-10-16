using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comportamiento : MonoBehaviour
{
    Rigidbody fisicas;
    public float movX, movZ, speed;
    bool saltar;

    void Start()
    {
        fisicas = GetComponent<Rigidbody>();

        saltar = false;
        speed = 5;
    }

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(movX * speed, fisicas.velocity.y, movZ * speed);
        fisicas.velocity = newVelocity;

        if (saltar)
        {
            fisicas.AddForce(Vector3.up * 5, ForceMode.Impulse);
            saltar = false;
        }
    }
}
