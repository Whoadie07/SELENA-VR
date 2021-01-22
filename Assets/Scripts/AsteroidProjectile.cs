using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidProjectile : MonoBehaviour
{
    /// <summary>
    /// none yet
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Public Field

    [HideInInspector]
    public int buttonNumber = 0;
    [HideInInspector]
    public AsteroidLevel asteroidLevel;

    #endregion

    #region Private Serialized Field

    [Header("zLimit is maximum Z value before the asteroid explodes. (default -5)")]
    [SerializeField] private float zLimit = -5;
    [SerializeField] private float movementSpeed = 10;

    #endregion

    #region Private Field

    private float damageValue = 1; // Hard coding this.

    #endregion

    #region Private Methods

    private void MoveAsteroid()
    {
        transform.Translate(new Vector3(0, 0, -Mathf.Abs(movementSpeed * Time.deltaTime)), Space.World);
    }

    private void CheckDistance()
    {
        if (transform.position.z <= zLimit)
        {
            DestroyAsteroid(true);
        }
    }

    private void DestroyAsteroid(bool hitShip)
    {
        if (hitShip)
        {
            AsteroidLevel.armorHealth -= damageValue;
        }
        asteroidLevel.TurnOffAButton(buttonNumber);
        Destroy(gameObject);
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializations

    }

    private void Update()
    {
        MoveAsteroid();
        CheckDistance();
    }

    #endregion

}//End of class