using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBlocks : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col);
        if (col.gameObject.tag == "Block") {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
