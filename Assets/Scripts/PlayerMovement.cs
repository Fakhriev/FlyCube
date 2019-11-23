using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;

    [SerializeField] private float acceleration;
    [SerializeField] private float speedMax;

    [SerializeField] private float speedSide;

    public float speed;
    private Vector3 moveVector;

    private void Update()
    {/*
        if (Input.GetKey(KeyCode.Space) && speed <= speedMax)
            Acceleration(1);
       
        if(!Input.GetKey(KeyCode.Space) && speed > 0)
            Acceleration(-1);  */

        if ((Input.GetAxisRaw("Horizontal") > 0 || Input.GetAxisRaw("Vertical") > 0) && speed <= speedMax)
            Acceleration(1);

        if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) && speed > 0)
            Acceleration(-1);


        if (speed < 0)
            speed = 0;
    }

    private void FixedUpdate()
    {
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -20, 20), Mathf.Clamp(transform.position.y, -20, 20), transform.position.z);
        MoveToVector();
    }

    private void Acceleration(float value)
    {
        if (value > 0)
            speed += (acceleration * Time.deltaTime);

        if(value < 0)
            speed -= (acceleration * 1.25f * Time.deltaTime);
    }

    private void MoveToVector()
    {
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speedSide;
        moveVector.y = Input.GetAxisRaw("Vertical") * speedSide;
        moveVector.z = speed;
        
        player.MovePosition(transform.position + moveVector * Time.fixedDeltaTime);
    }
}
