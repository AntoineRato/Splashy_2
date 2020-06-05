using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovements : MonoBehaviour
{
    private Touch touch;
    private float moveSpeed = 0.007f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !DrawLevel.gameIsRunning)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - touch.deltaPosition.x * moveSpeed);
            }
        }
    }
}
