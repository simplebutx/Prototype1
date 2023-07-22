using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    [SerializeField] public float smoothness= 0.001f;

    private float minY = -18f; 
    private float maxY = 1; 

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }


        if (Input.GetMouseButton(0))
        {
            Vector3 currentPosition = Input.mousePosition;
            Vector3 moveDirection = (currentPosition - dragOrigin) * smoothness;

            moveDirection.x = 0;

            Vector3 newPosition = transform.position - moveDirection;
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
            transform.position = newPosition;
        }
    }
}
