using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCounter : MonoBehaviour
{
    public Image t1grayStar1;
    public Image t1grayStar2;
    public Image t1grayStar3;
    public Image t2grayStar1;
    public Image t2grayStar2;
    public Image t2grayStar3;

    public Image t1yellowStar1;
    public Image t1yellowStar2;
    public Image t1yellowStar3;
    public Image t2yellowStar1;
    public Image t2yellowStar2;
    public Image t2yellowStar3;

    // Start is called before the first frame update
    void Start()
    {
        t1grayStar1.enabled = true;
        t1grayStar2.enabled = true;
        t1grayStar3.enabled = true;
        t2grayStar1.enabled = true;
        t2grayStar2.enabled = true;
        t2grayStar3.enabled = true;

        t1yellowStar1.enabled = false;
        t1yellowStar2.enabled = false;
        t1yellowStar3.enabled = false;
        t2yellowStar1.enabled = false;
        t2yellowStar2.enabled = false;
        t2yellowStar3.enabled = false;

        if (StarController.controller.track1Set == 1)
        {
            t1grayStar1.enabled = false;
            t1yellowStar1.enabled = true;
        }

        if (StarController.controller.track1Set == 2)
        {
            t1grayStar1.enabled = false;
            t1yellowStar1.enabled = true;
            t1grayStar2.enabled = false;
            t1yellowStar2.enabled = true;
        }

        if (StarController.controller.track1Set == 3)
        {
            t1grayStar1.enabled = false;
            t1yellowStar1.enabled = true;
            t1grayStar2.enabled = false;
            t1yellowStar2.enabled = true;
            t1grayStar3.enabled = false;
            t1yellowStar3.enabled = true;
        }

        if (StarController.controller.track2Set == 1)
        {
            t2grayStar1.enabled = false;
            t2yellowStar1.enabled = true;
        }

        if (StarController.controller.track2Set == 2)
        {
            t2grayStar1.enabled = false;
            t2yellowStar1.enabled = true;
            t2grayStar2.enabled = false;
            t2yellowStar2.enabled = true;
        }

        if (StarController.controller.track2Set == 3)
        {
            t2grayStar1.enabled = false;
            t2yellowStar1.enabled = true;
            t2grayStar2.enabled = false;
            t2yellowStar2.enabled = true;
            t2grayStar3.enabled = false;
            t2yellowStar3.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
