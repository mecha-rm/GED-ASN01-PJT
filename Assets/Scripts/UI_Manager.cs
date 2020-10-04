/*
 * References:
    * https://answers.unity.com/questions/1087029/how-to-change-camera-on-trigger-enter-unity-5.html
    * https://answers.unity.com/questions/1171111/hideunhide-game-object.html
    * https://docs.unity3d.com/ScriptReference/Component-gameObject.html
    * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GED
{
    public class UI_Manager : MonoBehaviour
    {
        // objects used for instaniation
        public GameObject cube;
        public GameObject sphere;
        public GameObject capsule;
        public GameObject cylinder;
        public GameObject plane;
        public GameObject quad;
        public GameObject terrain;
        public GameObject tree;

        // main camera and secondary camera
        private bool swapCam = false;
        public Camera cam1;
        public Camera cam2;

        // sets whether the recently instantiated object is a player or not.
        private bool addPlayerScript = false;

        // Start is called before the first frame update
        void Start()
        {

        }

        // SPAWNERS //
        // Spawns a cube
        public void SpawnCube()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(cube, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();
            
        }

        // Spawns a sphere
        public void SpawnSphere()
        {
            // instatiates a new sphere at the world origin
            GameObject newObject = Instantiate(sphere, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if(addPlayerScript)
                newObject.AddComponent<PlayerController>();
            
        }

        // Spawns a capsule
        public void SpawnCapsule()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(capsule, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // Spawns a cylinder
        public void SpawnCylinder()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(cylinder, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // Spawns a cylinder
        public void SpawnPlane()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(plane, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // Spawns a quad
        public void SpawnQuad()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(quad, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // Spawns a terrain object
        public void SpawnTerrain()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(terrain, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // Spawns a tree
        public void SpawnTree()
        {
            // instantiates a new cube at the world origin
            GameObject newObject = Instantiate(tree, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));

            // adds a player script
            if (addPlayerScript)
                newObject.AddComponent<PlayerController>();

        }

        // TOGGLES //
        public void IsPlayer()
        {
            addPlayerScript = !addPlayerScript;
        }

        // Update is called once per frame
        void Update()
        {

            // switches the camera
            // if(Input.GetKeyDown(KeyCode.C))
            // {
            // 
            //     // TODO: this isn't very intuitive. This is just to see if I can get it to work.
            //     swapCam = !swapCam;
            //     switch(swapCam)
            //     {
            //         case true:
            //             // cam1.enabled = false;
            //             //cam1.targetDisplay = 2;
            // 
            //             // cam2.enabled = true;
            //             //cam2.targetDisplay = 1;
            //             int temp1 = cam1.targetDisplay;
            //             int temp2 = cam2.targetDisplay;
            // 
            //             Display.displays[cam2.targetDisplay].Activate();
            //             // gameObject.SetActive(false);
            //             break;
            //         case false:
            //             // cam2.enabled = false;
            //             //cam2.targetDisplay = 2;
            // 
            //             // cam1.enabled = true;
            //             //cam1.targetDisplay = 1;
            // 
            //             // gameObject.SetActive(true);
            //             Display.displays[cam1.targetDisplay].Activate();
            //             break;
            //     }
            // }
        }
    }
}