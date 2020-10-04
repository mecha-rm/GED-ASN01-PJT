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
            GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(false);
            // alters the offset value so that the object can move along with the mouse proportionally. 
            offset = transform.position - (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F;
        }

        // called when you drag the mouse
        private void OnMouseDrag()
        {
            transform.position = (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F + offset;

            // updating the lines connected to the control points so that they're up to date.
            t1.GetComponent<LineRenderer>().SetPosition(0, transform.position);
            t2.GetComponent<LineRenderer>().SetPosition(0, transform.position);

            // redrawing the spline on both sides of the current waypoint so that it's up to date.
            DrawCurve(true);
            DrawCurve(false);
        }

        // called when you release the mouse
        private void OnMouseUp()
        {
            GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(true);
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}