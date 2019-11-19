using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button start;
    public Button exit;
    public Button trackSel;
    public Button mainMenu;

    //public GameObject starController;

    // Start is called before the first frame update
    void Start()
    {
        Button startBtn = start.GetComponent<Button>();
        Button exitBtn = exit.GetComponent<Button>();
        Button trackSelBtn = trackSel.GetComponent<Button>();
        Button mainMenuBtn = mainMenu.GetComponent<Button>();

        start.onClick.AddListener(StartGame);
        mainMenu.onClick.AddListener(MainMenu);
        trackSel.onClick.AddListener(TrackSelect);
        exit.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void TrackSelect()
    {
        SceneManager.LoadScene("Track Selection");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}
