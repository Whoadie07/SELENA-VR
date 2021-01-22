using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnchor : MonoBehaviour
{
    /// <summary>
    /// This script can anchor 2 GameObjects together matching their rotation during runtime with a Vector3 offset.
    /// You could also just parent objects if you don't want to use a script.
    /// Should be very useful for anchoring objects to hands/head in VR.
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Private Serialized Field

    [SerializeField] private GameObject childObject;
    [SerializeField] private GameObject parentObject;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool reverseRotation;

    #endregion

    #region Private Field

    private Transform childTransform;
    private Transform parentTransform;

    #endregion

    #region Private Methods

    private void Anchor()
    {
        childTransform.position = parentTransform.position;
        childTransform.rotation = parentTransform.rotation;
        childTransform.Translate(offset, Space.Self);
        if (reverseRotation)
        {
            childTransform.eulerAngles = new Vector3(-parentTransform.eulerAngles.x, -parentTransform.eulerAngles.y, -parentTransform.eulerAngles.z);
        }
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializaitons
        childTransform = childObject.GetComponent<Transform>();
        parentTransform = parentObject.GetComponent<Transform>();
    }

    private void Update()
    {
        Anchor();
    }

    #endregion

}//End of class