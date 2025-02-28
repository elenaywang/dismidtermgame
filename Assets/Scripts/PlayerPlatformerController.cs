// using System.Numerics;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;


// add this script to the Platformer Player game object

public class PlayerPlatformerController : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;

    public int hp = 20;

    public int section = 0;      // variable to save which maze section the player is in? to be changed by ObjectManager probably

    [Header("Grounding")]
    public LayerMask groundMask;
    public float groundRayLength = 0.1f;
    public float groundRaySpread = 0.4f;
    public bool grounded = false;

    private Rigidbody2D rb2d;


    // NOTE: if it's not already there... don't forget to add Physics Material 2D to Assets, and change friction to 0.
    // Then change the player sprite --> rigidbody2d --> material to the NoFriction material you just made.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2d.linearVelocity;
        vel.x = Input.GetAxis("Horizontal") * speed;

        UpdateGrounding();

        bool inputJump = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space);
        if (inputJump && grounded) {
            vel.y = jumpForce;
        }

        rb2d.linearVelocity = vel;

        // player restarts maze section if hp runs out
        if (hp <= 0) {
            RestartSection();
        }
    }


    void UpdateGrounding() {
        Vector3 rayStart = transform.position + Vector3.up * groundRayLength;
        Vector3 rayStartLeft = transform.position + Vector3.up * groundRayLength + Vector3.left * groundRaySpread;
        Vector3 rayStartRight = transform.position + Vector3.up * groundRayLength + Vector3.right * groundRaySpread;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartLeft, Vector3.down, groundRayLength * 2, groundMask);
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartRight, Vector3.down, groundRayLength * 2, groundMask);

        // Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength * 2, Color.red);
        // Debug.DrawLine(rayStartLeft, rayStartLeft + Vector3.down * groundRayLength * 2, Color.red);
        // Debug.DrawLine(rayStartRight, rayStartRight + Vector3.down * groundRayLength * 2, Color.red);


        if (hit.collider != null || hitLeft.collider != null || hitRight.collider != null) {
            grounded = true; 
        } else {
            grounded = false;
        }
    }


    private void RestartSection() {
        // restart maze section. maybe set player's position to the maze section's start position? 
        // check section variable for which maze section the player is in
        // also reset the section's object?
        // Debug.Log("you died :( \t section has restarted");
        Debug.Log(String.Format("you died :( \t section {} has restarted", section));
        hp = 20;       // reset hp
    }


    // private void DisplayHP() {}
}
