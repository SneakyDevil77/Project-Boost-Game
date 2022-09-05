using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float mainThrust = 150f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip mainEngine;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       ProcessThrust();
       ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
        else 
            {
                audioSource.Stop();
            }
    }


    void ProcessRotation()
    {
        
        if (Input.GetKey(KeyCode.A)) 
        {
            ApplyRotation(rotateThrust);
        }

        else if (Input.GetKey(KeyCode.D)) 
        {
            ApplyRotation(-rotateThrust);
        }


    }

    void ApplyRotation(float rotationThisFrame) 
    {
        rb.freezeRotation = true; //freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; //unfreezing rotation


    }

}
