using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public float deadzone = -45;
    public logicScript logic;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * movementSpeed) * Time.deltaTime;
        if (transform.position.x < deadzone) 
        {   Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }

        if (timer < 2) 
        {
            timer = timer + Time.deltaTime;
        } 
        else 
        {
            if (logic.playerScore >= logic.getMaxScore()) 
            {
                if (movementSpeed < 35)
                {
                    movementSpeed = movementSpeed + 1;
                    logic.setMaxScore(logic.getMaxScore() + 3);

                    Debug.Log("Speed Increased; Max Score is " + logic.getMaxScore() + "; Speed is " + movementSpeed);
                } 
            }
            timer = 0;
        }
    }
}
