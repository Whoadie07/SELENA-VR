using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVR;
using Oculus;

public class AsteroidHand : MonoBehaviour
{
    /// <summary>
    /// none yet
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Private Serialized Field

    [SerializeField] private bool isRightHand = true; // TODO

    #endregion

    #region Private Field

    private string buttonTag = "AsteroidButton";     // Hard coding this.
    private string buttonTag2 = "AsteroidStartButton";
    private bool isTouchingButton;
    private bool isTriggerDown;

    #endregion

    #region Private Methods



    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializations

    }

    private void Update()
    {
        OVRInput.Update();
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) >= 0)
        {
            isTriggerDown = true;
        } else
        {
            isTriggerDown = false;
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag(buttonTag))
        {
            if (isTriggerDown)
            {
                collider.gameObject.GetComponent<AsteroidButtonData>().DestroyAsteroid();
            }
        } else if (collider.gameObject.CompareTag(buttonTag2))
        {
            if (isTriggerDown)
            {
                collider.gameObject.GetComponent<AsteroidStartButton>().StartGame();
            }
        } else
        {
            isTouchingButton = false;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        isTouchingButton = false;
    }



    #endregion

}//End of class