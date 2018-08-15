using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void AddForce(Vector2 force)
    {
        Vector2 veloctity = rigidbody.velocity;
        veloctity.y = 0;
        rigidbody.velocity = veloctity;
        rigidbody.AddForce(force);
    }
}
