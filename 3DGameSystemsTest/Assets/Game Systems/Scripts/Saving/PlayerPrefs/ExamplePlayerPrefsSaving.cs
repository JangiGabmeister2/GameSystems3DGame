using UnityEngine;

public class ExamplePlayerPrefsSaving : MonoBehaviour
{
    /* PlayerPrefs
     * Pros
     *          - Prebuilt
     *                  - Already has all the functions and functionality
     *                  - Easy to use
     *          - Saves a key (name) and a value (data) similar to a dictionary
     *          - Easy to edit
     *          
     * Cons
     *          - Not flexible (only saves float, int, and string)
     *          - Easy to edit
     *                  - Players can easily find files
     *                  - Players can mess with the file/s
     *          - WebPlayer has a PlayerPrefs Size limit 1MB
     *          
     * What is it good for??
     *          - User/Options/Settings
     */

    public string stringToSaveAndLoad;

    void Awake()
    {
        //searches for a matching string key(entry) name
        //returns true if key exists in the prefs
        if (PlayerPrefs.HasKey("Test String"))
        {
            //if there is a data called "Test String"
            Debug.Log("Data was found");
        }
        else
        {
            //if there isnt
            Debug.Log("No data was found");
        }
    }

    void Start()
    {
        //returns the value corresponding to key in the preference file if it exists
        stringToSaveAndLoad = PlayerPrefs.GetString("Test String", "Crisp Ratt");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //set = write = save
            //sets the value of the preference identified by key
            PlayerPrefs.SetString("Test String", stringToSaveAndLoad);

            PlayerPrefs.SetInt("Test Int", 1);
            PlayerPrefs.SetFloat("Test Float", 1f);

            //writes all modified preferences to disk
            PlayerPrefs.Save();
            //on default, unity writes prefs to disk on application quit, so whenever the game crashes or quits when it shouldn't, you might want to write playerprefs during 'checkpoints' and not during actual gameplay
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.DeleteKey("Test String");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //deletes all modified keys. Use with caution.
            PlayerPrefs.DeleteAll();
        }
    }
}
