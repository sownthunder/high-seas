using UnityEngine;
using System.Collections;

public class BoidFlocking : MonoBehaviour {

    // Each boid runs this script. It handles randomness, clumping behavior, velocity matching behavior and target following behavior.
    // This could be updated to include weighting factors for velocity matching, target following and clumping, as has been done for randomness. 

    // RigidBody2D of the THIS PARTICULAR BOID that this script will be attached to 
    public Rigidbody2D rb2D;

    // test variables?
    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chasee;

    // USe this for pre-initialization
    void Awake()
    {

        // get and set RigidBody2D variable to be that of the RigidBody2D variable attached to this script
        rb2D = GetComponent<Rigidbody2D>();

    }

	// Use this for initialization
	void Start() 
    {

        StartCoroutine("BoidSteering");
	
	}

    IEnumerator BoidSteering()
    {
        
        while (true)
        {
            
            if (inited)
            {
                
                rb2D.velocity = rb2D.velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody2D>().velocity.magnitude;

                if (speed > maxVelocity)
                {

                    rb2D.velocity = rb2D.velocity.normalized * maxVelocity;

                }
                else if (speed < minVelocity)
                {
                    
                    rb2D.velocity = rb2D.velocity.normalized * minVelocity;

                }
                
            }

            float waitTime = Random.Range(0.3f, 0.5f);
            yield return new WaitForSeconds(waitTime);

        }

    }

    private Vector2 Calc()
    {

        Vector2 randomize = new Vector2((Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        BoidController boidController = Controller.GetComponent<BoidController>();
        Vector2 flockCenter = boidController.flockCenter;
        Vector2 flockVelocity = boidController.flockVelocity;
        Vector2 follow = chasee.transform.localPosition;

        // local vector3 variable created each time to hold the localPosition but then convert to vector2
        Vector3 flockCenterLocalPositionV3 = transform.localPosition;

        // FUCKING CAST THE VECTOR3 CONTAINING "LOCAL POSITION" TO A VECTOR2
        // localPosition == the position of the Parent object (if any)
        // local variable
        Vector2 flockCenterLocalPositionV2 = (Vector2)flockCenterLocalPositionV3;

        flockCenter = flockCenter - flockCenterLocalPositionV2;
        flockVelocity = flockVelocity - rb2D.velocity;
        follow = follow - flockCenterLocalPositionV2;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);

    }

    public void SetController(GameObject theController)
    {

        Controller = theController;
        BoidController boidController = Controller.GetComponent<BoidController>();
        minVelocity = boidController.minVelocity;
        maxVelocity = boidController.maxVelocity;
        randomness = boidController.randomness;
        chasee = boidController.chasee;
        inited = true;

    }
	
	// Update is called once per frame
	void Update() 
    {
	


	}

    // Fixed Update is called once per Unity Physics frame
    void FixedUpdate()
    {


    }

}
