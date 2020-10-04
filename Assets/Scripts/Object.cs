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

        // called when you click on an object
        private void OnMouseDown()
        {
        }

        // called when you drag the mouse
        private void OnMouseDrag()
        {
            
        }

        // called when you release the mouse
        private void OnMouseUp()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}