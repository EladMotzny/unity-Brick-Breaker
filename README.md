# Brick Break

## Introduction and Instruction:
This game is the well known classic Brick Bracker which was developed for the Game Development course.
You're objective is to destroy all of the bricks in all three levels to win!

![Example](https://user-images.githubusercontent.com/33173449/82437632-66e5c300-9aa0-11ea-9e60-5731a4e18c2b.gif)

- The paddle- ![paddle](https://user-images.githubusercontent.com/33619352/82352691-ff2f6980-9a06-11ea-949b-0be949c8dcc7.JPG)
Can move using the left and right arrows, and can not cross the game walls. (Closed world)


- The ball- ![ball](https://user-images.githubusercontent.com/33619352/82353253-d5c30d80-9a07-11ea-93b3-e7a9d40eaa78.JPG)
Launch it using space every beggining of a level or when a life lost.
The ball has a unity built in physics "Bouncy" which calculates how to bounce the ball each time it collides with a wall, a brick or the paddle.

- The bricks-
  - Purple brick- ![purpleBrick](https://user-images.githubusercontent.com/33619352/82357949-79afb780-9a0e-11ea-850f-98a6951218ba.JPG)
  - Green brick- ![green](https://user-images.githubusercontent.com/33173449/82437082-7b758b80-9a9f-11ea-80fa-c0b8a00a5edb.PNG)
  - Green brick after one hit- ![greenBroken](https://user-images.githubusercontent.com/33173449/82437159-a4961c00-9a9f-11ea-98da-1c17cebe4e39.PNG)
  - Grey brick (can't be broken)- ![grey](https://user-images.githubusercontent.com/33173449/82437194-b24ba180-9a9f-11ea-820a-f68157271117.PNG)

- The levels-
  - Level 1- A simple introduction to the game. Regular purple bricks you need to break:
  ![level1](https://user-images.githubusercontent.com/33173449/82444227-95b56680-9aab-11ea-8b9d-7cf2746eb092.PNG)
  - Level 2- Added the green bricks which takes two hits to break. We also added more bricks and the level layout is a bit more difficult:
  ![level2](https://user-images.githubusercontent.com/33173449/82444393-d4e3b780-9aab-11ea-95df-b13d27b1550c.PNG)
  - Level 3- Added grey bricks which doesnt break at all with difficult brick placement, and also larger number of bricks to break:
  ![level3](https://user-images.githubusercontent.com/33173449/82444480-ffce0b80-9aab-11ea-9bdf-327e7f13f50d.PNG)



## The Code:
- The Paddle: We added to it the [moving ability](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Paddle.cs#L24-L25). And [freeze](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Paddle.cs#L19-L22) when the game is over or when we upload the next level.

- The Ball: 
  - We added the "Bouncy" built in script to make the bounce physics work when the ball hits the wall, the bricks and the paddle.
  - When the ball falls to the bottom of the screen we [restart](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L49-L58) it by putting it on the paddle and taking a life.
   - When the ball hits a brick it makes a jumping sound. And if the brick breaks then it triggers the explosion prefab we created using the "Particle Effect" in Unity and adjusted it to our game. And to disable the over creation of explosion objects during the game we [destroy](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L77) the exploasion object after a few seconds. Moreover we [update](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L90) the score for every brick hit (except for the gray brick).

- The Game
  - Game Over- If the player runs out of lives- the game ends and a panel shows asking if he wants to play again or quit. Pressing play again will lead him to the [beggining of the current level](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L89-L97) with 3 new lives and -10 points in the score, and Quit will return to the main menu.
  - Next Level- When all of the [bricks are cleared](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L59-L76) we [load the next level](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L78-L86) (all of the levels are stored as prefabs in an array so we don't need to switch scenes for every level).
  - Game Won- when we reach the [last level](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L62-L67) in our array, and all the bricks are cleared  then the ["Game Won" panel](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L103-L107) is shown with the possibility to [Play Again](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L109-L119)- from the first level, or [Quit](https://github.com/EladMotzny/unity-homework-8/blob/3528f13bc67727aa60f8b78edd379de05d4988f4/Brick%20Breaker/Assets/Scripts/GameManager.cs#L121-L124) and go the the main menu.
  
  
