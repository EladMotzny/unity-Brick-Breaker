using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position; // move the ball to the middle of the paddle
        }

        if (Input.GetButtonDown("Jump") && !inPlay) // space bar
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bottom"))
        {
            Debug.Log("Bootom of screen");
            rb.velocity = Vector2.zero; // zero out the forces on the ball
            inPlay = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("brick"))
        {
            Destroy(collision.gameObject);
        }
    }
}
