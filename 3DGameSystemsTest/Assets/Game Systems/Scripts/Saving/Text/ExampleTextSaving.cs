using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ExampleTextSaving : MonoBehaviour
{
    //input values for saving
    public string[] whatWeAreSaving;
    //display what we have loaded after we split a string
    public string[] showWhatWeAreSplitting;
    //put some of the values into an array
    public string[] showStringsLoaded;
    //some of the values into an int
    public int showIntLoaded;

    //path for saving and loading
    public string path = "Assets/Game Systems/Resources/Save/TextSaveFile.txt";

    //this works as well, but saves to %appdata%
    //string path = Application.persistentDataPath + "TextSaveFile.txt";
    void Write()
    {
        //true adds on
        //false replaces
        StreamWriter writer = new StreamWriter(path, false);

        //for everything  we are saving
        for (int i = 0; i < whatWeAreSaving.Length; i++)
        {
            //if its not the last piece of data
            if (i < whatWeAreSaving.Length - 1)
            {
                //when saving add a marker | to separate the data values
                writer.Write(whatWeAreSaving[i] + '|');
            }
            else //if we are at the last piece of data
            {
                //we dont need a marker | on the end
                writer.Write(whatWeAreSaving[i]);
            }
        }
        //this lets us stop the data stream aka stop the process of saving so stuff don't break
        writer.Close();
        //this is the only thing tied to Unity Editor
        AssetDatabase.ImportAsset(path);
        //this will update the inspector when the save file is selected and displaying in the inspector, or else it'll look like nothing is happening, leading to confusion and pain for no reason at all yet nothing is going wrong, hopefully
    }

    void Read()
    {
        StreamReader reader = new StreamReader(path);
        //temporarily store the loaded info
        string tempRead = reader.ReadLine();
        //splitting up the line at the marker | and putting each value into our array
        showWhatWeAreSplitting = tempRead.Split('|');
        //separate our last value is the goal of the following

        //set our string array to the size of our splitted data except the last piece of data, which will be an int
        showStringsLoaded = new string[showWhatWeAreSplitting.Length - 1];
        //assign the string values to our string array

        for (int i = 0; i < showStringsLoaded.Length; i++)
        {
            showStringsLoaded[i] = showWhatWeAreSplitting[i];
        }
        //assign and convert our int value
        showIntLoaded = int.Parse(showWhatWeAreSplitting[showWhatWeAreSplitting.Length - 1]);

        //stop the loading;
        reader.Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Read();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Write();
        }
    }
}
