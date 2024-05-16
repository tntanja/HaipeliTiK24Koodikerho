using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float currentSpeed = 3;
    private Rigidbody2D body;
    private Transform playerTransform;
    
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameManager.instance.IsGamePlay()){
            return;
        }

        GetPlayer();
        Move();
    }
    
    private void Move(){
        if(playerTransform == null){
            return;
        }

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    private void GetPlayer() {
        if(playerTransform == null){
            playerTransform = GameManager.instance.playerController.transform;
        }
    }
}
