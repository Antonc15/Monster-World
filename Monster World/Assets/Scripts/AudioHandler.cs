using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    void Update()
    {
        foreach(Transform child in transform)
        {
            AudioSource source = child.GetComponent<AudioSource>();
            if (!source.isPlaying)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
