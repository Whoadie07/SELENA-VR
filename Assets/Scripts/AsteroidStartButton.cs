using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidStartButton : MonoBehaviour
{
    /// <summary>
    /// none yet
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Private Serialized Field

    [SerializeField] private AsteroidLevel asteroidLevelScript;

    #endregion

    #region Private Field



    #endregion

    #region Public Methods

    public void StartGame()
    {
        asteroidLevelScript.StartAsteroidLevel();
        Debug.Log("AsteroidStartButton should change a color or something #TODO");
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializations

    }

    private void Update()
    {

    }

    #endregion

}//End of class