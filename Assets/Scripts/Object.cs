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
        // name
        public string name = "";

        // description
        public string description = "";
        
        // start
        void Start()
        {
            // if the name is blank.
            if(name == "")
            {
                string str = "";
                const int CHAR_COUNT = 10;

                // uses 10 characters for the name
                for(int x = 0; x < 10; x++)
                {
                    // determines whether a number or letter is being used.
                    int y = Random.Range(0, 2);

                    switch(y)
                    {
                        case 0: // add number
                            str += Random.Range(0, 10);
                            break;

                        case 1: // add letter
                        default:
                            str += (char)(Random.Range(65, 123));
                            break;
                    }
                }

                name = str;
            }

            // UndoRedoSystem.RecordObject(this, name);
            UndoRedoSystem.RegisterCreatedObject(this, name);
        }

        // collisions
        private void OnTriggerEnter(Collider col)
        {
        
        }

       
        //private void OnMouseDown()
        //{
        //    GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(false);
         
        //    offset = transform.position - (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F;
        //}

        
        //private void OnMouseDrag()
        //{
        //    transform.position = (Input.mousePosition - new Vector3(Screen.width / 2.0F, Screen.height / 2.0F, 0.0F)) * 0.1F + offset;

            
        //    t1.GetComponent<LineRenderer>().SetPosition(0, transform.position);
        //    t2.GetComponent<LineRenderer>().SetPosition(0, transform.position);

          
        //}

        
        //private void OnMouseUp()
        //{
        //    GameObject.Find("Cube").GetComponent<CubeScript>().AddWaypointOnLeftMouseClick(true);
        //}

        
        void Update()
        {
        }
    }
}