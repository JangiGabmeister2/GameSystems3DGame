using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool showDialogue;   //if UI of dialogue is shown
    public string charName;     //name of character we are talking to
    public string[] dialogueText; //text shown in dialogue
    public int index;           //which line of dialogue is shown/selected in array of text

    public void EndDialogue()
    {        
        showDialogue = false;
        //hides dialogue
        index = 0;
        //resets conversation to beginning
        GameManager.GameManagerInstance.gameState = GameStates.GameState;
        //player can now move and look around
    }
}
