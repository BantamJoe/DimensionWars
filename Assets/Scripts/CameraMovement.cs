using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    #region ABOUT
    /**
     * Using vertical and horizontal axes, moves the camera.
     */
    #endregion

    #region VARIABLES
    public const float TRANS_SPEED = 10.0F;
    public const float ROT_SPEED = 100.0F;
    #endregion

    /// <summary>
    /// Gets input from the vertical (translation with W and A) and horizontal (rotation with A and D)
    /// and moves the camera in the appropriate directions with our set constant speeds.
    /// </summary>
    void Update () {
        float translation = Input.GetAxis("Vertical") * TRANS_SPEED;
        float rotation = Input.GetAxis("Horizontal") * ROT_SPEED;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
	}
}
