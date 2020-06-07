using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
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
        if(DrawLevel.gameIsRunning && collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("PlatformBump") || collision.gameObject.CompareTag("PlatformBonus"))
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
            else if (collision.gameObject.CompareTag("PlatformBonus"))
            {
                ballRigidbody.AddForce(transform.up * bounceStrenght * 6);
                //collision.gameObject.GetComponent<PlatformBump>().Bump();
                StartCoroutine(ApplyBonus(1));
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

    private IEnumerator ApplyBonus(int step)
    {
        if (step == 1)
        {
            yield return new WaitForSeconds(0.2f);
            Time.timeScale = 4;
            StartCoroutine(ApplyBonus(2));
        }
        else if (step == 2)
        {
            yield return new WaitForSeconds(4.4f);
            Debug.Log("0.1");
            Time.timeScale = 0.1f;
            StartCoroutine(ApplyBonus(3));
        }
        else if (step == 3)
        {
            yield return new WaitForSeconds(0.05f);
            Debug.Log("2");
            Time.timeScale = 2f;
        }
        /*if(step == 1)
         {
             yield return new WaitForSeconds(0.2f);
             Time.timeScale = 4;
             StartCoroutine(ApplyBonus(2));
         }
         else if(step == 2)
         {
             yield return new WaitForSeconds(4.3f);
             Debug.Log("3");
             Time.timeScale = 3f;
             StartCoroutine(ApplyBonus(3));
         }
         else if (step == 3)
         {
             yield return new WaitForSeconds(0.03f);
             Debug.Log("2");
             Time.timeScale = 2f;
             StartCoroutine(ApplyBonus(4));
         }
         else if (step == 4)
         {
             yield return new WaitForSeconds(0.03f);
             Debug.Log("1");
             Time.timeScale = 1f;
             StartCoroutine(ApplyBonus(5));
         }
         else if (step == 5)
         {
             yield return new WaitForSeconds(0.02f);
             Debug.Log("0.5");
             Time.timeScale = 0.5f;
             StartCoroutine(ApplyBonus(6));
         }
         else if (step == 6)
         {
             yield return new WaitForSeconds(0.03f);
             Debug.Log("0.1");
             Time.timeScale = 0.1f;
             StartCoroutine(ApplyBonus(7));
         }
         else if (step == 7)
         {
             yield return new WaitForSeconds(0.03f);
             Debug.Log("0.5");
             Time.timeScale = 0.5f;
             StartCoroutine(ApplyBonus(8));
         }
         else if (step == 8)
         {
             yield return new WaitForSeconds(0.02f);
             Debug.Log("1.2");
             Time.timeScale = 1.2f;
             StartCoroutine(ApplyBonus(9));
         }
         else if (step == 9)
         {
             yield return new WaitForSeconds(0.02f);
             Debug.Log("Finish(2)");
             Time.timeScale = 2f;
         }*/
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
