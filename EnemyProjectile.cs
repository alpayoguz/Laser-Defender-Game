using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    int speed = 20;

    [SerializeField] Rigidbody2D rb;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }


    }








    private void Start()
    {
        rb.velocity = -transform.up * speed;   
        
    }

    private void Update()
    {
       
    }


}
