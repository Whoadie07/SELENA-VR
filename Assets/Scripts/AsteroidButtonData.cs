using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidButtonData : MonoBehaviour
{
    /// <summary>
    /// none yet
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Public Field

    public bool isOn = false;

    #endregion

    #region Private Serialized Field

    [SerializeField] private Material offMaterial;
    [SerializeField] private Material onMaterial;

    #endregion

    #region Private Field

    private int asteroidNumber = 0;
    private MeshRenderer meshRenderer;

    #endregion

    #region Public Methods

    /*
    public void SetAsteroidNumber(int number)
    {
        asteroidNumber = number;
    }

    public int GetAsteroidNumber()
    {
        return asteroidNumber;
    }
    */

    public void DestroyAsteroid()
    {
        Debug.Log("Destroying Asteroid.");
        TurnOff();
    }

    public void TurnOn()
    {
        isOn = true;
        meshRenderer.material = onMaterial;
    }

    public void TurnOff()
    {
        isOn = false;
        meshRenderer.material = offMaterial;
    }

    #endregion

    #region Private Methods



    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializations
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Update()
    {

    }

    #endregion
}//End of class
