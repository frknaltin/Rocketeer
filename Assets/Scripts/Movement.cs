using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float rocketSpeed = 1500.0f;
    [SerializeField] float rotationSpeed = 100.0f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem engineParticles;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else 
        {
            audioSource.Stop();
            engineParticles.Stop();
        }

    }
    void ProcessRotation()
    {
        StartRotating();
    }
    
    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward*Time.deltaTime*rotationThisFrame);
        rb.freezeRotation = false;
    }
    
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up*Time.deltaTime*rocketSpeed);
            
            if (!engineParticles.isPlaying)
            {
                engineParticles.Play();
            }
            if (!audioSource.isPlaying) 
            {
                audioSource.PlayOneShot(mainEngine);    
            }
    }
    void StartRotating()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }
}