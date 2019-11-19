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

    public int stars;
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

        //stars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //time = winCondition.seconds;
        starText = GameObject.Find("Star Text").GetComponent<Text>();
        winCondition = GameObject.FindObjectOfType<WinCondition>();

        if (stars == 0)
        {
            starText.enabled = false;
        }
        else if (stars >= 1)
        {
            starText.enabled = true;
            starText.text = "Stars: " + stars;
        }

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Game")
        {
            if (winCondition.seconds >= 32f)
            {
                stars = 1;
            }

            else if (winCondition.seconds <= 32f && winCondition.seconds >= 27f)
            {
                stars = 2;
            }

            else if (winCondition.seconds <= 27f)
            {
                stars = 3;
            }
        }
    }

    public void OnDisable()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData data = new PlayerData();
        data.stars = stars;

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

            stars = data.stars;
            Debug.Log("Data Loaded");
        }
    }
}

[Serializable]
class PlayerData
{
    public int stars;
}
