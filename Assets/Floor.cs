using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    private bool shifted = false;
    public GameObject Player;
    public GameObject Camera;
    // Player.Movement.dir;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            DIRECTION DIR = Player.GetComponent<Movement>().dir;
            if (DIR == DIRECTION.UP){
                Camera.transform.Translate(0,17,0);
            } else if (DIR == DIRECTION.DOWN){
                Camera.transform.Translate(0,-17,0);
            } else if (DIR == DIRECTION.LEFT){
                Camera.transform.Translate(-17,0,0);
            } else {
                Camera.transform.Translate(17,0,0);
            }
        }
    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if .OnCollisionEnter2D(edge);
    }
}
