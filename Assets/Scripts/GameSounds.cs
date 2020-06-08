using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    private AudioSource ballAudioSource;
    private AudioClip[] pianoNote;
    private AudioClip[] slowMotion;
    private AudioClip timerSound;
    private AudioClip speedSound;
    private AudioClip bumpPlatformSound;
    private AudioClip allPianoNotes;
    private AudioClip confettiSound;
    private int nextNote = 1;
    private int noteInverter = 1;

    // Start is called before the first frame update
    void Start()
    {
        ballAudioSource = this.gameObject.GetComponent<AudioSource>();
        pianoNote = new AudioClip[47];
        slowMotion = new AudioClip[2];

        for (int i = 0; i < 47; i++)
        {
            pianoNote[i] = (AudioClip)Resources.Load("Audio/Piano/note-" + (i + 1));
        }

        allPianoNotes = (AudioClip)Resources.Load("Audio/Piano/allNotes");
        slowMotion[0] = (AudioClip)Resources.Load("Audio/slowMotion_in");
        slowMotion[1] = (AudioClip)Resources.Load("Audio/slowMotion_out"); ;
        timerSound = (AudioClip)Resources.Load("Audio/timerSound"); ;
        speedSound = (AudioClip)Resources.Load("Audio/speedEffect");
        bumpPlatformSound = (AudioClip)Resources.Load("Audio/bumpPlatformSound");
        confettiSound = (AudioClip)Resources.Load("Audio/confettiSound");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform") && DrawLevel.gameIsRunning)
        {
            if ((nextNote + (1 * noteInverter)) >= 47)
                noteInverter = -1;
            else if ((nextNote + (1 * noteInverter)) <= 0)
                noteInverter = 1;

            nextNote += (1 * noteInverter);

            ballAudioSource.PlayOneShot(pianoNote[nextNote]);
        }
        else if (collision.gameObject.CompareTag("LastPlatform"))
        {
            ballAudioSource.PlayOneShot(confettiSound, 1.7f);
            ballAudioSource.PlayOneShot(allPianoNotes);
        }
        /*else if (collision.gameObject.CompareTag("Ground"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);*/
    }
    
    /// <summary>
    /// Play slow motion sound.
    /// </summary>
    /// <param name="step"> 1 = in / 2 = out</param>
    public void Play_SlowMotionSound(int step)
    {
        ballAudioSource.PlayOneShot(slowMotion[step - 1], 0.9f);
    }

    public void Play_TimerSound()
    {
        ballAudioSource.PlayOneShot(timerSound, 1.2f);
    }

    public void Play_SpeedSound()
    {
        ballAudioSource.PlayOneShot(speedSound, 0.2f);
    }

    public void Play_BumpPlatformSound()
    {
        ballAudioSource.PlayOneShot(bumpPlatformSound);
    }

    public void StopCurrentSound()
    {
        ballAudioSource.Stop();
    }
}
