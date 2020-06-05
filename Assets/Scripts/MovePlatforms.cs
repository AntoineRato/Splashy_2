using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatforms : MonoBehaviour
{
    private float moveSpeed = 1.6464f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(DrawLevel.gameIsRunning)
            this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.y < -10f || transform.position.x < -10f)
            Destroy(this.gameObject);
    }
}
