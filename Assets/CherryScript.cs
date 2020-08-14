using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryScript : MonoBehaviour
{
    public GameObject cherry;

    private static GameObject cherryInstance;
    private int positionX;
    private int positionY;
    private System.Random randG;
    // Start is called before the first frame update
    void Start()
    {
        randG = new System.Random();
        cherryInstance = Instantiate(cherry);
        cherryInstance.name = "Cherry";
        cherryInstance.SetActive(false);
        newCherry();
    }

    void newCherry()
    {
        positionX = randG.Next(20);
        positionY = randG.Next(8);
        cherryInstance.transform.position = new Vector3(-9.5f + positionX, 3.5f - positionY, 0);
        cherryInstance.SetActive(true);
    }

    void stopCherryAnimation()
    {
        cherryInstance.GetComponent<Animator>().enabled = false;
    }
}
