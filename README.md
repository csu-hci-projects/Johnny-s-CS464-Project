# The Effects of Latency On Performance-Experience In Video Games

3 executables are provided, each play the game on their respecitve latency.
To play them simply open the folder of the application with the latency you would like to play and double click the Top-down buzzsaws file.
In order to alter the level of latency from the project files you must:
1. Open the project(Top-down boulders) in unity.
2. Open the playerMovement2D script.
3. Change the latency variable to the desired latency (defualt is 0, 80 and 160 are the other latencies being tested) in the Start method.
4. Go back to unity, go to window-> animation-> animator.
5. Select the player object.
6. Click one of the arrows between idle and Movement animations.
7. In the inspector open settings.
8. Change both the Transition Duration (s) and Transition Offset to the desired latency.
9. Repeat steps 6-8 for the other arrow. 
10. Build and run the game.

Please note that the art assets used in the game were obtained from the unity asset store for free. Credit for the assets goes to Ansimuz. The asset pack used is called: Tiny RPG - Forest.
