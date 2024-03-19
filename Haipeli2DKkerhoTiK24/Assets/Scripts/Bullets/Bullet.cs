using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float currentSpeed = 5f;
    
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * -1 * currentSpeed * Time.deltaTime);
    }
}
