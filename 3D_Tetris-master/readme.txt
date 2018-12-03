# 3D_Tetris

### @Authors: Yahang Wu(Harry), Jingyi Liu(Jannie)

#### Game play video:

https://www.youtube.com/watch?v=uRgAz4eAYow&feature=youtu.be

#### What is it?

It is a 3D version Tetris. In memory of the classic tile-matching puzzle video game. 

Blocks are updated to three dimension and you need to fill in a whole plane to eliminate it. 

#### How to Use it?

Basically, it can be used both on PC and Tablet. So, it means it can be controlled by touchscreen or mouse/keyboard. Users can use both control methods at the same time as they wish.

Music and game difficulty can be adjusted in the Setting menu.  

How to play menu briefly tells you how to play the game.

###### Tablet Mode:

- Buttons are attached to the screen, in order to control the  blocks or access to game settings. Arrows are to control the horizontal movement of the cube. X, Y, Z rotation button will change the blocks rotation in x-axis, y-axis and z-axis respectively. 
- Accelerometer is used to accelerate the falling speed of the cube. To accelerate, you need to "throw" your tablet backward and downward (rotate your wrist in a high speed).
- Use one finger to adjust the camera view
- Use two fingers to zoom in/out
- A "back to origin" button is attached to the bottom legame play screen, in order to set the camera view to default

###### PC Mode:

- Arrows are used to control the horizontal movement
- 'A' is used to rotate on x-axis
- 'S' is used to rotate on y-axis
- 'D' is used to rotate on z-axis
- 'Space' is used to accelerate the falling speed of the blocks
- All on screen button can be clicked by mouse

#### Objects and Entities

###### MainScene

- A plane and eight sprites form the boarder of the game. The entities name is Border and Ground, which have hierarchy children. The plane entity, which is the child of Ground, is rendered with a modified Blind-Phong Shader with custom shadow maps. The color of the plane would change by time. Shadows would appear on the plane. 
- One directional light, eight point light and four spotlight provide the light effect and shadow effects. The material of the point light is attached to a custom glow Shader. The glow effect would also change by time by using the animation. All the point light is attached to a parent, the parent will rotate by y-axis. So that, the lighting effect would be more dynamic and more interesting. 
- A spawner is used to generate the spawner. Spawners are generated randomly using prefabs.  A Prefab Shader script is attached to the prefabs, in order to use Phong illumination model and custom shadow map. The Group.cs script is used to set the game rules and make transformations to the blocks.
- The main camera provides the view of game play, it has a parent object, which is called Camera. Camera is an empty gameobject. The function of it is to help to control the camera's position. 
- GamePlayButton is used to generate the on screen button. The BGM is used to store the game music. The PauseInterface is used to display the "Pause" on screen text.
- On the top right of the screen, shows the score, if user places 1 tetris cube down, user will gain 50 points. And if user manages to fill in a plane, user will gain 5000 points! since we acknowledged the difficulty of this game.   

###### MainMenu

- Start Menu, Quit Menu, How to Play Menu and Setting Menu are easy to distinguish by their names.
- BGM_Menu stores the BGM of the menu scene.

###### GameOver

- GameOver holds the text "Game Over !".
- GameOverFirework is attached with a particle system to generate visual effects. 

#### Graphics and Camera motion

###### Graphics

Generally, in the game, custom Blind-Phong illumination model, custom shadow map, custom glow shader, animation and particle system are being used to generate special lighting or shadow effects. 

The Blind-Phong illumination model is modified from the lab example. A custom shadow map is added to the shader. It is used in the PhongShader and the PlaneShader. The PlaneShader takes more light to generate shadows, and it takes two different color point lights to change its own color. So, as time goes by, the color of the plan will be changed. 

A custom glow shader (ItemGlow) is used to generate visual effect on the shape of the point light. It takes 4 inputs which are basic color, normal map, rim color and rim power. After combined with animation, it can achieve the shining effects.

A particle system is used in the GameOver scene. We want it to provide a "celebration" atmosphere, so that it would be more dramatic and makes more fun. 

We did not use UV textures, because we want the style of this game more like the famous and beautiful game "Monument Valley", and we kind of did it. 

###### Camera Motion

For the camera motion, it is separate into two parts. 

The first one is Zoom in/out. We used touch screen to detect the two fingers' positions and calculate the previous distance and current distance, and we generate the zooming rate by compare the two distance. We used the fieldOfView to achieve zoom in/out, and the camera itself is not moving. 

The second part is main camera revolution. Since we created a empty gameobject to be the parent of the main camera, we could control the parent to achieve the revolution of the main camera. Still, we used the touch sensor to get the original data.  We detect the single finger movement and calculated the moving distance in x-axis and y-axis and transform it to the Camera coordinate to rotate. The reason we chose to control the camera in a revolution mode is because we don't really need the camera to move every in the game world. The function of the camera is provide a better view about the blocks and the planes that player created. Since it is in 3D, player may need to look around the blocks, so that the blocks can fit the plane more perfectly. 

#### Acknowledge

Touch Control: https://docs.unity3d.com/ScriptReference/Input.GetTouch.html

Custom glow Shader: https://www.youtube.com/watch?v=WU_M9fLnd_Y&t=110s