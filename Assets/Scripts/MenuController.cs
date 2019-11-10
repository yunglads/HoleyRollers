using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button start;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        Button startBtn = start.GetComponent<Button>();
        Button exitBtn = exit.GetComponent<Button>();

        start.onClick.AddListener(StartGame);
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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exiting Game");
    }
}
