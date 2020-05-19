using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform purpleExplosion;
    public Transform greenExplosion;
    public GameManager gm;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            transform.position = paddle.position;
            return; //if the game is over don't place the ball on the paddle and freeze the game
        }

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
            rb.velocity = Vector2.zero; // zero out the forces on the ball
            inPlay = false;
            gm.UpdateLives(-1);// lost 1 life

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.transform.CompareTag("purpleBrick")|| collision.transform.CompareTag("greenBrick"))
        {
            Bricks brick = collision.gameObject.GetComponent<Bricks>();
            if (brick.hitsToBreak > 1)
            {
                brick.BreakBrick();
            }
            else
            {
                //make explosion effect from the brick
                if (collision.transform.CompareTag("purpleBrick")) {
                    Transform newExplosion = Instantiate(purpleExplosion, collision.transform.position, collision.transform.rotation);

                    //remove the new object from the hierarchy
                    Destroy(newExplosion.gameObject, 2.5f);
                }

                if (collision.transform.CompareTag("greenBrick"))
                {
                    Transform newExplosion = Instantiate(greenExplosion, collision.transform.position, collision.transform.rotation);

                    //remove the new object from the hierarchy
                    Destroy(newExplosion.gameObject, 2.5f);
                }


                //add to the score the bricks point value
                gm.UpdateScore(brick.points);
                gm.UpdateNumberOfBricks();

                //destroy the brick
                Destroy(collision.gameObject);
            }
            audio.Play();
        }
    }
}
