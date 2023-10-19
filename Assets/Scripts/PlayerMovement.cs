using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    ParticleSystem particulas;
    public TMP_Text textoColeccionable;
    Rigidbody fisicas;
    AudioSource audio;
    GameManager gameManager;

    public float movX, movZ, speed;
    public double coleccionables;
    bool jump = false;

    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
        fisicas = GetComponent<Rigidbody>();
        audio = GameObject.Find("SonidoRecoger").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        speed = 8;
        coleccionables = 0;
    }

    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

        if (coleccionables == 5)
        {
            gameManager.EndGame();
        }
    }

    private void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(movX * speed, fisicas.velocity.y, movZ * speed);
        fisicas.velocity = newVelocity;

        textoColeccionable.text = coleccionables.ToString();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            if (jump)
            {
                fisicas.AddForce(Vector3.up * 30, ForceMode.Impulse);
                jump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            audio.Play();
            particulas.Play();
            coleccionables++;
        }
    }
}
