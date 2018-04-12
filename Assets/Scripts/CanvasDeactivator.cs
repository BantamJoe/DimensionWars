using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDeactivator : MonoBehaviour
{
    #region ABOUT
    /**
     * Disables the Canvas it is on if the [CameraRig]'s features are not activated (not in VR mode).
     * This can be done by checking if the controllers are active.
     **/
    #endregion

    #region VARIABLES
    [Tooltip("The right controller attached to the [CameraRig]. MUST BE SET.")]
    public GameObject rightController;
    #endregion

    void Start()
    {
        if (!rightController)
        {
            this.gameObject.SetActive(false);
        }

        if (rightController.activeSelf == false)
        {
            this.gameObject.SetActive(false);
        }
    }
}
