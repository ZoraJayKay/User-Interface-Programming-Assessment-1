using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // If the user presses Esc, quit the program
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            Application.Quit();
        }
    }
}
