using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPhysics : MonoBehaviour
{
    private readonly int bounceStrenght = 200;
    private Rigidbody ballRigidbody;
    private Animation ballAnimation;
    private int platformHitCount = 0;

    private void Start()
    {
        ballRigidbody = this.gameObject.GetComponent<Rigidbody>();
        ballAnimation = this.gameObject.GetComponent<Animation>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(DrawLevel.gameIsRunning && collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("PlatformBump"))
        {
            ballAnimation.Play();
            platformHitCount++;
            if (platformHitCount % 10 == 0)
                Time.timeScale += 0.1f;

            if (collision.gameObject.CompareTag("Platform"))
            {
                ballRigidbody.AddForce(transform.up * bounceStrenght);
                StartCoroutine(fallPlatform(collision));
            }
            else if (collision.gameObject.CompareTag("PlatformBump"))
            {
                ballRigidbody.AddForce(transform.up * bounceStrenght * 3);
                collision.gameObject.GetComponent<PlatformBump>().Bump();
            }

            //Replace the ball at the center x of platform to avoid the desyncronisation of the rhythm
            Transform floorPlatformTransform = collision.transform.GetChild(0).transform;
            if (Mathf.Abs((this.transform.position - floorPlatformTransform.position).x) > 0.28f)
            {
                this.transform.position = new Vector3(floorPlatformTransform.position.x, this.transform.position.y, this.transform.position.z);
            }
        }
        else if (collision.gameObject.CompareTag("LastPlatform"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (collision.gameObject.CompareTag("Ground"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator fallPlatform(Collision collision)
    {
        yield return new WaitForSeconds(0.1f);
        Rigidbody collisionRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        collisionRigidbody.useGravity = true;
        collisionRigidbody.isKinematic = false;
        collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
    }
}
