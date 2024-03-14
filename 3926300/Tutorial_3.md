# Tutorial 3
In this tutorial we are going to create a main menu, character selection screen. Create 2 character prefabs for the player to choose from which will be a "motorcycle" and a "taxi". We will also use "PlayerPrefs" to remember the player's character selection so that if the player presses "restart" or "retry" then the game will start over with the character that was selected last.
<br/><br/>
We will start by creating a scene called "MainMenu". You can do so by right-clicking in a empty spot in the "Project" settings. 
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/b13498ea-b78e-4cd2-83a0-202071c3c595)
<br/><br/>
And create another one called "CharacterSelectScene".
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/22fbf996-2eba-4964-93f1-c74ca60d5345)
<br/><br/>
Add the scenes to the "Build Settings".
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/b6e23d08-27bd-4e49-8337-294fe43605cf)
<br/><br/>
You can create the black background effect by going in the camera in the hierarchy and pressing Clear Flags and putting the option as "Solid Colour" and then changing the background color to black.
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/a5007b03-2a43-475b-88dc-a5bc2bb52d56)
<br/><br/>
For the Main Menu create a canvas and an empty game object inside it called "MainMenuUI".
<br/><br/>
Inside this empty game object we need 1 text UI for the title and 2 buttons, the play button will take the player to the character selection screen. And the quit button will quit the game.
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/b33a470b-b4f0-40c7-ba32-3c5f75fb177f)
<br/><br/>
Now, lets create a script called MainMenuUI and write this code.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/c323a583-083a-467d-aea5-09c6d70b2a55)
<br/><br/>
Attach the code to your empty game object called MainMenuUI in the canvas and drag and drop the references needed.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/b6b471d5-8dcf-408f-8df0-a3e17732838f)
<br/><br/>
Great, now thats all ready so we can move onto our character selection scene.
<br/><br/>
Create a canvas and create the game objects needed shown in the picture:
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/1a44fa44-b1f7-4e55-8e2c-62f76ef2a11f)
<br/><br/>
Now we can create our script for our character selection screen and call it "CharacterSelectSceneUI".

![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/d7b90a5e-2ad2-4dd5-8c1b-35520c40de04)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/485f85ba-7919-43a4-ba17-569ff222458b)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/8a89a276-82fe-424c-a4ed-6517e3759670)

And go back and attach this script to the empty game object we created that is called "CharacterSelectSceneUI"
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/4cd746aa-d40a-47be-9953-5dcca9108ef8)
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/345b95ac-d74e-430e-bcc0-a927e2a7c7c0)
<br/><br/>

It's finally time to do characters for our player. We will do one motorcycle and one taxi which the player will be able to choose from.
<br/><br/>
Start making both characters with cubes and spheres. Here is how I did mine:
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/948f7162-936e-4e83-866f-3c86a9a435f1)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/28cc409b-58ab-427b-9029-68f067bc0862)
<br/><br/>
And now disable both game objects like this:
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/c9d32323-115b-4db3-b153-a2f864ceacac)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/ced3ee7c-61fa-483f-96d7-26d29d24dd18)
<br/><br/>
And now we will have to go back to the game scene and add our characters.
Add inside our player in the hierarchy and then disable them
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/ad86bf94-92d0-47bf-bacc-a09606209603)
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/7eebbabc-e830-4d04-9ad6-786c9c1b035f)
<br/><br/>
And now create a script called "BikeActivator" and write this code:
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/845859e0-6898-4af8-a65e-ba79a2a45fe9)
<br/><br/>
Now attach the script to the player as seen and drag and drop our character prefabs in this order:
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/86ce38b0-20cc-42af-be39-132ce654a0a5)
<br/><br/>
Great now everything should be working, however the motorcycle that came with the asset is still there so we will just hide it by disabling it's mesh renderers.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/21fefab0-cf0f-4354-a2dd-82b0c6bfee5e)
<br/><br/>
After doing that to every mesh renderer, we will go back to main menu and try our code.
<br/><br/>
![image](https://github.com/cayaahmet/Ahmet_Caya_Programming_CourseWork/assets/125205290/709fa07d-d613-4b4f-9c9c-1bed2c81f11e)
<br/><br/>
And yes everything works with main menu and character selection screen working perfectly!
<br/><br/>
Tutorial 3 is finished so we can move onto tutorial 4!
