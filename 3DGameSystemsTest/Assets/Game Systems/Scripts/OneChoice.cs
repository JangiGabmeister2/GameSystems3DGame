using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneChoice : DialogueManager
{
    [Header("Choice Marker")]
    public int choiceIndex;

    private void OnGUI()
    {
        //if our dialogue can be seen on screen
        if (showDialogue)
        {
            //then dialogue box takes up the whole bottom 3rd of the screen
            //this box also shows NPC name and current line of dialogue
            GUI.Box(new Rect(0, 6 * UI_Manager.screen.y, Screen.width, 3 * UI_Manager.screen.y), $"{charName}: {dialogueText[index]}");

            //if we are not yet at the end of the dialogue and we are not the choice index
            if (index < dialogueText.Length - 1 && index != choiceIndex)
            {
                //display a button that says next in the bottom right of the screen
                //if the button is pressed then...
                if (GUI.Button(new Rect(13.5f * UI_Manager.screen.x, 8.25f * UI_Manager.screen.y, 2.5f * UI_Manager.screen.x, 0.75f * UI_Manager.screen.y), "Next"))
                {
                    //increases index by 1
                    index++;
                }
            }
            //if we ARE the choice
            else if (index == choiceIndex)
            {
                //if yes
                if (GUI.Button(new Rect(11f * UI_Manager.screen.x, 8.25f * UI_Manager.screen.y, 2.5f * UI_Manager.screen.x, 0.75f * UI_Manager.screen.y), "Yes"))
                {
                    index++;
                    EndDialogue();
                }
                //if no
                if (GUI.Button(new Rect(13.5f * UI_Manager.screen.x, 8.25f * UI_Manager.screen.y, 2.5f * UI_Manager.screen.x, 0.75f * UI_Manager.screen.y), "No"))
                {
                    //index is 2nd to last line of dialogue
                    index = dialogueText.Length - 1;
                    EndDialogue();
                }
            }
            //else we on the last line of dialogue
            else
            {
                //display 'bye' button where next was and if triggered...
                if (GUI.Button(new Rect(13.5f * UI_Manager.screen.x, 8.25f * UI_Manager.screen.y, 2.5f * UI_Manager.screen.x, 0.75f * UI_Manager.screen.y), "Bye"))
                {
                    //run parent end dialogue code
                    EndDialogue();
                }
            }
        }
    }
}
