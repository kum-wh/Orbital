# CP2106 Independent Software Development Project (Orbital)

## Description
Orbital is a summer vacation module I enrolled in Year 1 where I gain experience in a chosen computing technologies. The project was done in pairs of two, where me and my project mate propose, design, and implement the project.
The project is a 2D top down shooter game created using Unity Game Engine and coded in C#. The graphics and animation assets were taken from online sources.

## Gameplay
Gameplay follows that of a usual top down shooter where the player has to shoot all the enemies in the level.
The map design at each level will allow players the freedom to explore the different chambers.
General gameplay involves controlling an object with simple motions using WASD on the keyboard and using the mouse to aim. 
Left clicking on the mouse will allow the object controlled to fire a bullet that will destroy the enemies while right clicking will change the type of bullet fired. The game can be paused with the Esc key.

## Software Engineering
This section depicts the software engineering practices used in the game. Object collision
and physics of game objects are handled by Unity. Scripts were included in objects that
require additional functions, such as the player movement.

### Object Pooling
There are 3 primary methods of shootings being used commonly in games,namely ray tracing, using the physics engine on the bullet game object and moving the bullet game
object in a vector direction manually. Ray Tracing was deemed unsuitable for our game and the other 2 methods were used on the 2 different bullet types. One of the bullets will be
instantiated if the left mouse button is clicked and destroyed after a certain. The movement of this bullet is done by applying a force on it using the physics engine in unity. The other
bullet is instantiated at the start of the scene and is set as inactive. It turns active on left mouse click and moves in the vector direction of the mouse position from the player position.
Object pooling reduces the processing needed when a large amount of a certain object is needed to be instantiated and destroyed continuously.

### Hitbox
As with shooting, there are 2 methods to damage game objects. One method is to check the distance between the 2 gameobject every frame and damage the gameobject is the distance is close to zero.
However, this method requires a lot of processing every frame. Instead, we use the object collision built into Unity, that is called only when the 2 game objects collide.

### Singleton Pattern
Singleton pattern is used for the implementation of game managers that contains variables that are needed to be used across the whole scene.
The singleton script manages the audio in the game.
Having only one instance of the audio manager ensures that the volume of the music remains constant between scenes and audio is not cut off during transition across scenes. 
The script also contains the necessary global variables such as the difficulty of the game.

## Usage
Download the Bulids folder and run the file 'Game.exe'.
