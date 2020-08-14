using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyScript : MonoBehaviour
{
    void positionSet(Vector3 positionBodyPart)
    {
        try
        {
            GameObject.Find("Body" + ((int)positionBodyPart.z)).SendMessage("positionSet", new Vector3(transform.position.x + 9.5f, 3.5f - transform.position.y, positionBodyPart.z + 1));
        }
        catch (Exception e)
        {
        }
        transform.position = new Vector3(-9.5f + positionBodyPart.x, 3.5f - positionBodyPart.y, 0);
    }

    void fruitEaten(int lenght)
    {
        GameObject temp = Instantiate(this.gameObject);
        temp.name = "Body" + (lenght+1);
    }
}
