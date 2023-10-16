using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject panel;
    GameObject Terrain, Player, Enemy;
    GameObject[] listOfItems;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Terrain = GameObject.Find("Suelo");
        Player = GameObject.Find("Jugador");
        Enemy = GameObject.Find("Enemigo");
        
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            listOfItems = GameObject.FindGameObjectsWithTag("Item");

            Terrain.SetActive(false);
            Player.SetActive(false);
            Enemy.SetActive(false);
            foreach(var item in listOfItems)
            {
                item.SetActive(false);
            }

            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
