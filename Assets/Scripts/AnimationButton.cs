using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Animacion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animacion()
    {
        if (this.gameObject.transform.localScale == new Vector3(1, 1, 1) || this.gameObject.transform.localScale == new Vector3(0.3f, 0.2f, 1))
        {
            float newPosition = this.gameObject.transform.position.x - 400;
            LeanTween.moveLocalX(this.gameObject, newPosition, 2).setEaseInElastic();
        }
        else
        {
            LeanTween.scale(this.gameObject, new Vector3(2, 2, 1), 2).setEaseInOutBack();
        }
    }
}
