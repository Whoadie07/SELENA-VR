using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidLevel : MonoBehaviour
{
    /// <summary>
    /// This is the main script that the Asteroid Level uses.
    /// </summary>
    /// <author>
    /// Lucas Rendell
    /// </author> 

    #region Public Static Field

    public static float armorHealth = 10;

    #endregion

    #region Private Serialized Field

    [SerializeField] private List<GameObject> asteroidButtons;
    [Header("Note: asteroidSpawns should be emptys")]
    [SerializeField] private List<Transform> asteroidSpawnTransforms;
    [SerializeField] private List<GameObject> asteroidsToSpawn;
    [SerializeField] private Image armorBarFill;
    [SerializeField] private float initialSpeed = 3.0f;
    [SerializeField] private float incrementSpeed = 0.1f;

    #endregion

    #region Private Field

    private bool isAsteroidLevelPlaying = false;
    private bool hasStarted = false;
    private int maxArmor = 10;
    private int buttonCount;
    private List<AsteroidButtonData> buttonDatas; // Button scripts should be cached, so there's less GetComponent<>()'s
    private bool[] buttonStates;
    private IEnumerator coroutine;

    #endregion

    #region Public Field

    public void StartAsteroidLevel()
    {
        isAsteroidLevelPlaying = true;
        if (!hasStarted)
        {
            hasStarted = true;
            coroutine = SpawnTimer(initialSpeed);
            StartCoroutine(coroutine);
        }
    }

    public void EndAsteroidLevel()
    {
        isAsteroidLevelPlaying = false;
        Debug.Log("Ending Asteroid Level");
    }

    public int TurnOnAButton()
    {
        int asteroidButtonInt = Random.Range(0, buttonCount-1);
        Debug.Log(asteroidButtonInt);
        Debug.Log(buttonCount);
        while (buttonStates[asteroidButtonInt])
        {
            asteroidButtonInt = Random.Range(0, buttonCount-1);
        }
        buttonStates[asteroidButtonInt] = true;
        buttonDatas[asteroidButtonInt].TurnOn();
        return asteroidButtonInt;
    }

    public void TurnOffAButton(int number)
    {
        buttonStates[number] = false;
        buttonDatas[number].TurnOff();
    }

    #endregion

    #region Private Methods

    private void GetButtons()
    {
        buttonDatas = new List<AsteroidButtonData>();
        buttonCount = 0;
        foreach (GameObject asteroidButton in asteroidButtons)
        {
            try
            {
                buttonDatas.Add(asteroidButton.GetComponent<AsteroidButtonData>());
                //buttonDatas[buttonCount].SetAsteroidNumber(buttonCount);
                buttonCount++;
            }
            catch
            {
                Debug.Log("Failed to gather Data in a asteroidButton, skipping that button.");
            }
        }
        buttonStates = new bool[buttonCount];
        for (int i = 0; i < buttonCount; i++)
        {
            buttonStates[i] = false;
        }
    }

    private void SpawnAsteroid()
    {
        int asteroidToSpawnInt = Random.Range(0, asteroidsToSpawn.Count-1);
        int asteroidSpawnTransformInt = Random.Range(0, asteroidSpawnTransforms.Count-1);
        int buttonInt = TurnOnAButton();
        Debug.Log("ti: " + asteroidSpawnTransformInt);
        Debug.Log("transform: " + asteroidSpawnTransforms[asteroidSpawnTransformInt]);
        GameObject asteroid = Instantiate(asteroidsToSpawn[asteroidToSpawnInt], asteroidSpawnTransforms[asteroidSpawnTransformInt]);
        AsteroidProjectile asteroidScript = asteroid.GetComponent<AsteroidProjectile>();
        asteroidScript.buttonNumber = buttonInt;
        asteroidScript.asteroidLevel = this;
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        // Initializations
        armorHealth = maxArmor;
        GetButtons();
        isAsteroidLevelPlaying = false;
    }

    private void Update()
    {
        if (maxArmor <= 1)
        {
            Debug.Log("Saving grace not implmented yet. (destroy remaining asteroids pew pew pew, say something inspirational, tah dah)");
            EndAsteroidLevel();
        }
    }

    private IEnumerator SpawnTimer(float time)
    {
        while (isAsteroidLevelPlaying)
        {
            time -= incrementSpeed;
            if (time <= 0.2)
            {
                isAsteroidLevelPlaying = false;
                Debug.Log("Time ran out");
            }
            SpawnAsteroid();
            yield return new WaitForSeconds(time);
        }
    }

    #endregion

}//End of class