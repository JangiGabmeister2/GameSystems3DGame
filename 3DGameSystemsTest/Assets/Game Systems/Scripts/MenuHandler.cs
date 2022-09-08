using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public GameObject[] panels;

    public MenuStates menuState;

    public void Start()
    {
        ChangePanel(0);
    }
    public void Update()
    {
        if (menuState == MenuStates.AnyKey)
        {
            if (Input.anyKey)
            {
                ChangePanel(1);
            }
        }
    }

    public void ChangePanel(int value)
    {
        menuState = (MenuStates)value;

        switch (menuState)
        {
            case MenuStates.AnyKey:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false); //turns them all off
                }
                panels[0].SetActive(true); //then turns this one on again
                break;
            case MenuStates.MainMenu:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[1].SetActive(true);
                break;
            case MenuStates.Options:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[2].SetActive(true);
                break;
            default:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);
                menuState = MenuStates.AnyKey;
                break;
        }
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}

public enum MenuStates
{
    AnyKey,
    MainMenu,
    Options
}
