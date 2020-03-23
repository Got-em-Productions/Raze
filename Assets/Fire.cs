using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D bRB = bullet.GetComponent<Rigidbody2D>();
            DIRECTION currentDir = gameObject.GetComponentInParent<Movement>().dir;
            switch (currentDir) {
                case DIRECTION.UP:
                    bRB.velocity = transform.up * 5;
                    break;
                case DIRECTION.LEFT:
                    bRB.velocity = transform.right * -5;
                    break;
                case DIRECTION.RIGHT:
                    bRB.velocity = transform.right * 5;
                    break;
                default:
                    bRB.velocity = transform.up * -5;
                    break;
            }
        }
    }

}
