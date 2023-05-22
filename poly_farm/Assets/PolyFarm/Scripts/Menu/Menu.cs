using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
   
    bool menuOpen;

    private void Awake()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (menuOpen)
            {
                menuOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                menu.SetActive(false);
            }
            else
            {
                menuOpen = true;
                Cursor.lockState = CursorLockMode.Confined;
                menu.SetActive(true);
            }
        }
    }
}
