//using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 400;
    public float flapStrength = 10;
    public Rigidbody2D rb;

    public Animator animator;
    public logicScript logic;
    public bool birdIsAlive = true;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive) 
        {
            rb.velocity = Vector2.up * flapStrength;
            animator.Play("flap");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       Debug.Log($"trigerred with {collision.tag}");

        switch ((string)collision.tag) 
        {
            case "scoreArea":
                logic.addScore(1);
                break;
        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
       Debug.Log($"collided with {collision.gameObject.name}");

        switch ((string)collision.gameObject.name) 
        {
            case "top":
            case "bottom":
            case "Wall":
            case "Floor":
                logic.GameOver();
                birdIsAlive = false;
                break;
        }
    }
}
