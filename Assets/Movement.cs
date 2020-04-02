using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENUM for character facing
public enum DIRECTION { UP, DOWN, LEFT, RIGHT }

public class Movement : MonoBehaviour
{
    // Direction bois
    
    public Sprite W_Sp;
    public Sprite S_Sp;
    public Sprite A_Sp;
    public Sprite D_Sp;
    private SpriteRenderer sr;

    // Raycast hitbois
    private RaycastHit2D upRay, downRay, leftRay, rightRay;
    
    // Variables for ability to move, speed, cooldown, direction, position
    private bool canMove = true, moving = false;
    private int speed = 5, cooldown = 0;
<<<<<<< HEAD
    
    [System.NonSerialized]
=======
>>>>>>> Camera_Testing
    public DIRECTION dir = DIRECTION.DOWN;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        initializeRays();
        sr = GetComponent<SpriteRenderer>();
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
                if (dir != DIRECTION.UP){
                    cooldown = 5;
                    dir = DIRECTION.UP;
                    sr.sprite = W_Sp;
                } else {
                    if (upRay.collider == null){
                        canMove = false;
                        moving = true;
                        pos += Vector3.up;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.S)){
                if (dir != DIRECTION.DOWN){
                    cooldown = 5;
                    dir = DIRECTION.DOWN;
                    sr.sprite = S_Sp;
                } else {
                    if (downRay.collider == null){
                        canMove = false;
                        moving = true;
                        pos += Vector3.down;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.A)){
                if (dir != DIRECTION.LEFT){
                    cooldown = 5;
                    dir = DIRECTION.LEFT;
                    sr.sprite = A_Sp;
                } else {
                    if (leftRay.collider == null){
                        canMove = false;
                        moving = true;
                        pos += Vector3.left;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.D)){
                if (dir != DIRECTION.RIGHT){
                    cooldown = 5;
                    dir = DIRECTION.RIGHT;
                    sr.sprite = D_Sp;
                } else {
                    if (rightRay.collider == null){
                        canMove = false;
                        moving = true;
                        pos += Vector3.right;
                    }
                }
            }
        }
    }
}
