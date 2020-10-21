# GED-ASN01-PJT
Assignment 1 for Game Engine Design and Implementation, which is a group assignment.

- PART 1 -
The instructions for the game are shown below.
*********************
--- KEYBOARD/MOUSE CONTROLS ---
(I) - Show/Hide Instruction Panel
(U) - Show/Hide User Interface
(CTRL + Z) - Undo
(CTRL + Y) - Redo

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


- PART 2 -
Design Patterns
* Command Design Pattern: Undo/Redo
	- Use CTRL + Z & CTRL + Y for undo/redo, or menu buttons
	- Doesn't allow for the undoing or redoing of object creation or destruction.
* Factory Design Pattern: Spawner
	- Create custom spawner using UI button.
	- Add entities and add options in the spawner that index wise correspond with said entities.
* Optional Design Pattern:
	- State Machine: state machine changes state via number or name (if applicable), then notifies observers.
	- Observer (Bonus): tracks changes in state machine. Derived classes determine how observer reacts.

The example for state machines has a piece of text that shows which object is selected.
This is finicky due to the hitgeometry, and other than this label it doesn't do anything.

DLL for saving and loading files was not completed. Crashes Unity if attempted.