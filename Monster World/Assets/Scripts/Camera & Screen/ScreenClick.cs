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
    CustomCursor cursor;

    private void Start()
    {
        cam = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cursor = GameObject.FindGameObjectWithTag("Cursor").GetComponent<CustomCursor>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(cursor.transform.position);
        RaycastHit hit;

        if (!cursor.looking && Physics.Raycast(ray, out hit))
        {
            float distance = Vector3.Distance(player.position, hit.point);

            if (distance <= reach)
            {
                if(hit.transform.tag == "Interactable")
                {
                    cursor.ChangeSprite("Interact");

                    if (hit.transform.GetComponent<Forageable>())
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            hit.transform.GetComponent<Forageable>().Clicked();
                        }
                    }
                }
                else if (hit.transform.tag == "Inspectable")
                {
                    cursor.ChangeSprite("Inspect");

                    if (Input.GetMouseButtonDown(0))
                    {
                        hit.transform.GetComponent<Inspectable>().Clicked();
                    }
                }
                else
                {
                    cursor.ChangeSprite("Idle");
                }
            }
            else
            {
                cursor.ChangeSprite("Idle");
            }
        }
    }
}
