using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerBinary : MonoBehaviour
{
    public static void SaveData(PlayerHandler player)
    {
        //reference to binary formatter
        BinaryFormatter formatter = new BinaryFormatter();

        //location to save (path)
        string path = Application.persistentDataPath + "/" + "Flower_Texture" + ".jpeg";

        //create/replace a file at the file path
        FileStream writeDataStream = new FileStream(path, FileMode.Create);

        //what data to write(save) to the file
        PlayerData data = new PlayerData(player);

        //write that data from the serialised byte stream (the data we have converted to bytes so we can save it to the file)
        formatter.Serialize(writeDataStream, data);

        //after we are done with the action so close the byte stream and finish writing
        writeDataStream.Close();
    }

    public static PlayerData LoadData(PlayerHandler player)
    {
        //location to save to (path)
        string path = Application.persistentDataPath + "/" + "Flower_Texture" + ".jpeg";

        //if we have a file at the path
        if (File.Exists(path))
        {
            //reference to our binary formatter
            BinaryFormatter formatter = new BinaryFormatter();

            //open the file at that file path
            FileStream readDataStream = new FileStream(path, FileMode.Open);

            //read(load) that data from the file and deserialise(turn back) the bytes in the stream
            PlayerData data = formatter.Deserialize(readDataStream) as PlayerData;

            //and we are done with the action so close the byte stream and finish reading
            readDataStream.Close();

            //send the usable data to that PlayerData script
            return data;
        }

        return null;
    }
}
