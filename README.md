# GED-ASN01-PJT
Assignment 1 for Game Engine Design and Implementation, which is a group assignment.

The instructions for the game are shown below.
*********************
--- KEYBOARD/MOUSE CONTROLS ---
(I) - Show/Hide Instruction Panel
(U) - Show/Hide User Interface

--- When CameraLock is Off ---
(WASDQR) - Move Camera
(ARROW KEYS, Page Up, & Page Down) - Rotate Camera
(R) - Reset Camera to Default Position

--- For Objects with a PlayerController Script Attached ---
(WASDQR) - Move Objects (When ControlLock is Off)
(Hold Right Mouse Button) - Rotate Object in Mouse Direction

OTHER
*********************************
To add an object, press the buttons on the UI (only when UI is visible).
"Main Camera" is for Display 1 and "Secondary Camera" is for Display 2. Keep in mind that the camera controls and CameraLock applies to both cameras.
IsPlayer and HasRigidBody when active apply a PlayerController Script and RigidBody respectively to an object upon it being spawned.
CameraLock when active locks the Camera controls. PlayerObjects and the cameras both use WASDQE.
To lock the controls on a PlayerObject, select that object and use the "controlLock" bool in the inspector.
