using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public static bool gameIsRunning;

    public GameObject platformPrefab;
    public GameObject lastPlatformPrefab;

    private float spacingPlatformValue = 1.35f;
    private float z_minGameArea = -3;
    private float z_maxGameArea = 2;

#if UNITY_EDITOR
    public float Timescale = 1.5f;
#endif

    private void Awake()
    {
        gameIsRunning = false;
        Application.targetFrameRate = 300;
        Time.timeScale = 1.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        float x_spawnValue = 1.35f;
        float z_spawnValue = -0.538f;

        for (int i = 0; i < 15; i++)
        {
            z_spawnValue += Random.Range(-spacingPlatformValue, spacingPlatformValue);
            z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

            Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);

            x_spawnValue += spacingPlatformValue;
        }

        z_spawnValue += Random.Range(-spacingPlatformValue, spacingPlatformValue);
        z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

        Instantiate(lastPlatformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //Time.timeScale = Timescale;
#endif
    }
}
