using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GED
{
    public class UI_Manager : MonoBehaviour
    {
        public GameObject cube;

        // Start is called before the first frame update
        void Start()
        {

        }

        // SPAWNERS //
        // Spawns a cube
        public void SpawnCube()
        {
            // instantiates a new cube at the world origin
            Instantiate(cube, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 1));
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}