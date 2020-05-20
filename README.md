# Brick Break

## Introduction and Instruction:
This game is the well known classic Brick Bracker which was developed for the Game Development course.

- The paddle- ![paddle](https://user-images.githubusercontent.com/33619352/82352691-ff2f6980-9a06-11ea-949b-0be949c8dcc7.JPG)
Can move using the left and right arrows, and can not cross the game walls. (Closed world)


- The ball- ![ball](https://user-images.githubusercontent.com/33619352/82353253-d5c30d80-9a07-11ea-93b3-e7a9d40eaa78.JPG)
Launch it using space every beggining of a level or when a life lost.
The ball has a unity built in physics "Bouncy" which calculates how to bounce the ball each time it collides with a wall, a brick or the paddle.

- The bricks-
  - Purple brick- ![purpleBrick](https://user-images.githubusercontent.com/33619352/82357949-79afb780-9a0e-11ea-850f-98a6951218ba.JPG)



## The Code:
- The Paddle: We added to it the [moving ability](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Paddle.cs#L24-L25). And [freeze](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Paddle.cs#L19-L22) when the game is over or we proceed to the next level.

- The Ball: 
  - We added the "Bouncy" built in script to make the bounce physics logical when the ball hits the wall, bricks and the paddle.
  - When the ball falls to the bottom of the screen we [restart](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L49-L58) it by putting it on the paddle and taking a life.
    -When the ball hits any brick it makes a jumping sound. And if the brick breaks then it triggers the explosion prefab we created using the "Particle Effect" in Unity and adjusted it to our game. And to deny the over creation of explosion prefabs during the game we [destroy](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L77) the object after a few seconds. Moreover we [update](https://github.com/EladMotzny/unity-homework-8/blob/b01c0ece711d050e7e927ca2bf93a37b6a34ba1e/Brick%20Breaker/Assets/Scripts/Ball.cs#L90) the score for every brick hit (except for the gray brick)

