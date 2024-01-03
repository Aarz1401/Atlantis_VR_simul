using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour{
 
    public GameObject mainmenu;
    //One function for each of the options
  
    //At game start,Scene main menu is loaded , presents user with following options:
    public void StartGame()
    {
      
        SceneManager.LoadScene("Main_Menu");
    }
    public void QuitGame()
    {
       Application.Quit();
    }
    public void BackToMenu()
    {
        //Takes an input from the controller from update function , and then switches scene back to the menu
        //When user presses X and A together
        
        SceneManager.LoadScene("Main_Menu");


    }
    public void ExploreMuseum()
    {  
      // switches scene to the interior of the museum
        SceneManager.LoadScene("Museum Loading scene");

    }
    public void SwimWithDolphins()
    {
        SceneManager.LoadScene("Template");
        //Loads Swim with Doplphins scene
        
    }
    public void Freeroam()
    {
        SceneManager.LoadScene("FreeRoam");//No dolphins ,Player in a different position, rest all is same
       // Loads Freeroam


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       


        
    }
}
