using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RouletteController : MonoBehaviour
{   
    float rotSpeed = 0;
    AudioSource audioSource;
    
    float accumulatedAngle = 0f;
    public float anglePerTick = 1080f;

    void Start()
    {
        Application.targetFrameRate = 60;
        audioSource = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) && this.rotSpeed == 0)
        {
            this.rotSpeed = 30;
        }

        if (this.rotSpeed > 0)
        {
            transform.Rotate(0, 0, this.rotSpeed);
            
            accumulatedAngle += this.rotSpeed;

            if (accumulatedAngle >= anglePerTick)
            {   
                audioSource.time = 0.08f;
                audioSource.Play();
                accumulatedAngle %= anglePerTick;
            }

            this.rotSpeed *= 0.995f; 

            if(this.rotSpeed < 0.1f)
            {
                this.rotSpeed = 0; 
                accumulatedAngle = 0;
            }
        }
    }
}