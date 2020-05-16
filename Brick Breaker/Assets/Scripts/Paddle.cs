using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class will do everything concerning the paddle
public class Paddle : MonoBehaviour
{
    [Tooltip("Change to increase/decrease movement speed")] [SerializeField] float moveSpeed = 1f;//10 seems to be fine in terms of speed
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the paddle according to user input
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * moveSpeed;
    }
}
