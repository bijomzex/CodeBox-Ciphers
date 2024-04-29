using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    private float rotationAngle;
    private float movementSpeed;
    public GameObject gameObjectToDestroy;
    private void Start()
    {
        // Rotate the plane randomly in the Z-axis within the range of -45 to +45 degrees
         rotationAngle = Random.Range(-45f, 45f);
         Vector3 rotationAxis = Vector3.forward;
         transform.rotation = Quaternion.AngleAxis(rotationAngle, rotationAxis);
         movementSpeed = Random.Range(20f, 30f);
 
    }

    private void Update()
    {
        // Move the plane forward at the computed speed
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        CameraSupport s = Camera.main.GetComponent<CameraSupport>();  // Try to access the CameraSupport component on the MainCamera
        if (s != null)   // if main camera does not have the script, this will be null
        {
            // intersect my bond with the bounds of the world
            Bounds myBound = GetComponent<Renderer>().bounds;  // this is the bound on the SpriteRenderer
            CameraSupport.WorldBoundStatus status = s.CollideWorldBound(myBound);
            
            // If result is not "inside", then, move the hero to a random position
            if (status != CameraSupport.WorldBoundStatus.Inside)
            {
                // now let's re-spawn ourself somewhere in the world
                Debug.Log("Touching the world edge: " + status);
                Destroy(transform.gameObject);
            }
        }
    }
}
