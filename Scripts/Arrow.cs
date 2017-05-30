using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    // Rigidbody2D of THIS PARTICULAR Arrow Object this script is attached to
    public Rigidbody2D rb2D;

    // GameObject variable that starts off NULL but will hold the Pirate Player
    // and will be used to determine when/if to stop arrows and when/where, etc
    public GameObject piratePlayer;

    // Use this for pre-initialization
    void Awake()
    {

        // get and set the RigidBody2D by taking from ATTACHED GameObject
        rb2D = GetComponent<Rigidbody2D>();

        // Get and set 'piratePlayer' variable
        piratePlayer = GameObject.FindGameObjectWithTag("Player");

    }

	// Use this for initialization
	void Start() 
    {


	
	}
	
	// Update is called once per frame
	void Update() 
    {

        // if THIS PARTICULAR Arrow that was shot has moved past a certain distance
        if (rb2D.transform.position.y >= 20)
        {

            Debug.Log("BOOM goes the dynamite");

            // Destroy THIS arrow
            Destroy(this.transform.gameObject);

        }
	
	}

    // FixedUpdate is called once per Unity Physics frame
    void FixedUpdate()
    {

        // Apply Force upwards (only one direction FOR NOW for testing)
        // 2.5f is 1.0 faster than the Pirate Player's CURRENT(test) speed 
        rb2D.AddForce(Vector2.up * 2.5f);

    }

}
