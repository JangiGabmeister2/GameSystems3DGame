using System;

[Serializable] //converts the data to make it readable to UNITY

public class PlayerData
{
    public string characterName;

    [Serializable]

    public struct Position
    {
        public float x, y, z;
    }

    public Position position;

    public struct Rotation
    {
        public float x, y, z, w;
    }

    public Rotation rotation;

    public PlayerData(PlayerHandler player)
    {
        characterName = player.name;

        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        position.z = player.transform.position.z;

        rotation.x = player.transform.rotation.x;
        rotation.y = player.transform.rotation.y;
        rotation.z = player.transform.rotation.z;
        rotation.w = player.transform.rotation.w;
    }
}
