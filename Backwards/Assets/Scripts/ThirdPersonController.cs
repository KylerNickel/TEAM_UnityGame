using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour {

    public GameObject player;
    public Camera playerCam;
    public Camera spectatorCam;
    public float movementSpeed = 10f;
    public float rotateSpeed = 1f;

    public float health = 100; //
    public float shield = 100; // TODO change these to private
    public float powerLevel = 0; //

    void Start()
    {

    }

    void Update()
    {
        MovePlayer();
        if (health <= 0)
            Die();
    }

    void MovePlayer()
    {
        // if left mouse button or w is pressed, rotate the player toward the camera direction
        if (Input.GetMouseButton(0) || Input.GetButton("Vertical"))
        {
            player.transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        } else {
            player.transform.Rotate(0, (Input.GetAxis("Horizontal") * Time.deltaTime), 0);
        }

        // apply rotations
        if (Input.GetButton("Vertical"))
            transform.Translate(0, 0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, player.transform);

        if (Input.GetButton("Horizontal"))
            transform.Translate((Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime), 0, 0, player.transform);
    }

    void ApplyDamage (float damage)
    {
        if (shield != 0) {
            shield -= damage;
        } else if (shield <= 0) {
            health -= damage;
        }
    }

    void Die()
    {
        Instantiate(spectatorCam, playerCam.transform.position, playerCam.transform.rotation);
        Destroy(player);
    }
}