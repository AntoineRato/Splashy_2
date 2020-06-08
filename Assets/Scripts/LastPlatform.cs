using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastPlatform : MonoBehaviour
{
    ParticleSystem[] confettiObjects;

    // Start is called before the first frame update
    void Start()
    {
        confettiObjects = new ParticleSystem[2];
        confettiObjects = this.GetComponentsInChildren<ParticleSystem>();
    }

    public void ConfettiThrow()
    {
        foreach(ParticleSystem confetti in confettiObjects)
        {
            StopAllCoroutines();
            Time.timeScale = 2f;
            confetti.Play();
            StartCoroutine(reloadGame());
        }
    }

    private IEnumerator reloadGame()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
