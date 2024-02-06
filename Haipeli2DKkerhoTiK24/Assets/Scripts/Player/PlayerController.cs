using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   public float moveSpeed = 5f;
   private Rigidbody2D body;
   private Master controls;
   private Vector2 moveInput;

   private void Awake() {
      controls = new Master();
      body = GetComponent<Rigidbody2D>();
   }

   // kutsutaan kun objekti aktiivinen
   private void OnEnable() {
      controls.Enable();   //aktivoi liikkumis näppäimet
   }

   // kutsutaan kun objekti ei ole enää aktiivinen
   private void OnDisable() {
      controls.Disable();  // lopettaa näppäinten toiminnon
   }

   // käytetään fysiikkaan liittyvissä updatessa
   private void FixedUpdate(){
      Move();
   }

   // liikkumisen toiminnallisuus
   private void Move(){
      moveInput = controls.Player.Move.ReadValue<Vector2>();
      Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
      body.MovePosition(body.position + movement);
   }
   
}
