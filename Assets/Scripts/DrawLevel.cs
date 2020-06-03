using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLevel : MonoBehaviour
{
    public GameObject platformPrefab;

    private float spacingPlatformValue = 1.35f;
    private float z_MinGameArea = -3;
    private float z_MaxGameArea = 2;

    // Start is called before the first frame update
    void Start()
    {
        float x_SpawnValue = 1.35f;
        float z_SpawnValue = -0.538f;
        //float z_nextRandomPosition = 0f;

        for (int i = 0; i < 50; i++)
        {
            z_SpawnValue += Random.Range(-spacingPlatformValue, spacingPlatformValue);
            z_SpawnValue = Mathf.Min(z_MaxGameArea, Mathf.Max(z_SpawnValue, z_MinGameArea));

            //z_nextRandomPosition = Random.Range(-1.35f, 1.35f);

            /*if((z_SpawnValue + z_nextRandomPosition) > z_MaxGameArea)
            {
                z_SpawnValue = z_MaxGameArea;
            }*/
            Instantiate(platformPrefab, new Vector3(x_SpawnValue, 0, z_SpawnValue), Quaternion.identity);

            x_SpawnValue += spacingPlatformValue;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
