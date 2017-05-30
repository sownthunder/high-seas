using UnityEngine;
using System.Collections;

public class Cannonball : MonoBehaviour {

	// For use in determining "hit" on collision
	public GameObject enemyShip;

	// To see if ball has hit the ground yet or not
	public bool hitGround = false;

	// To see if the ball has made contact with the enemy ship or not
	public bool hasHitEnemy = false;

	// To see if the ball has made contact with the player ship or not
	public bool hasHitPlayer = false;

	// Highest record y that the ball achieves:
	public float highestY = 0;

	// For use in determining "hit" on collision between cannon and ship
	public float cannonEnergy;
	public float enemyShipEnergy;

	// The finalized number that each individual cannonball strike may or may not do for damage
	public float damageDealt;
	// damageDealth = VELOCITY + damageModifier (PERCENTAGE)
	// damageModifier = (powerLevel + playerShipAttackLevel + difToWeakSpot) / 10
	// to get final percentage for: damageModifier = 

	// Used because velocity is a vector3 for some stupid ass reason
	public float velocity;

	public Rigidbody cannonBallRb3D;				// Used for the rigidbody of the cannonball
	public Rigidbody enemyShipRb3D;					// Used for the rigidbody of the enemyShip

	void Awake () 
	{

		cannonBallRb3D = this.gameObject.GetComponent<Rigidbody> ();

		enemyShipRb3D = enemyShip.GetComponent<Rigidbody> ();

	}

	// Use this for initialization
	void Start () 
	{


	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
		if (this.transform.position.y > highestY)
		{

			highestY = this.transform.position.y;

		}

		if (hitGround == false) 
		{

			if (transform.position.y <= 0) 
			{
				
				hitGround = true; 
				
				Debug.Log ("X-range: " + this.transform.position.x);
				Debug.Log ("Y-range: " + highestY);
				
			}

		}

	}

	void OnCollisionEnter(Collision collision) 
	{

		if (collision.gameObject == enemyShip) 
		{

			// Gets one number for velocity
			velocity = ((cannonBallRb3D.velocity.x) * (cannonBallRb3D.velocity.y) * -1);

			// Set hasHitEnemy to try because bool is of course true (collision has occured)
			hasHitEnemy = true;

			//collision.rigidbody.isKinematic = true;

			// Energy = mass * speed (velocity)
			//cannonEnergy = cannonBallRb3D.mass * cannonBallRb3D.velocity;

			// Energy == mass * speed (velocity)
			//enemyShipEnergy = enemyShipRb3D.mass * enemyShipRb3D.velocity;

		}

	}

}
