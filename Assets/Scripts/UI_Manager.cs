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

        // TOGGLES //
        public void IsPlayer()
        {
            addPlayerScript = !addPlayerScript;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}