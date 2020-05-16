using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    /*
     * THIS CLASS WILL BE USED TO KEEP TRACK ON PLAYER STATS LIKE LIVES AND SCORE
     * 
     * 
     * 
     */

    public static int playerScore = 0;
    public static int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Inceases the player score
    public void increaseScore(int score)
    {
        playerScore += score;
    }

    //decreases the player lives by 1
    public void decreaseLives()
    {
        playerLives--;
        if(playerLives == 0)
        {
            //call game over function/scene(?)
        }
    }
}
