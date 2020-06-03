using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private int bounceStrenght = 200;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<Animation>().Play();
        this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceStrenght);
    }
}
