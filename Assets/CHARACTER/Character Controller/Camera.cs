 using UnityEngine;
 using System.Collections;
 
 // Place the script in the Camera-Control group in the component menu
 [AddComponentMenu("Camera-Control/Smooth Follow CSharp")]
 
 public class Camera : MonoBehaviour
 {

     // The target we are following
     public Transform target;
     // The distance in the x-z plane to the target
     public float distance = 10.0f;
     // the height we want the camera to be above the target
     public float height = 5.0f;
     // How much we 
     public float heightDamping = 2.0f;
     public float rotationDamping = 3.0f;
 
     void  LateUpdate ()
     {

         Vector3 vNewInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
         
         // Only do work if meaningful
         if(vNewInput.sqrMagnitude < 0.1f)
         {
             return;
         }

         if (Input.GetKeyDown ("joystick button 5")) {
             
         }
 
         // Apply the transform to the object  
         var angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg;
         // Early out if we don't have a target
         if (!target)
             return;
     
         // Calculate the current rotation angles
         float wantedRotationAngle = target.eulerAngles.y;
         float wantedHeight = target.position.y + height;
         float currentRotationAngle = transform.eulerAngles.y;
         float currentHeight = transform.position.y;
     
         // Damp the rotation around the y-axis
         currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
 
         // Damp the height
         currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
 
         // Convert the angle into a rotation
         Quaternion currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
     
         // Set the position of the camera on the x-z plane to:
         // distance meters behind the target
         transform.position = target.position;
         transform.position -= currentRotation * Vector3.forward * distance;
 
         // Set the height of the camera
         transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
     
         // Always look at the target
         transform.LookAt (target);
     }
 }