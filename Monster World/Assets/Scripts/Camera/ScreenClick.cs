using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenClick : MonoBehaviour
{
    // Public Variables \\
    [Header("General")]
    public float reach;

    // Private Variables \\
    Camera cam;
    Transform player;

    private void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector2 hitPos = new Vector2(hit.transform.position.x, hit.transform.position.z);

                if (hit.transform.GetComponent<Forageable>())
                {
                    float distance = Vector2.Distance(playerPos, hitPos);

                    if (distance <= reach)
                    {
                        hit.transform.GetComponent<Forageable>().Clicked();
                    }
                }
            }
        }
    }
}
