using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENUM for character facing
public enum DIRECTION { UP, DOWN, LEFT, RIGHT }

public class Movement : MonoBehaviour
{
    // Camera object
    
    
    // Raycast hitbois
    private RaycastHit2D upRay, downRay, leftRay, rightRay;
    
    // Variables for ability to move, speed, cooldown, direction, position
    private bool canMove = true, moving = false;
    private int speed = 5, cooldown = 0;
    
    [System.NonSerialized]
    public DIRECTION dir = DIRECTION.DOWN;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        initializeRays();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown--;
        if (canMove){
            pos = transform.position;
            move();
        }
        
        if (moving){
            if (transform.position == pos){
                moving = false;
                canMove = true;

                move();
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
    }

    private void initializeRays() {
        upRay = Physics2D.Raycast(transform.position, Vector2.up, 1);
        downRay = Physics2D.Raycast(transform.position, Vector2.down, 1);
        leftRay = Physics2D.Raycast(transform.position, Vector2.left, 1);
        rightRay = Physics2D.Raycast(transform.position, Vector2.right, 1);
    }

    private void move(){
        initializeRays();
        // if cooldown <=0 then character is in the right spot.
        if (cooldown <= 0){
            //format: if character not facing direction, character faces direction. Else character moves in direction.
            if (Input.GetKey(KeyCode.W)){
                if (upRay.collider == null){    
                    if(dir != DIRECTION.UP){
                        cooldown = 5;
                        dir = DIRECTION.UP;
                    } else {
                        canMove = false;
                        moving = true;
                        pos += Vector3.up;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.S)){
                if (downRay.collider == null){
                    if(dir != DIRECTION.DOWN){
                        cooldown = 5;
                        dir = DIRECTION.DOWN;
                    } else {
                        canMove = false;
                        moving = true;
                        pos += Vector3.down;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.A)){
                if (leftRay.collider == null){
                    if(dir != DIRECTION.LEFT){
                        cooldown = 5;
                        dir = DIRECTION.LEFT;
                    } else {
                        canMove = false;
                        moving = true;
                        pos += Vector3.left;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.D)){
                if (rightRay.collider == null){
                    if(dir != DIRECTION.RIGHT){
                        cooldown = 5;
                        dir = DIRECTION.RIGHT;
                    } else {
                        canMove = false;
                        moving = true;
                        pos += Vector3.right;
                    }
                }
            }
        }
    }
}
