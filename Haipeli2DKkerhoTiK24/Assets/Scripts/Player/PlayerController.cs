using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed = 5f;
   private Vector2 move;
   private Rigidbody2D body;

   private void Awake() {
      body = GetComponent<Rigidbody2D>();
   }

   // called every 1/30th of a second, used for physics
   // private void FixedUpdate(){
   //    Move();
   // }

   // // function that handles the moving stuff
   // private void Move(){
   //    //move = controls.Player.Move.ReadValue<Vector2>();
   //    Vector2 movement = new Vector2(move.x, move.y) * moveSpeed * Time.fixedDeltaTime;
   //    body.MovePosition(body.position + movement);
   // }
   
}
