using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject allPlatformParent;

    private float spacingPlatformValue = 1.35f;
    private float z_minGameArea = -3;
    private float z_maxGameArea = 2;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Start is called before the first frame update
    void Start()
    {
        float x_spawnValue = 1.35f;
        float z_spawnValue = -0.538f;
        //float z_nextRandomPosition = 0f;

        for (int i = 0; i < 50; i++)
        {
            z_spawnValue += Random.Range(-spacingPlatformValue, spacingPlatformValue);
            z_spawnValue = Mathf.Min(z_maxGameArea, Mathf.Max(z_spawnValue, z_minGameArea));

            Instantiate(platformPrefab, new Vector3(x_spawnValue, 0, z_spawnValue), Quaternion.identity, allPlatformParent.transform);

            x_spawnValue += spacingPlatformValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
