using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    //ref to our screens x and y divided byt our aspect ratio
    public static Vector2 screen;
    //singleton
    private static UI_Manager _uiManagerInstance;
    public static UI_Manager uiManagerInstance
    {
        //see, read, look at
        get { return _uiManagerInstance; }
        //change, write, print
        private set
        {
            if (_uiManagerInstance == null)
            {
                //set our ref to this instance
                _uiManagerInstance = value;
            }
            //else if instance is not the same instance as the value
            else if (_uiManagerInstance != value)
            {
                Debug.Log($"{nameof(UI_Manager)} instance already exists. Destroy the duplicate. [insert Highlander quote]");
                Destroy(value);
            }
        }
    }

    public void UpdateUIScale()
    {
        if (new Vector2(Screen.width / 16, Screen.height / 9) != screen)
        {
            screen.x = Screen.width / 16;
            screen.y = Screen.height / 9;
        }
    }

    private void Awake()
    {
        uiManagerInstance = this;
    }

    void Start()
    {
        //set up screen size
        UpdateUIScale();
    }

    void Update()
    {
        //set up screen size
        UpdateUIScale();
    }
}
