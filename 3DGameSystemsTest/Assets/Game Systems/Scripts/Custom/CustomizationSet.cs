using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizationSet : MonoBehaviour
{
    #region Variables
    //name of our character
    public string characterName;
    //Texture2D List for skin mouth eyes hair clothes armour
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    //current index value of above textures
    public int skinIndex, mouthIndex, eyesIndex, hairIndex, clothesIndex, armourIndex;
    //character mesh renderer - this is so we can edit the materials
    public SkinnedMeshRenderer character;
    //max amount of textures (this is so we can load from resources)
    public int skinMax, mouthMax, eyesMax, hairMax, clothesMax, armourMax;
    //array of material/texture names
    public string[] materialNames = new string[6] { "Skin", "Mouth", "Eyes", "Hair", "Clothes", "Armour" };

    //bool for race dropdown
    public bool raceDrop;
    //dropdown race display
    public string raceDropDisplay = "Select Race";
    //bool for class dropdown
    public bool classDrop;
    //dropdown class display
    public string classDropDisplay = "Select Class";
    //Vector2 for both the scroll spaces of the dropdowns race and class
    public Vector2 scrollPosRace, scrollPosClass;
    //bonus stat points to be able to add - 6
    public int bonusStatPoints = 6;
    //array of attribute names eg health
    public string[] attributeName = new string[3] { "Health", "Mana", "Stamina" };
    //array of stat name - DnD style
    public string[] statName = new string[6] { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };
    #endregion
    #region Start/Setup
    private void Start()
    {
        #region Pulling textures from resources
        for (int i = 0; i < skinMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Skin_{i}") as Texture2D;
            skin.Add(temp);
        }

        for (int i = 0; i < eyesMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Eyes_{i}") as Texture2D;
            eyes.Add(temp);
        }

        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Hair_{i}") as Texture2D;
            hair.Add(temp);
        }

        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Armour_{i}") as Texture2D;
            armour.Add(temp);
        }

        for (int i = 0; i < mouthMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Mouth_{i}") as Texture2D;
            mouth.Add(temp);
        }

        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load($"Character/Clothes_{i}") as Texture2D;
            clothes.Add(temp);
        }
        #endregion
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        #region After setting textures
        SetTexture("Skin", 0);
        SetTexture("Mouth", 0);
        SetTexture("Eyes", 0);
        SetTexture("Hair", 0);
        SetTexture("Clothes", 0);
        SetTexture("Armour", 0);
        #endregion
    }
    #endregion
    #region Set Texture Behaviour
    public void SetTexture(string type, int direction)
    {
        int index = 0, max = 0, matIndex = 0;
        SkinnedMeshRenderer curRend = new SkinnedMeshRenderer();
        Texture2D[] textures = new Texture2D[0];
        #region Switch Material
        switch (type)
        {
            #region Skin
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                curRend = character;
                break;
            #endregion
            #region Mouth
            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 2;
                curRend = character;
                break;
            #endregion
            #region Eyes
            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 3;
                curRend = character;
                break;
            #endregion
            #region Hair
            case "Hair":
                index = hairIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                curRend = character;
                break;
            #endregion
            #region Clothes
            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                curRend = character;
                break;
            #endregion
            #region Armour
            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                curRend = character;
                break;
                #endregion
        }
        #endregion
        #region Assign Direction
        index += direction;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }

        Material[] mats = curRend.materials;
        mats[matIndex].mainTexture = textures[index];
        curRend.materials = mats;
        #endregion
        #region Switch Set Material to Model
        switch (type)
        {
            #region Skin
            case "Skin":
                skinIndex = index;
                break;
            #endregion
            #region Mouth
            case "Mouth":
                mouthIndex = index;
                break;
            #endregion
            #region Eyes
            case "Eyes":
                eyesIndex = index;
                break;
            #endregion
            #region Hair
            case "Hair":
                hairIndex = index;
                break;
            #endregion
            #region Clothes
            case "Clothes":
                clothesIndex = index;
                break;
            #endregion
            #region Armour
            case "Armour":
                armourIndex = index;
                break;
                #endregion
        }
        #endregion
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SetTexture("Clothes", 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SetTexture("Clothes", -1);
        }
    }
}
