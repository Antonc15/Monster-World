using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFollow : MonoBehaviour
{
    public Transform follow;
    public float heightDifference;

    void Update()
    {
        transform.position = new Vector3(follow.position.x, follow.position.y + heightDifference, follow.position.z);
    }
}
