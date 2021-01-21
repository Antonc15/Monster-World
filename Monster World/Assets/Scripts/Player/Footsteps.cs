using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public GameObject[] footsteps;
    int currentFootstep = 0;

    public void FootStep()
    {
        GameObject footstepAudio = Instantiate(footsteps[currentFootstep], transform.position, Quaternion.identity);
        footstepAudio.transform.parent = FindObjectOfType<AudioHandler>().transform;

        currentFootstep++;
        if(currentFootstep >= footsteps.Length)
        {
            currentFootstep = 0;
        }
    }
}
