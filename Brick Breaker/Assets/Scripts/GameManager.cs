using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverPanel;
    public GameObject loadLevelPanel;
    public GameObject gameWonPanel;
    public int numberOfBricks;
    public Transform[] levels;
    private int currentLevelIndex;

    AudioSource[] objectSounds;//Gets all the Audio sources from the object
    AudioSource gameOverSound;
    AudioSource victorySound;
    AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        livesText.text = "Lives: "+ lives;
        scoreText.text = "Score: " + score;
        numberOfBricks = GameObject.FindGameObjectsWithTag("purpleBrick").Length + GameObject.FindGameObjectsWithTag("greenBrick").Length;
        objectSounds = GetComponents<AudioSource>();
        gameOverSound = objectSounds[0];//First audio source
        victorySound = objectSounds[1];//Second audio source
        gameMusic = objectSounds[2];//Third audio source
        gameMusic.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLives(int changeInLives)
    {
        lives += changeInLives;

        //Check for no lives left and trigger the end of the game
        if(lives <= 0)
        {
            lives = 0;
            GameOver();
        }

        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore (int points)
    {
        score += points;
        if(score< 0)
        {
            score = 0;
        }
        scoreText.text = "Score: " + score;
    }

    public void UpdateNumberOfBricks()
    {
        numberOfBricks--;
        if (numberOfBricks <= 0) // check if level is complete
        {
            if (currentLevelIndex >= levels.Length - 1)
            {//no more levels to load
                GameWon();
            }
            else
            {
                loadLevelPanel.SetActive(true);
                loadLevelPanel.GetComponentInChildren<Text>().text = "Level " + (currentLevelIndex + 2);
                gameOver = true;
                Invoke("LoadLevel", 3f);// freeze the game for 3 seconds and the activate the next level
            }
        }
    }

    void LoadLevel()
    {
        currentLevelIndex++;
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("purpleBrick").Length + GameObject.FindGameObjectsWithTag("greenBrick").Length;
        gameOver = false; //reanable the game
        loadLevelPanel.SetActive(false);

    }


   void LoadCurrentLevel()
    {
        Instantiate(levels[currentLevelIndex], Vector2.zero, Quaternion.identity);
        numberOfBricks = GameObject.FindGameObjectsWithTag("purpleBrick").Length + GameObject.FindGameObjectsWithTag("greenBrick").Length;
        gameOver = false; //reanable the game
        gameOverPanel.SetActive(false);
        UpdateLives(3);
        UpdateScore(-10);
    }
    void GameOver()
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        gameMusic.Stop();
        gameOverSound.Play();
    }
    void GameWon()
    {
        gameOver = true;
        gameWonPanel.SetActive(true);
        gameMusic.Stop();
        victorySound.Play();
    }

    public void playAgain()
    {
        if (currentLevelIndex == levels.Length - 1 && numberOfBricks == 0) //No more levels- start again from the first level
        {
            SceneManager.LoadScene("Main");
        }
        else
        {
            LoadCurrentLevel();
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
