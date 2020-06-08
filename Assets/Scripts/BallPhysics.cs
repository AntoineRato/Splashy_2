using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallPhysics : MonoBehaviour
{
    public ParticleSystem speedLinesEffect;
    public GameObject stopMotionTimer;

    private readonly int bounceStrenght = 200;
    private Rigidbody ballRigidbody;
    private Animation ballAnimation;
    private bool stopMotionIsRunning = false;
    private bool slowMotionIsRunning = false;
    private BallSounds ballSoundsScript;

    private void Start()
    {
        ballRigidbody = this.gameObject.GetComponent<Rigidbody>();
        ballAnimation = this.gameObject.GetComponent<Animation>();
        ballSoundsScript = this.gameObject.GetComponent<BallSounds>();
    }

    private void Update()
    {
        if(stopMotionIsRunning && this.transform.position.y <= 10f)
        {
            speedLinesEffect.Stop();
            Time.timeScale = 1f;
            ballSoundsScript.Play_TimerSound();
            Time.timeScale = 0.001f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            stopMotionTimer.SetActive(true);
            stopMotionIsRunning = false;
            StartCoroutine(ApplyBonus(3));
        }
        
        if(slowMotionIsRunning)
        {
            Time.timeScale = Mathf.Clamp((Time.timeScale + 1f * Time.unscaledDeltaTime), 0f, 2f);
            if (Time.timeScale >= 2f)
            {
                slowMotionIsRunning = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(DrawLevel.gameIsRunning && collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("PlatformBump") || collision.gameObject.CompareTag("PlatformBonus"))
        {
            ballAnimation.Play();

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
                collision.gameObject.GetComponent<PlatformBump>().Bump();
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
            StartCoroutine(ReloadGame());
        else if(other.gameObject.CompareTag("Hourglass"))
        {
            StopAllCoroutines();
            Destroy(other.gameObject);
            ballSoundsScript.Play_SlowMotionSound(1);
            Time.timeScale = 1f;
            StartCoroutine(ApplyBonus(4));
        }
    }

    private IEnumerator ReloadGame()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ApplyBonus(int step)
    {
        if (step == 1)
        {
            yield return new WaitForSeconds(0.2f);
            speedLinesEffect.Play();
            Time.timeScale = 6f;
            StartCoroutine(ApplyBonus(2));
        }
        else if(step == 2)
        {
            yield return new WaitForSeconds(0.8f);
            bonusRunning = true;
        }
        else if(step == 3)
        {
            slowMotionTimer.SetActive(true);
            yield return new WaitForSeconds(0.001f);
            Time.timeScale = 2;
            Time.fixedDeltaTime = 0.02f;
            bonusRunning = false;
        }
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
