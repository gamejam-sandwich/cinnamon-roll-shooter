using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float screenBorder;

    private Rigidbody2D rigidbody;
    private Vector2 movementInput;
    private Vector2 smoothedMovement;
    private Vector2 smoothVelocity;
    private Camera camera;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    private void FixedUpdate()
    {
        SetPlayerVelocity();
        RotateDirection();
    }

    private void SetPlayerVelocity()
    {
        smoothedMovement = Vector2.SmoothDamp(
            smoothedMovement,
            movementInput,
            ref smoothVelocity,
            0.1f);

        rigidbody.velocity = smoothedMovement * speed;
        PreventOffScreen();
    }

    private void PreventOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if((screenPosition.x < screenBorder && rigidbody.velocity.x < 0) ||
            (screenPosition.x > camera.pixelWidth - screenBorder && rigidbody.velocity.x > 0))
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if ((screenPosition.y < screenBorder && rigidbody.velocity.y < 0) ||
            (screenPosition.y > camera.pixelHeight - screenBorder && rigidbody.velocity.y > 0))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        }
    }

    private void RotateDirection()
    {
        if (movementInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothedMovement);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rigidbody.MoveRotation(rotation);
        }
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
