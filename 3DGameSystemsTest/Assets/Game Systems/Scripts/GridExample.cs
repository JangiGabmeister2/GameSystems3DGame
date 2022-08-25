using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridExample : MonoBehaviour
{
    private void OnGUI()
    {
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 9; y++)
            {
                GUI.Box(new Rect(x * UI_Manager.screen.x, y * UI_Manager.screen.y, UI_Manager.screen.x, UI_Manager.screen.y), "");
            }
        }
    }
}
