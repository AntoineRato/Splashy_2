using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    public float Timescale = 15;

    private float moveSpeed = 1.6464f;
    private float x_travelledCounter = 10;
    private float destroyValueBegin = -10f;
    private float destroyDistance = 1.35f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 15;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        
        if(this.transform.position.x < destroyValueBegin && (this.transform.position.x + x_travelledCounter) < destroyDistance)
        {
            Destroy(this.transform.GetChild(0).gameObject);
            x_travelledCounter += destroyDistance;
        }

        Time.timeScale = Timescale;
    }
}
