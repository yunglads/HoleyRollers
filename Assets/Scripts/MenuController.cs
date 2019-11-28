using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button track1;
    public Button track2;
    public Button exit;
    public Button trackSel;
    public Button mainMenu;
    public Button reset;

    //public GameObject starController;

    // Start is called before the first frame update
    void Start()
    {
        Button track1Btn = track1.GetComponent<Button>();
        Button track2Btn = track2.GetComponent<Button>();
        Button exitBtn = exit.GetComponent<Button>();
        Button trackSelBtn = trackSel.GetComponent<Button>();
        Button mainMenuBtn = mainMenu.GetComponent<Button>();
        Button resetBtn = reset.GetComponent<Button>();

        track1.onClick.AddListener(Track1);
        track2.onClick.AddListener(Track2);
        mainMenu.onClick.AddListener(MainMenu);
        trackSel.onClick.AddListener(TrackSelect);
        exit.onClick.AddListener(QuitGame);
        reset.onClick.AddListener(Delete);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Track1()
    {
        SceneManager.LoadScene("Game");
    }

    public void Track2()
    {
        SceneManager.LoadScene("Track 2");
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

    public void Delete()
    {
        StarController.controller.Delete();
    }
}
