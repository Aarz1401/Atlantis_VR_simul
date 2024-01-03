using UnityEngine;
using UnityEngine.SceneManagement;

public class Back_to_menu : MonoBehaviour
{
    public string mainMenuSceneName = "Main_Menu";

    // Update is called once per frame
    void Update()
    {
        // Check if buttons X and Y are pressed simultaneously on the left controller
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) &&
            OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch))
        {
            SwitchToMainMenu();
        }
    }

    // Function to switch to the Main Menu scene
    void SwitchToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}

