using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityResolutionHandler : MonoBehaviour
{
    #region Quality
    public void Quality(int qualityIndex) //dropdown are arrays which have values, the value is this class's index
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    #endregion
    #region Resolution
    public Resolution[] resolutions;
    public Dropdown resDropDown;
    void ResSetUp()
    {
        resolutions = Screen.resolutions;
        resDropDown.ClearOptions();
        List<string> options = new List<string>(); //lists are arrays whose size can be altered during runtime
        int curResIndex = 0; //current index value for current resolution
        for (int i = 0; i < resolutions.Length; i++)
        {
            //formatting the string
            string option = resolutions[i].width + "x" + resolutions[i].height;
            //adding the string to our list
            options.Add(option);

            if (Screen.currentResolution.width == resolutions[i].width && Screen.currentResolution.height == resolutions[i].height)
            {
                curResIndex = i;
            }
        }
        //set the dropdown option list to the list of options
        resDropDown.AddOptions(options);
        //display current resolution to dropdown
        resDropDown.value = curResIndex;
        //refresh to make sure changes apply
        resDropDown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    #endregion
    #region Fullscreen
    public Toggle fullscreenToggle;
    public void SetFullscreen(bool isFullscren) //toggle ui is bool known as 'isOn'
    {
        Screen.fullScreen = isFullscren;
    }
    #endregion

    private void Start()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        ResSetUp();
    }
}
