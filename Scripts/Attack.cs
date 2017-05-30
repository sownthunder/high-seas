using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    // TYPES OF WEAPONS TO REMEMBER:

    // MELEE: Sword, Axe, Spear

    // RANGED: Bow, Bowstaff, Crossbow

    // MAGIC: Voodoo Doll, Magi Beads, Shanty Scroll (sings?)

    // COLLIDER VARIABLES
    ////////////////////////

    // GameObject variable that starts off null but is filled/stored with the GameObject that Pirate Player is "holding"
    // --- and by HOLDING, that means that the GameObject is a CHILD to this GameObject, and if not it will be set that way
    public GameObject playerWeapon;

    // the Pirate Player's hand that will "hold" whatever weapon they are holding, ie a sword or bowstaff
    public GameObject theHand; 

    // Use this for pre-initialization
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



    }

}
