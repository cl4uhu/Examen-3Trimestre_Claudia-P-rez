using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour

{
    Rigidbody2D rBody2D;
    Collider2D collider;

    public float bulletSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
       rBody2D = GetComponent <Rigidbody2D> ();
       rBody2D.AddForce(transform.right* bulletSpeed, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {      
        Destroy (this.gameObject);
    }
}
