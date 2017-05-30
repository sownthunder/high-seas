using UnityEngine;
using System.Collections;

public class AttackManagarr : MonoBehaviour {

    // RigidBody2D of the Pirate Player (the GameObject that this script is attached to)
    public Rigidbody2D rb2D;

    // holding in their hand as a weapon
    // ***** STARTS OFF FILLED WITH A PREFAB FOR TESTING PURPOSES *****
    public GameObject attackWeapon;             // PREFABICATED GAMEOBJECT

    /// *** TO BE FILLED/FIXED YOOO ***
    public GameObject meleeWeapon;

    // holding in their hand as a weapon
    // STARTS OFF FILLED WITH PREFAB OF RANGED BOW
    public GameObject rangedWeapon;

    // holindg in their hand as a weapon
    // STARTS OFF FILLED WITH PREFAB OF VOODOO MAGIC
    public GameObject voodooWeapon;

    public GameObject dragonSword;
    public GameObject goldSword;
    public GameObject pulgrimSword;

    // PUBLIC GAMEOBJECT that starts off null but is soon filled with LOCAL VARIABLE
    // (to help better access variables outside of its own function)
    public GameObject theAttackWeapon;

    public bool lerping = false;

    public bool reallyAttacking = false;

    // bool variables used to determine if and when to display sprites for the differenty types of weapons
    public bool displayMeleeWep = false;
    public bool displayRangedWep = false;
    public bool displayVoodooWep = false;

    // How many seconds it is currently / it will take to reset MELEE ATTACK
    public float meleeAttackTimer;
    public float meleeAttackCoolDown;

    // How many seconds it is currently / it will take to reset RANGED ATTACK
    public float rangedAttackTimer;
    public float rangedAttackCoolDown;

    // How many seconds it is currently / it will take to reset VODOO ATTACK
    public float voodooAttackTimer;
    public float voodooAttackCoolDown;

    // How many seconds it is currently / it will take to STOP DISPLAYING THE WEAPON (melee)
    public float displayMeleeWepTimer;
    public float displayMeleeWepCoolDown;

    // How many seconds it is currently / it will take to STOP DISPLAYING THE WEAPON (ranged)
    public float displayRangedWepTimer;
    public float displayRangedWepCoolDown;

    // How many seconds it is currently / it will take to STOP DISPLAYING THE WEAPON (voodoo)
    public float displayVoodooWepTimer;
    public float displayVoodooWepCoolDown;

    // bool variables used to determine what TYPE of weapon will be spawned/displayed based on Pirate Player
    public bool isMelee = false;
    public bool isRanged = false;
    public bool isVoodoo = false;

    ////////////////////////////////////////////////////
    // TYPES OF WEAPONS:                              //
    ////////////////////////////////////////////////////
    // MELEE: Sword, Axe, Spear                       //
    // RANGED: Bow, Bowstaff, Crosbow                 //
    // MAGIC: Voodoo Doll, Magi Beads, Shanty Scrolls //
    ////////////////////////////////////////////////////

    // GameObject that will be used to get and set GameManagarr Script
    public GameObject theGameManagarr;

    // "GameController" Script 
    public GameManagarr theGameController;

    // GameObject that will be used to get and set GameManagarr Script
    public GameObject theWeaponManagarr;

    // "Weapon Controller" Script
    public PirateWeaponManagarr theWeaponController;

    // Use this for pre-initialization
    void Awake()
    {

        // get and set rb2D variable (RigidBody2D)
        rb2D = GetComponent<Rigidbody2D>();

    }

	// Use this for initialization
	void Start() 
    {

        // get and set Game Mangarr GameObject
        theGameManagarr = GameObject.FindGameObjectWithTag("GameController");

        // get and set Game Controller Script
        theGameController = theGameManagarr.GetComponent<GameManagarr>();

        // if the name of the PREFABRICATED WEAPON is that of MELEE...
        if (attackWeapon)
        {

            // get and set the Pirate Weapon Controller through the 'attackWeapon' prefab object
            theWeaponController = attackWeapon.GetComponent<PirateWeaponManagarr>();

            if (attackWeapon.name == "testPirateWeapon" | attackWeapon.name == "pirateMeleeWeapon")
            {

                // set MELEE bool to true so we know what type of weapon he/she is using
                isMelee = true;

            }

        }
        // ELSE IF... the name of the PREFABRICATED WEAPON is that of RANGED...
        else if (rangedWeapon)
        {

            // get and set the Pirate Weapon Controller through the 'rangedWeapon' prefab object
            theWeaponController = rangedWeapon.GetComponent<PirateWeaponManagarr>();

            if (rangedWeapon.name == "pirateRangedWeapon")
            {

                // set RANGED bool to true so we know what type of weapon he/she is using
                isRanged = true;

            }

        }
        // ELSE IF... the name of the PREFABRICATED WEAPON is that of VOODOO...
        else if (voodooWeapon)
        {

            // get and set the Pirate Weapon Controller through the 'voodooWeapon' prefab object
            theWeaponController = voodooWeapon.GetComponent<PirateWeaponManagarr>();

            if (voodooWeapon.name == "pirateVoodooWeapon")
            {

                // set VOODOO bool to be true so we know what type of weapon he/she is using
                isVoodoo = true;
            
            }

        }

        // get and set our test Melee weapon
        //attackWeapon = GameObject.Find("MeleeWeapon");

        // find and assign the MELEE WEAPON to be the attack weapon (FOR NOW)
        //      attackWeapon = GameObject.Find("MeleeWeapon");

        // SET TRANSFORM ATTACHED TO THIS SCRIPT (PIRATE PLAYER) AS "PARENT" OF ATTACKWEAPON (m3l33 for now)
        //      attackWeapon.transform.parent = this.transform;

        // get and set Weapon Managarr GameObject
        //theWeaponManagarr = GameObject.FindGameObjectWithTag("WeaponController");

        // get and set Weapon Controller Script
        //theWeaponController = theWeaponManagarr.GetComponent<PirateWeaponManagarr>();
        
        // set the Weapon Managarr GameObject's parent to be the AttackManagar script's attached GameObject (Pirate Player)
        //theWeaponManagarr.transform.parent = this.transform;

        // Setup Attack Timers
        meleeAttackTimer = 0f;
        rangedAttackTimer = 0f;
        voodooAttackTimer = 0f;

        // Setup Display Timers (to display sprites)
        displayMeleeWepTimer = 0f;
        displayRangedWepTimer = 0f;
        displayVoodooWepTimer = 0f;

        // if we have a "standard" Swinging Melee speed...
        // we set the 'meleeSpeedCoolDown' to be 0.6 float (0.6 seconds?)
        meleeAttackCoolDown = 0.6f;

        // if we have a "standard" Firing Ranged speed...
        // we set the 'rangedSpeedCoolDown' to be 1.3 float (1.3 seconds?)
        rangedAttackCoolDown = 1.3f;

        // if we have a "standard" Magical Voodoo speed...
        // we set the 'vodooSpeedCoolDown' to be 3.3 float (3.3 seconds?)
        voodooAttackCoolDown = 3.3f;

        // this number determines how long a weapon will be "displayed" for when attacking (MELEE)
        displayMeleeWepCoolDown = 0.6f;

        // this number determines how long a weapon will be "displayed" for when attacking (RANGED)
        displayRangedWepCoolDown = 1.3f;

        // this number determines how long a weapon will be "displayed" for when attacking (VOODOO)
        displayVoodooWepCoolDown = 3.3f;

	}
	
	// Update is called once per frame
	void Update() 
    {

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (meleeAttackTimer > 0)
            meleeAttackTimer = meleeAttackTimer - Time.deltaTime;

        // Just in case the meleeAttackTimer ever goes below zero, it becomes zero
        if (meleeAttackTimer < 0)
            meleeAttackTimer = 0;

        ////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (rangedAttackTimer > 0)
            rangedAttackTimer = rangedAttackTimer - Time.deltaTime;

        // Just in case the rangedAttackTimer ever goes below zero, it becomes zero
        if (rangedAttackTimer < 0)
            rangedAttackTimer = 0;

        ////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (voodooAttackTimer > 0)
            voodooAttackTimer = voodooAttackTimer - Time.deltaTime;

        // Just in case the rangedAttackTimer ever goes below zero, it becomes zero
        if (voodooAttackTimer < 0)
            voodooAttackTimer = 0;

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // if we are FINALLY REALLY ATTACKING (because our AttackManagarr Script has finally been told so)
        if (reallyAttacking)
        {

            // If the meleeAttackTimer has finally reached zero after subtracting per second
            if (isMelee && meleeAttackTimer == 0)
            {

                // i guess im organizing now huh
                // PirateAttack();

                MeleeAttack();                              // m3l33 attack (FOR NOW)
                meleeAttackTimer = meleeAttackCoolDown;     // reset (rinse and repeat) (m3l33 FOR NOW)

                // set bool 'reallyAttacking' to false because we are DONE REALLY ATTACKING
                reallyAttacking = false;

            }
            // If the rangedAttackTimer has finally reached zero after subtracting per second
            else if (isRanged && rangedAttackTimer == 0)
            {

                // i guess im organizing now huh
                // PirateAttack();

                RangedAttack();                             // RANGED attack
                rangedAttackTimer = rangedAttackCoolDown;   // reset (rinse and repeat) (RANGED)

                // set bool 'reallyAttacking' to false because we are DONW REALLY ATTACKING
                reallyAttacking = false;

            }
            // If the voodooAttackTimer has finally reached zero after subtracting per second
            else if (isVoodoo && voodooAttackTimer == 0)
            {

                // i guess im organizing now huh
                // PirateAttack();

                VoodooAttack();                             // VOODOO attack
                voodooAttackTimer = voodooAttackCoolDown;   // reset (rinse and repeat) (VOODOO)

                // set bool 'reallyAttacking' to false because we are DOWN REALLY ATTACKING
                reallyAttacking = false;

            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (displayMeleeWepTimer > 0)
            displayMeleeWepTimer = displayMeleeWepTimer - Time.deltaTime;

        // Just in case the displayMeleeWepTimer ever goes below zero, it becomes zero
        if (displayMeleeWepTimer < 0)
            displayMeleeWepTimer = 0;

        // If the displayWeaponTimer (MELEE) has finally reach zero after subtracting per second
        if ((displayMeleeWepTimer == 0) && (displayMeleeWep))
        {

            // destroy 'theAttackWeapon' our GAMEOBJECT HOLDER variable because the timer has counted down and we no longr want it displayed
            Destroy(theAttackWeapon);

            displayMeleeWep = false;

        }

        ////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (displayRangedWepTimer > 0)
            displayRangedWepTimer = displayRangedWepTimer - Time.deltaTime;

        // Just in case the displayRangedWepTimer ever goes below zero, it becomes zero
        if (displayRangedWepTimer < 0)
            displayRangedWepTimer = 0;

        // If the displayWeaponTimer (RANGED) has finally reach zero after subtracting per second
        if ((displayRangedWepTimer == 0) && (displayRangedWep))
        {

            // destroy 'theAttackWeapon' our GAMEOBJECT HOLDER variable because the timer has counted down and we no longr want it displayed
            Destroy(theAttackWeapon);

            displayRangedWep = false;

        }

        ////////////////////////////////////////////////////////

        // As long as the Timer is greater than zero and not zero, we will subtract 1 per second (pretty much counting down)
        if (displayVoodooWepTimer > 0)
            displayVoodooWepTimer = displayVoodooWepTimer - Time.deltaTime;

        // Just in case the displayVoodooWepTimer ever goes below zero, it becomes zero
        if (displayVoodooWepTimer < 0)
            displayVoodooWepTimer = 0;

        // If the displayWeaponTimer (VOODOO) has finally reach zero after subtracting per second
        if ((displayVoodooWepTimer == 0) && (displayVoodooWep))
        {

            // destroy 'theAttackWeapon' our GAMEOBJECT HOLDER variable because the timer has counted down and we no longr want it displayed
            Destroy(theAttackWeapon);

            displayVoodooWep = false;

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (lerping)
        {

            // LERP-a-DERP this weapon?
            //theAttackWeapon.transform.position = Vector2.Lerp(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + 10), 5.0f * Time.fixedDeltaTime);

            lerping = false;

        }

	}

    // FixedUpdate is called once every Physics Frame
    public void FixedUpdate()
    {

        // if 'theAttackWeapon' is NOT NULL (theAttackWeapon != null)
        if (theAttackWeapon)    // AS LONG AS THIS GAMEOBJECT EXISTS IN THE WORLD...
        {

            //theAttackWeapon

            // set it so it constantly moves to try and stay at the same positon as the Pirate Player? 
            //theAttackWeapon.transform.position = this.transform.position;

            // set it so it constantly moves to try and stay +1 y intercept above the Pirate Player
            //theAttackWeapon.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
            // WHAT THE Y-INTERCEPT WAS PREVIOUSLY: this.transform.position.y + 1);

            // if theAttackWeapon is SPECIFICALLY a MELEE WEAPON (isMelee == true)
            if (isMelee)
            {

                Debug.Log("lunge ON GUARD YARGH");

                // create a local variable and set the position of the Pirate Player, CURRENTLY, to the newly created variable
                Vector2 piratePosition = new Vector2(this.transform.position.x, this.transform.position.y);

                //////////////////////////// LERP - A - DERP /////////////////////////////////////////////////////

                // create a local variable and set it to 2 UNITS ABOVE the CURRENT position of the Pirate Player
                Vector2 lungePositon = new Vector2(piratePosition.x, piratePosition.y + 1.25f);

                // "Lerp-A-Derp" the MELEE WEAPON so that it "lunges" 2 units above the Pirate Player
                // The time (float) is set to 0.6f because that is how long the MELEE COOLDOWN is
                theAttackWeapon.transform.position = Vector2.Lerp(piratePosition, lungePositon, 0.6f);

                // try and "smooth damp" the sword 
                //theAttackWeapon.gameObject.rigidbody2D = Vector2.SmoothDamp(piratePosition, lungePositon, rb2D.velocity, 0.6f);
                //theAttackWeapon.transform.position = Vector2.SmoothDamp(piratePosition, lungePositon, rb2D.velocity, 0.6f);

                //////////////////////////// LERP - A - DERP /////////////////////////////////////////////////////

            }

            // Vector2 variable that holds the position of the target that the Pirate Player's Weapon is going to attack towards 
            // <---- LOCAL VARIABLE ---->
            //Vector2 targetPosition = new Vector2(this.transform.position.x, this.transform.position.y + 10);

            // Debug.Log("LERP-a-DERP");

            // LERP-a-DERP this weapon?
            //theAttackWeapon.transform.position = Vector2.Lerp(this.transform.position, new Vector2(this.transform.position.x, this.transform.position.y + 10), 5.0f * Time.fixedDeltaTime);

            lerping = true;

            // debug and test the position of attacking Weapon
            Debug.Log(theAttackWeapon.transform.position);

        }

    }

    // the BIG FUNCTION YARRGH that does a lot of cool shit
    public void PirateAttack()
    {

        /////////////////////////////////////////////////////////////////////////////////////////
        // THIS WILL BE USED TO DETERMINE EXACTLY WHICH "TYPE" OF ATTACK THE PLAYER WILL DO    //
        // (BECAUSE DIFFERENT SHIT WILL HAPPEN DEPENDING ON WHICH WEAPON AND/OR SKILL IS USED) //
        /////////////////////////////////////////////////////////////////////////////////////////

        // if the ATTACHED WEAPON that the Pirate Player is holding/using is MELEE-based
        if (isMelee)
        {

            MeleeAttack();                              // m3l33 attack (FOR NOW)
            meleeAttackTimer = meleeAttackCoolDown;     // reset (rinse and repeat) (m3l33 FOR NOW)

            // set bool 'reallyAttacking' to false because we are DONE REALLY ATTACKING
            reallyAttacking = false;

        }
            // ELSE IF... the ATTACHED WEAPON that the Pirate Player is holding/using is RANGED-based
        else if (isRanged)
        {

            RangedAttack();                             // RANGED attack
            rangedAttackTimer = rangedAttackCoolDown;   // reset (rinse and repeat) (RANGED)

            // set bool 'reallyAttacking' to false because we are DONW REALLY ATTACKING
            reallyAttacking = false;

        }
            // ELSE IF... the ATTACHED WEAPON that the Pirate Player is holding/using is VOODOO-based
        else if (isVoodoo)
        {

            VoodooAttack();                             // VOODOO attack
            voodooAttackTimer = voodooAttackCoolDown;   // reset (rinse and repeat) (VOODOO)

            // set bool 'reallyAttacking' to false because we are DOWN REALLY ATTACKING
            reallyAttacking = false;

        }

        // done

    }

    // --- MELEEE ATTACK ---
    public void MeleeAttack()
    {

        // m3l33 attack
        // make that baby shake
        Handheld.Vibrate();

        // create a local variable that is the INSTANTIATED MELEE WEAPON CLONE (at current position of the Pirate Player)
        GameObject aWeapon = (GameObject)Instantiate(attackWeapon, this.transform.position, Quaternion.identity);

        Debug.Log("spawn a weapon ballllzzzz");

        // set the EMPTY 'theAttackWeapon' GameObject variable to be filled with the newly created LOCAL variable
        // this is so we can delete THIS SPECIFICALLY SPAWNED GAMEOBJECT AND NOT THE PREFAB ITSELF
        theAttackWeapon = aWeapon;

        // if not displaying weapon... display the weapon (displayWep == true)
        if (!displayMeleeWep)
            displayMeleeWep = true;

        // reset timer so it starts to count down and then when done deletes the above GameObject?
        displayMeleeWepTimer = displayMeleeWepCoolDown;

        // set the TRANSFORM object attached TO THIS SCRIPT to become the PARENT OF MELEE SWORD that was spawned
        //aWeapon.transform.parent = this.transform;

    }

    // --- RANGED ATTACK ---
    public void RangedAttack()
    {

        // rang3d attack

        // create a local variable that is the INSTANTIATED RANGED WEAPON CLONE (at current position of the Pirate Player)
        GameObject aWeapon = (GameObject)Instantiate(rangedWeapon, this.transform.position, Quaternion.identity);

        // set the EMPTY 'theAttackWeapon' GameObject variable to be filled with the newly created LOCAL variable
        // this is so we can delete THIS SPECIFICALLY SPAWNED GAMEOBJECT AND NOT THE PREFAB ITSELF
        theAttackWeapon = aWeapon;

        // if not displaying weapon.... display the weapon (displayWep == true)
        if (!displayRangedWep)
            displayRangedWep = true;

        // reset timer so it starts to count down and then when done deletes the above GameObject?
        displayRangedWepTimer = displayRangedWepCoolDown;

    }

    // --- VOODOO ATTACK ---
    public void VoodooAttack()
    {

        // V00D00 attack

        // create a local variable that is the INSTANTIATED VOODOO WEAPON CLONE (at current position of the Pirate Player)
        GameObject aWeapon = (GameObject)Instantiate(voodooWeapon, this.transform.position, Quaternion.identity);

        // set the EMPTY 'theAttackWeapon' GameObject variable to be filled with the newly created LOCAL variable
        // this is so we can delete THIS SPECIFICALLY SPAWNED GAMEOBJECT AND NOT THE PREFAB ITSELF
        theAttackWeapon = aWeapon;

        // if not displaying weapon... display the weapon (displayWep == true)
        if (!displayVoodooWep)
            displayVoodooWep = true;

        // reset timer so it tarts to count down and then when done deletes the above GameObject?
        displayVoodooWepTimer = displayVoodooWepCoolDown;

    }

}
