using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBall : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    void Update()
    {
        // Move the Blue Ball forward
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        // Check if the object is outside the screen
        if (IsVisibleOnScreen())
        {
            Destroy(gameObject); 
        }
    }

    bool IsVisibleOnScreen()
    {
        // Check if the object's bounds are within the screen's bounds
        Renderer renderer = GetComponent<Renderer>();
        if (renderer.isVisible)
        {
            return true;
        }
        return false;
    }
}


