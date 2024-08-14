using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovementMobile : MonoBehaviour
{

    PlayerControls controls;

    float direction = 0;
    public float speed = 400;

    public Rigidbody2D playerRB;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

    }

    // Update is called once per frame
    void Update()
    {
        playerRB.velocity = new Vector2 (direction * speed * Time.deltaTime, playerRB.velocity.y);
    }
}
