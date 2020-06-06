using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBump : MonoBehaviour
{
    private Rigidbody platformBumpRigidbody;
    private readonly int bumpStrenght = 200;
    // Start is called before the first frame update
    void Start()
    {
        platformBumpRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bump()
    {
        StartCoroutine(BumpDelay());
    }

    private IEnumerator BumpDelay()
    {
        yield return new WaitForSeconds(0.1f);
        this.GetComponentInChildren<BoxCollider>().enabled = false;
        platformBumpRigidbody.useGravity = true;
        platformBumpRigidbody.isKinematic = false;
        platformBumpRigidbody.AddForce(transform.up * bumpStrenght);
        this.GetComponentInChildren<ParticleSystem>().Play();
    }
}
