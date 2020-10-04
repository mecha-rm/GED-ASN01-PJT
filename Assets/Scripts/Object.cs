using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

/*
 * References:
    - https://docs.unity3d.com/ScriptReference/Transform-position.html
    - https://docs.unity3d.com/ScriptReference/Transform-rotation.html
    - https://docs.unity3d.com/ScriptReference/Transform-localScale.html
 */
// level editor namespace
namespace GED
{
    public class Object : MonoBehaviour
    {

        public string name = "";
        public string description = "";


        // Start is called before the first frame update
        void Start()
        {
        }

        // trigger for collision.
        private void OnTriggerEnter(Collider col)
        {

        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}