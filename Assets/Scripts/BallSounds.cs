using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSounds : MonoBehaviour
{
    private AudioSource ballAudioSource;
    private AudioClip[] pianoNote;
    private int nextNote = 1;
    private int noteInverter = 1;

    // Start is called before the first frame update
    void Start()
    {
        ballAudioSource = this.gameObject.GetComponent<AudioSource>();
        pianoNote = new AudioClip[47];
        
        for (int i = 0; i < 47; i++)
        {
            pianoNote[i] = (AudioClip)Resources.Load("Audio/Piano/note-" + (i + 1));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") || collision.gameObject.CompareTag("PlatformBump") || collision.gameObject.CompareTag("PlatformBonus") && DrawLevel.gameIsRunning)
        {
            if ((nextNote + (1 * noteInverter)) >= 47)
                noteInverter = -1;
            else if ((nextNote + (1 * noteInverter)) <= 0)
                noteInverter = 1;

            nextNote += (1 * noteInverter);

            ballAudioSource.PlayOneShot(pianoNote[nextNote]);
        }
        /*else if (collision.gameObject.CompareTag("LastPlatform"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else if (collision.gameObject.CompareTag("Ground"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/
    }
}
