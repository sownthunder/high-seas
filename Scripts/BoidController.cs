using UnityEngine;
using System.Collections;

public class BoidController : MonoBehaviour {

    // This script creates and collects information on the boids. It Uses the surface of the controller's collider as spawn points. 

    public float minVelocity = 5;
    public float maxVelocity = 20;
    public float randomness = 1;
    public int flockSize = 20;
    public GameObject prefab;
    public GameObject chasee;

    public Vector2 flockCenter;
    public Vector2 flockVelocity;

    // bounds variable?
    public Bounds boidBounds;

    private GameObject[] boids;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    void Awake()
    {

        // get and set the 'chasee' variable to be the Pirate Player
        chasee = GameObject.FindGameObjectWithTag("Player");

    }

	// Use this for initialization
	void Start() 
    {

        boids = new GameObject[flockSize];
        for (int i = 0; i < flockSize; i++)
        {

            // add i value so the position is different each time?
            Vector2 position = new Vector2(0f + i, 0f + i);
            
            //Vector2 position = new Vector2 (
                //Random.value * collider2dBounds.size 

            // creates local variable as an instantiated object so its easier to get scripts etc
            GameObject boid = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            boid.GetComponent<BoidFlocking>().SetController(gameObject);     // get 'BoidFlocking' script from the 'testBoid' object/script
            boids[i] = boid;

        }
	
	}

    // Update is called once per frame
    void Update() 
    {


	
	}

    // FixedUpdate is called better for physics
    void FixedUpdate()
    {

        // vector2
        Vector2 theCenter = Vector2.zero;
        Vector2 theVelocity = Vector2.zero;

        foreach (GameObject boid in boids)
        {

            // local vector3 variable created each time to hold the localPosition but then convert to vector2
            Vector3 boidLocalPositionV3 = boid.transform.localPosition;

            // FUCKING CAST THE VECTOR3 CONTAINING "LOCAL POSITION" TO A VECTOR2
            // localPosition == the position of the Parent object (if any)
            // local variable
            Vector2 boidLocalPositionV2 = (Vector2)boidLocalPositionV3;

            // computer 'theCenter' etc
            theCenter = theCenter + boidLocalPositionV2;

            // compute velocity etc by gettiing RigidBody2D through 'GetComponent' and then get/set velocity
            theVelocity = theVelocity + boid.GetComponent<Rigidbody2D>().velocity; 

        }

        flockCenter = theCenter / (flockSize);
        flockVelocity = flockVelocity / (flockSize);

    }

}
