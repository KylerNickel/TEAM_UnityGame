using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public GameObject character;
    public float speed = 10f;

    private Rigidbody rb;

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
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 force = new Vector3(0, 0, speed);
            Vector3 position = new Vector3(character.transform.position.x, character.transform.position.y - 0.5f, character.transform.position.z);
            rb.AddForceAtPosition(force, position);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Vector3 force = new Vector3(-speed, 0, 0);
            Vector3 position = new Vector3(character.transform.position.x, character.transform.position.y - 0.5f, character.transform.position.z);
            rb.AddForceAtPosition(force, position);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 force = new Vector3(0, 0, -speed);
            Vector3 position = new Vector3(character.transform.position.x, character.transform.position.y - 0.5f, character.transform.position.z);
            rb.AddForceAtPosition(force, position);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 force = new Vector3(speed, 0, 0);
            Vector3 position = new Vector3(character.transform.position.x, character.transform.position.y - 0.5f, character.transform.position.z);
            rb.AddForceAtPosition(force, position);
        }
    }
}
