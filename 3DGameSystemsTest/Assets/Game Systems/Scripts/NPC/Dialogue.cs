using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/RPG/NPC/Dialogue")]
public class Dialogue : MonoBehaviour
{
    #region Variables
    [Header("References")]
    //boolean to toggle if we can see a characters dialogue box
    bool isDialogueOpen = false;
    //index for our current line of dialogu and an index for a set question marker of the dialogue 
    //object reference to the player
    //mouselook script reference for the maincamera
    //[Header("NPC Name and Dialogue")]
    //name of this specific NPC
    //array for text for our dialogue
    #endregion
    #region Start
    private void Start()
    {
        
    }
    //find and reference the player object by tag
    //find and reference the maincamera by tag and get the mouse look component 
    #endregion
    #region OnGUI
    //if our dialogue can be seen on screen
    //set up our ratio messurements for 16:9
    //the dialogue box takes up the whole bottom 3rd of the screen and displays the NPC's name and current dialogue line
    //if not at the end of the dialogue or not at the options part
    //next button allows us to skip forward to the next line of dialogue
    //else if we are at options
    //Accept button allows us to skip forward to the next line of dialogue
    //Decline button skips us to the end of the characters dialogue 
    //else we are at the end
    //the Bye button allows up to end our dialogue
    //close the dialogue box
    //set index back to 0 
    //allow cameras mouselook to be turned back on
    //get the component mouselook on the character and turn that back on
    //get the component movement on the character and turn that back on
    //lock the mouse cursor
    //set the cursor to being invisible
    #endregion
}
