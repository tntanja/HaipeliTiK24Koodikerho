using System;
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
   private Vector2 aimInput;

   public Transform gunTransform;

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

   private void Update() {
      Shoot();

      if (UsingMouse()) {
         AimWithMouse();
      } else {
         //AimWithKeyboard();
      }

   }

   private void Shoot() {
      if (controls.Player.Shoot.triggered){
         Debug.Log("shoot nappula toimii");
         GameObject bullet = BulletPoolManager.Instance.GetBullet();
         bullet.transform.position = gunTransform.position;
         bullet.transform.rotation = gunTransform.rotation;
      }
   }
   
   private bool UsingMouse() {
      if(Mouse.current.delta.ReadValue().sqrMagnitude > 0.1) {
         return true;
      }

      return false;
   }

   private void AimWithMouse() {
      aimInput = controls.Player.Aim.ReadValue<Vector2>();

      if(aimInput.sqrMagnitude > 0.1) {
         Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseWorldPosition.current.position.ReadValue());
         mouseWorldPosition.z = 0;

         Vector2 aimDirection = (mouseWorldPosition - gunTransform.position).normalized;

         float angle = Mathf.Atan2(aimDirection.x, aimDirection.y) * Mathf.Rad2Deg;

         gunTransform.rotation = Quaternion.Euler(0, 0, angle);
      }
   }
}
