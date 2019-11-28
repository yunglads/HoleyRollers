using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class StarController : MonoBehaviour
{
    public static StarController controller;

    public WinCondition winCondition;

    public int track1Stars;
    public int track1Set;
    public int track2Stars;
    public int track2Set;
    public int totalStars;
    public Text starText;
    //public float time;

    public void Awake()
    {

        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (winCondition == null && GetComponent<WinCondition>() != null)
        {
            winCondition = GetComponent<WinCondition>();
        }

        //track1Set = 0;
        //track2Set = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //time = winCondition.seconds;
        starText = GameObject.Find("Star Text").GetComponent<Text>();
        winCondition = GameObject.FindObjectOfType<WinCondition>();

        totalStars = track1Set + track2Set;

        if (totalStars == 0)
        {
            starText.enabled = false;
        }
        else if (totalStars >= 1)
        {
            starText.enabled = true;
            starText.text = "Stars: " + totalStars;
        }

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Game")
        {
            if (winCondition.seconds >= 32f)
            {
                track1Stars = 1;
            }

            else if (winCondition.seconds <= 32f && winCondition.seconds >= 27f)
            {
                track1Stars = 2;
            }

            else if (winCondition.seconds <= 27f)
            {
                track1Stars = 3;
            }

            if (winCondition.raceOver == true && track1Set < track1Stars)
            {
                track1Set = track1Stars;
            }
        }

        if (sceneName == "Track 2")
        {
            if (winCondition.seconds >= 32f)
            {
                track2Stars = 1;
            }

            else if (winCondition.seconds <= 32f && winCondition.seconds >= 27f)
            {
                track2Stars = 2;
            }

            else if (winCondition.seconds <= 27f)
            {
                track2Stars = 3;
            }

            if (winCondition.raceOver == true && track2Set < track2Stars)
            {
                track2Set = track2Stars;
            }
        }
    }

    public void OnDisable()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData data = new PlayerData();
        data.track1Stars = track1Stars;
        data.track1Set = track1Set;
        data.track2Stars = track2Stars;
        data.track2Set = track2Set;
        data.totalStars = totalStars;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Data Saved");
    }

    public void OnEnable() 
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            track1Stars = data.track1Stars;
            track1Set = data.track1Set;
            track2Stars = data.track2Stars;
            track2Set = data.track2Set;
            totalStars = data.totalStars;
            Debug.Log("Data Loaded");
        }
    }

    public void Delete()
    {
        track1Set = 0;
        track1Stars = 0;
        track2Set = 0;
        track2Stars = 0;
    }
}

[Serializable]
class PlayerData
{
    public int track1Stars;
    public int track1Set;
    public int track2Stars;
    public int track2Set;
    public int totalStars;
}
