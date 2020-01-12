using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour
{

    public static GameControl control;

    // ~~ ** //DECLARE VARIABLES HERE // ~~ ** //
    public static int highScoreSurvival = 0;
    public static int highScoreEndless = 0;

    public static bool lightMode = true;
    public static int gameMode = 1;
    public static int timesPlayedSurvival = 0;

    // Achievements
    //Survival mode
    public static bool untainted = false; // 10 points without damage
    public static bool pure = false;      // 25 points without damage
    public static bool sacred = false;    // 50 points without damage

    public static bool hungry = false;    // played survival mode 10 times
    public static bool famished = false;  // played survival mode 50 times
    public static bool ravenous = false;  // played survival mode 100 times

    //Endless mode
    public static bool worshipped = false; // 50 points
    public static bool revered = false;   // 100 points
    public static bool exalted = false;   // 200 points 


    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
        Load();
    }

    private static void CreateSaveFile()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            File.Create(Application.persistentDataPath + "/playerInfo.dat");
        }
    }


    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        PlayerData data = new PlayerData();

        // ~~ ** //SAVE VARIABLES HERE // ~~ ** //
        data.highScoreSurvival = highScoreSurvival;
        data.lightMode = lightMode;
        data.gameMode = gameMode;
        data.timesPlayedSurvival = timesPlayedSurvival;

        data.untainted = untainted;
        data.pure = pure;
        data.sacred = sacred;

        data.hungry = hungry;
        data.famished = famished;
        data.ravenous = ravenous;

        data.worshipped = worshipped;
        data.revered = revered;
        data.exalted = exalted;

        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();


            // ~~ ** //LOAD VARIABLES HERE // ~~ ** //
            highScoreSurvival = data.highScoreSurvival;
            lightMode = data.lightMode;
            gameMode = data.gameMode;
            timesPlayedSurvival = data.timesPlayedSurvival;

            untainted = data.untainted;
            pure = data.pure;
            sacred = data.sacred;

            hungry = data.hungry;
            famished = data.famished;
            ravenous = data.ravenous;

            worshipped = data.worshipped;
            revered = data.revered;
            exalted = data.exalted;
        }
        else
        {
            CreateSaveFile();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    public bool getThemePreference()
    {
        return lightMode;
    }

    public void toggleThemePreference()
    {
        lightMode = !lightMode;
    }

    public int getGameMode()
    {
        return gameMode;
    }

    public void setGameMode(int newMode)
    {
        gameMode = newMode;
    }
}


[Serializable]
class PlayerData
{
    public int highScoreSurvival;
    public bool lightMode;
    public int gameMode;
    public int timesPlayedSurvival;

    // Achievements
    //Survival mode
    public bool untainted; 
    public bool pure;      
    public bool sacred;    

    public bool hungry;    
    public bool famished;  
    public bool ravenous;  

    //Endless mode
    public bool worshipped; 
    public bool revered;   
    public bool exalted;   

}
