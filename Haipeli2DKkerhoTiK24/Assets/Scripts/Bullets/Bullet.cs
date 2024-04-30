using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float currentSpeed = 5f;
    
    private float lifespan = 2.5f;
    private float lifeTimer;


    private void OnEnable(){
        lifeTimer = lifespan;
    }
    // Update is called once per frame
    void Update()
    {

        if (!GameManager.instance.IsGamePlay()) {
            return;
        }

        transform.Translate(Vector2.up * -1 * currentSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;    // lifeTimer = lifeTimer - Time.deltaTime;
        if(lifeTimer <= 0){
            BulletPoolManager.Instance.ReturnBullet(gameObject);
        }
    }
}
