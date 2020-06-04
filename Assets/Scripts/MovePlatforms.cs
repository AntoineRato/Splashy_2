using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
#if UNITY_EDITOR
    public float Timescale = 1.5f;
#endif
    private float moveSpeed = 1.6464f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);

#if UNITY_EDITOR
        Time.timeScale = Timescale;
#endif
    }
}
