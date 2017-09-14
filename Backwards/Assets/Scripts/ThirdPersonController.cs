using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public GameObject player;
    public float movementSpeed = 10f;
    public float rotateSpeed = 1f;

    private Rigidbody rb;
    private Quaternion playerRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveCharacter();
        
    }

    void MoveCharacter()
    {
        if (Input.GetMouseButton(0) || Input.GetButton("Vertical"))
        {
            player.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        } else {
            //player.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime);
            player.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        }

        if (Input.GetButton("Vertical"))
        {
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, Camera.main.transform);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 force = new Vector3(movementSpeed, 0, 0);
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);
            rb.AddForceAtPosition(force, position);
        }
    }
}
