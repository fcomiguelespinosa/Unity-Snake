using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    private Animator anim;
    private bool nextScreen;
    // Start is called before the first frame update
    void Start() 
    { 
        nextScreen = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("return") && !nextScreen)
        {
            nextScreen = true;
            anim.SetTrigger("Transition");
        }
    }
}
