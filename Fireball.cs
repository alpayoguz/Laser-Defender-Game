using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 20;

    private void Start()
    {
        rb.velocity = transform.up * speed;
    }

   

}
