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


        
        void Start()
        {
        }

        private void OnTriggerEnter(Collider col)
        {
        
        }

       
        private void OnMouseDown()
        {
            GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(false);
         
            offset = transform.position - (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F;
        }

        
        private void OnMouseDrag()
        {
            transform.position = (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F + offset;

            
            t1.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            t2.GetComponent<LineRenderer>().SetPosition(0, transform.position);

          
        }

        
        private void OnMouseUp()
        {
            GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(true);
        }

        
        void Update()
        {
        }
    }
}