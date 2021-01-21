using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Forageable : MonoBehaviour
{
    // Public Variables \\ 
    [Header("General")]
    public int minClicks = 3;
    public int maxClicks = 5;
    public bool roatateOnClick = false;

    [Header("Audio Clips")]
    public GameObject clickSound;
    public GameObject harvestSound;

    // Private Variables \\
    Animator anim;
    int clicksUntilHarvest = 0;
    private void Start()
    {
        anim = GetComponent<Animator>();
        clicksUntilHarvest = Random.Range(minClicks, maxClicks + 1);
    }

    public void Clicked()
    {
        //If statement checks if the clicked animation is already running
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Clicked") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Harvest"))
        {
            //removes a click from harvesting
            clicksUntilHarvest--;

            //rotates the object so that the click animation faces a radnom direction.
            if (roatateOnClick)
                transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

            //Play Animations
            if (clicksUntilHarvest < 1)
            {
                anim.Play("Harvest");

                //handles the sound
                if (harvestSound != null)
                {
                    GameObject harvestObject = Instantiate(harvestSound, transform.position, Quaternion.identity);
                    harvestObject.transform.parent = FindObjectOfType<AudioHandler>().transform;
                }
            }
            else
            {
                anim.Play("Clicked");

                //Handles the click noise
                if (clickSound != null)
                {
                    GameObject clickObject = Instantiate(clickSound, transform.position, Quaternion.identity);
                    clickObject.transform.parent = FindObjectOfType<AudioHandler>().transform;
                }
            }
        }
    }

    //This function is called by the animator
    public void Harvest()
    {
        //handles the destruction
        Destroy(gameObject);
    }
}
