using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
   
    void Update()
    {
        checkPosition();
    }

    void checkPosition()
    {
        if(transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
