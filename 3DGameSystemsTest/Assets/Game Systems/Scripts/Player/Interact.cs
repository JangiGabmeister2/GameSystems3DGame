using UnityEngine;
using System.Collections;

[AddComponentMenu("Game Systems/RPG/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Variables
    //[Header("Player and Camera connection")]
    //create two gameobject variables one called player and the other mainCam
    #endregion
    #region Start
    //connect our player to the player variable via tag
    //connect our Camera to the mainCam variable via tag
    #endregion
    #region Update   
    //if our interact key is pressed
    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            Ray _ray; //creates a ray
            _ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)); //ray is shot out from the main camera's center of screen
            RaycastHit _hitInfo; //created ray hit info
            if (Physics.Raycast(_ray, out _hitInfo, 10)) //if ray hits something 10 metres infront of camera
            {

            }
            #region NPC tag
            if (_hitInfo.collider.tag == "NPC") //and that hits info is tagged NPC
            {
                //check if you have the script
                if (_hitInfo.collider.GetComponent<DialogueManager>())
                {
                    //show the dialogue UI
                    _hitInfo.collider.GetComponent<DialogueManager>().showDialogue = true;
                    //change game state
                    GameManager.GameManagerInstance.gameState = GameStates.MenuState;
                }
            }            
            #endregion
            #region Item
            if (_hitInfo.collider.CompareTag("Item")) //and that hits info is tagged Item
            {
                //Debug that we hit an Item     
                Debug.Log("That's an Item");
            }          
            #endregion
        }
    }
    #endregion
}






