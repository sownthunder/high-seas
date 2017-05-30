using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Camera2DFollow : MonoBehaviour
    {
        
        // Transform that will either hold the Pirate Player or Pirate Ship depending on the scene
        // A Transform is still what is specifically being followed no matter what (meaning that
        // the Transform may sometimes be taken from a GameObject other than just being itself)
        public Transform target;

        public float damping = 1;
        public float lookAheadFactor = 3;
        public float lookAheadReturnSpeed = 0.5f;
        public float lookAheadMoveThreshold = 0.1f;

        private float m_OffsetZ;
        private Vector3 m_LastTargetPosition;
        private Vector3 m_CurrentVelocity;
        private Vector3 m_LookAheadPos;

        //public GameObject playerControllerObj;

        public PlayerController thePlayerController;

        //public GameObject shipControllerObj;

        public ShipController theShipController;

        // GameObject vairable that starts off NULL but then will store the GameManagarr class 
        private GameObject theGameMangarr;

        // The Game Managarr, the class that theoretically controls everything
        private GameManagarr theGameController;

        void Awake()
        {

            // get and set playerController
            thePlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

            // get and set shipController
            theShipController = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipController>();

        }

        // Use this for initialization
        private void Start()
        {

            theGameMangarr = GameObject.FindGameObjectWithTag("GameController");
            theGameController = theGameMangarr.GetComponent<GameManagarr>();

            // SET THIS CAMERA2DFOLLOW SCRIPT/CAMERA TO BE CHILD OF GAME MANAGARR
            this.transform.parent = theGameMangarr.transform;

            ////////////////////////////////////////
            // CREATE A FUNCTION THAT WILL SEND SOMETHING TO THE GAMEMANAGAARR CLASS
            ////////////////////////////////////////

            if (target == null)
            {

                // get and set 'target' variable to be the Pirate Player or Pirate Ship
                // (above depends on level and below is converting a GameObject to TransforM
                target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            }

            // if a Pirate Town Scene (because object exists)
            if (GameObject.FindWithTag("PirateTownController"))
            {

                Debug.Log("PirateTown CAMERA RECONGISNZffff");

            }
                // ELSE IF... a Pirate Battle Scene (because object exists)
            else if (GameObject.FindWithTag("PirateBattleController"))
            {


                Debug.Log("PirateBattle CAMERA RECONGISNZ");

            }
                // ELSE IF... a Ship Battle Scene (because this object exists)
            else if (GameObject.FindWithTag("ShipBattleController"))
            {

                Debug.Log("ShipBattle CAMERA RECONGISNZ");

            }
                // ELSE IF... an Inside Building Scene (because this object exists)
            else if (GameObject.FindWithTag("InsideBuildingController"))
            {

                Debug.Log("InsideBuilding CAMERA RECONGISNZ");

            }

            // get and set the Camera Managarr GameObject
            //theCameraMangarr = GameObject.FindGameObjectWithTag("CameraController");

            // get and set Camera Controller script
            //theCameraController = theCameraMangarr.GetComponent<CameraManagarr>();
            
            m_LastTargetPosition = target.position;
            m_OffsetZ = (transform.position - target.position).z;

            // set PARENT ON THIS CAMERA 2D FOLLOW CLASS (the camera) TO BE GAME MANAGARR
            transform.parent = theGameMangarr.transform; ;
        }


        // Update is called once per frame
        private void Update()
        {
            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (target.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget)
            {
                m_LookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
            }
            else
            {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = target.position + m_LookAheadPos + Vector3.forward*m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = target.position;

            // if the player can move (== true)
            if (thePlayerController.canMove)
            {

                // get and set the camera's target to be the PIRATE PLAYER transform
                target = GameObject.FindGameObjectWithTag("Player").transform;

            }
            // else if it is false (meaning that the shipController.inShip == true)
            else
            {

                // get and set the camera's target to be the SHIP PLAYER transform
                target = GameObject.FindGameObjectWithTag("Ship").transform;

            }

            /*
            if (Application.loadedLevel == 1)
            {



            }
            else if (Application.loadedLevel == 2)
            {



            }
            else if (Application.loadedLevel == 3)
            {



            }
            else if (Application.loadedLevel == 4)
            {



            }
            else if (Application.loadedLevel == 5)
            {



            }
            */

        }
    }
}
