using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KBPlayerInputHandler : MonoBehaviour
{
    #region ABOUT
    /**
     * Handles player input from keyboard (or mouse)
     * Sets the parent camera (Main Camera) transform to a clicked object's position.
     * As such, the [CameraRig] object that this script is attached to will also have its position move.
     **/
    #endregion

    #region VARIABLES
    [Tooltip("Main Non-VR Game Camera")]
    public Camera camera;
    #endregion

    /// <summary>
    /// Listens for a mouse click and moves the Main Camera and [Camera Rig] to a raycast hit at a position to the click.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;

                // We give an offset of 2.0f for Y, and keep it throughout.
                Vector3 newPos = new Vector3(objectHit.position.x, 2.0f, objectHit.position.z);

                // Set the main camera and VR camera (this)'s positions.
                camera.transform.position = newPos;
                this.transform.position = newPos;
            }
        }
    }
}
