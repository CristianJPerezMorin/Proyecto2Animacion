using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject enemy;
    GameObject player;
    public float offsetY, offsetZ;
    bool cambioCam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jugador");
        offsetY = 3;
        offsetZ = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cambioCam)
            {
                cambioCam = false;
            }
            else
            {
                cambioCam = true;
            }
        }

        if (cambioCam)
        {

            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z - offsetZ);
        }

        transform.LookAt(enemy.transform);
    }
}
