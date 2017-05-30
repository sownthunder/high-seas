using UnityEngine;
using System.Collections;

public class CaptainsQuarters : MonoBehaviour {

    public bool isShowing = false;

    // GAMEOBJECT VARIABLES
    //////////////////////////

    // GameObject variable that will hold the 'GameManagarr' after this script/class is loaded into the game
    public GameObject theGameControllerObj;

    // SCRIPT VARIABLES
    ///////////////////////////

    // the Game Managarr, the class that theoritically controls the entire game
    GameManagarr theGameController;

    //////////////////////////////////////////////////////////////////////////////////////////////// 
    // Use this for pre-intialization
    void Awake()
    {



    }

	// Use this for initialization
	void Start()
    {


	
	}
	
	// Update is called once per frame
	void Update()
    {


	
	}

    // Use this for Graphical User Interface
    void OnGUI()
    {

        if (isShowing)
        {

            // 'BackGround' for the Captains Quarters GUI
            GUI.Box(new Rect(((Screen.width / 2) + 200), 50, (Screen.width - 60), (Screen.height - 100)), "");

            // GUI Box that acts as the title/label display within the Captains Quarters GUI box 
            // (will be at top to help player knwo they are there)
            GUI.Box(new Rect(30, 50, (Screen.width - 60), 25), "CAPTAINS QUARTERS:");

        }
        else
        {



        }

    }

}
