using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WalkDustScript : MonoBehaviour
{
    public VisualEffect walkDustVFX;
    public GameObject walkDustPosition;
    public float interval = 1f; // Interval between dust effects
    
    private float timer; // Tracks the time since the last VFX was played

    void Start()
    {
        timer = interval; // Initialize the timer
    }
    
    void Update()
    {
        bool isWalking = CheckIfCharacterIsWalking(); // Implement this method based on your character's movement logic

        if (isWalking)
        {
            timer += Time.deltaTime;

            if (timer >= interval)
            {
                PlayWalkDustVFX();
                timer = 0f; 
            }
        }
        else
        {
            timer = interval;
        }
    }
    
    private void PlayWalkDustVFX()
    {
        Debug.Log("Playing walk dust VFX");
        walkDustVFX.transform.position = walkDustPosition.transform.position;
        walkDustVFX.Play();
        walkDustVFX.transform.parent = null; 
    }

    private bool CheckIfCharacterIsWalking()
    {
        return true; // Placeholder return, implement according to your needs
    }
}