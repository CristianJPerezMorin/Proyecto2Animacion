using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActions : MonoBehaviour
{

    void DestroyThisItem()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("DestroyThisItem", 3);
        }
    }
}
