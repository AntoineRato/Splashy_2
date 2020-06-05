using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPhysics : MonoBehaviour
{
    private int bounceStrenght = 200;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && DrawLevel.gameIsRunning)
        {
            this.gameObject.GetComponent<Animation>().Play();
            this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * bounceStrenght);
            StartCoroutine(fallPlatform(collision));
        }
        else if (collision.gameObject.CompareTag("LastPlatform"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (collision.gameObject.CompareTag("Ground"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator fallPlatform(Collision collision)
    {
        yield return new WaitForSeconds(0.1f);
        collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
