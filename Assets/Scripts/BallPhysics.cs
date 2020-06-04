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
        if (collision.gameObject.CompareTag("Platform"))
        {
            this.gameObject.GetComponent<Animation>().Play();
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceStrenght);
            StartCoroutine(fallPlatform(collision));
        }
        else if (collision.gameObject.CompareTag("LastPlatform"))
            Time.timeScale = 0;
    }

    private IEnumerator fallPlatform(Collision collision)
    {
        yield return new WaitForSeconds(0.1f);
        collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
