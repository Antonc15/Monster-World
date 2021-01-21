using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CustomCursor : MonoBehaviour
{
    // Public Variables \\
    [Header("Images")]
    public CursorImage[] sprites;

    // Hidden Variables \\
    [HideInInspector]
    public bool looking;

    // Private Variables \\
    Image image;

    // Classes \\
    [System.Serializable]
    public class CursorImage
    {
        public Sprite image;
        public string name;
    }

    void Start()
    {
        image = GetComponent<Image>();
    }

    void Update()
    {
        // Assign Cursor Position
        transform.position = Input.mousePosition;
    }

    public void ChangeSprite(string name)
    {
        foreach(CursorImage child in sprites)
        {
            if(child.name == name)
            {
                image.sprite = child.image;
                break;
            }
        }
    }
}
