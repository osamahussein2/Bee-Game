using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit the application
            Application.Quit(); //End game on key press for testing.
        }
    }
}
