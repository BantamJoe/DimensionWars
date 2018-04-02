using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRPlayerInputHandler : MonoBehaviour
{
    #region ABOUT
    /**
     * This script is attached to a controller that will handle teleporting the unit to a squad/unit, etc.
     * Passes a Ray to the Player.cs class to handle movement. (Calls TeleportTo)
     **/
    #endregion

    #region VARIABLES
    [Tooltip("The Player script attached to the main camera rig.")]
    public Player mPlayer;
    [Tooltip("Whether or not the trigger is pressed.")]
    public bool triggerButtonDown = false;

    // The trigger button Valve code to parse with GetPressDown()
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    // Returns the index ID of the controller (determined at run time)
    private SteamVR_Controller.Device controller
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }
    // The tracked object component on this controller
    private SteamVR_TrackedObject trackedObj;
    #endregion

    /// <summary>
    /// Acquire the Player component if not set.
    /// Then acquire the tracked object component from the controller.
    /// </summary>
    void Start()
    {
        // If we didn't set the player, get it from [CameraRig]
        if (!mPlayer)
        {
            mPlayer = GetComponentInParent<Player>();
        }
        // Acquire the tracked object script component from this controller
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    /// <summary>
    /// At the trigger press, we shoot a Ray and handle the teleport.
    /// </summary>
    void Update()
    {
        // If no controller is detected, return.
        if (controller == null) return;
        
        // Check to see if we pressed the trigger
        triggerButtonDown = controller.GetPressDown(triggerButton);

        // If we did press the trigger, shoot ray.
        if (triggerButtonDown)
        {
            ShootRay();
        }
    }

    /// <summary>
    /// Handles shooting a ray to teleport the player thereafter.
    /// </summary>
    private void ShootRay()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Since we hit something, teleport to it.
            // TODO: Ensure we don't teleport anywhere that isn't a squad/unit, etc.
            mPlayer.TeleportTo(hit.collider.transform.position);
        }
    }
}
