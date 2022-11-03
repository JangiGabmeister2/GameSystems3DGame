using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    public static PlayerHandler player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHandler>();
    }

    public void Save()
    {
        PlayerBinary.SaveData(player);
    }

    public void Load()
    {
        player.gameObject.GetComponent<CharacterController>().enabled = false;
        PlayerData data = PlayerBinary.LoadData(player);
        player.name = data.characterName;
        player.transform.position = new Vector3(data.position.x, data.position.y, data.position.z);
        player.transform.rotation = new Quaternion(data.rotation.x, data.rotation.y, data.rotation.z, data.rotation.w);
        player.gameObject.GetComponent<CharacterController>().enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Load();
        }
    }
}
