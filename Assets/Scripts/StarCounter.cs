using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    public Image grayStar1;
    public Image grayStar2;
    public Image grayStar3;

    public Image yellowStar1;
    public Image yellowStar2;
    public Image yellowStar3;

    // Start is called before the first frame update
    void Start()
    {
        grayStar1.enabled = true;
        grayStar2.enabled = true;
        grayStar3.enabled = true;

        yellowStar1.enabled = false;
        yellowStar2.enabled = false;
        yellowStar3.enabled = false;

        if (StarController.controller.stars == 1)
        {
            grayStar1.enabled = false;
            yellowStar1.enabled = true;
        }

        if (StarController.controller.stars == 2)
        {
            grayStar1.enabled = false;
            yellowStar1.enabled = true;
            grayStar2.enabled = false;
            yellowStar2.enabled = true;
        }

        if (StarController.controller.stars == 3)
        {
            grayStar1.enabled = false;
            yellowStar1.enabled = true;
            grayStar2.enabled = false;
            yellowStar2.enabled = true;
            grayStar3.enabled = false;
            yellowStar3.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
