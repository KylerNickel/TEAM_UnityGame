using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour {

    protected Transform cameraTransform;
    protected Transform parentTransform;

    protected Vector3 localRotation;
    protected float cameraDistance = 3f;

    public float minCameraDistance = 1.5f;
    public float maxCameraDistance = 40f;
    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;

    public bool cameraDisabled = false;

	// Use this for initialization
	void Start ()
    {
        this.cameraTransform = this.transform;
        this.parentTransform = this.transform.parent;
	}
	
	void LateUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            cameraDisabled = !cameraDisabled;


        if (!cameraDisabled)
        {
            // Rotation of the camera based on the mouse coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                // Clamp the y rotation to horizon and not flipping over at the top
                localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
            }

            // Zooming input from our mouse scroll wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                // Makes camera zoom faster the further away it is from the target
                scrollAmount *= (this.cameraDistance * 0.3f);

                this.cameraDistance += scrollAmount * -1f;

                // This makes camera go no closer than 1.5 meters from the target, and no further than 100 meters
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, minCameraDistance, maxCameraDistance);
            }
        }

        // Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        this.parentTransform.rotation = Quaternion.Lerp(this.parentTransform.rotation, QT, Time.deltaTime * orbitDampening);

        if (this.cameraTransform.localPosition.z != this.cameraDistance * -1f)
        {
            this.cameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(cameraTransform.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollDampening));
        }
	}
}
