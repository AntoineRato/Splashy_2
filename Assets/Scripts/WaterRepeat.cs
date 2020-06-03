using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRepeat : MonoBehaviour
{
    private float moveSpeed = 1.6464f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        if(this.transform.position.x <= -63.48f)
        {
            this.transform.position = new Vector3(150.4f, this.transform.position.y, this.transform.position.z);
        }
    }
}
