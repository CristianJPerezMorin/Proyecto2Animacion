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
    bool doubleJump = false;

    void speedBoostFalse()
    {
        speed = 6;
    }

    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
        fisicas = GetComponent<Rigidbody>();
        audio = GameObject.Find("SonidoRecoger").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        speed = 6;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = 12;
            Invoke("speedBoostFalse", 1);
        }

        if (coleccionables == 5)
        {
            gameManager.EndGame();
        }

        if (!doubleJump && jump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fisicas.AddForce(Vector3.up * 20, ForceMode.Impulse);
                doubleJump = true;
            }
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
        if (collision.gameObject.CompareTag("Terrain") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Platform"))
        {
            if (jump)
            {
                fisicas.AddForce(Vector3.up * 20, ForceMode.Impulse);
                doubleJump = false;
            }
            jump = false;
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
