using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private PlayerControls playerControls;
    private float inputValue;

    [SerializeField] private float moveSpeed = 5f;

    private void OnEnable()
    {
        // Enable Controls
        playerControls.Player.Enable();
    }

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Update()
    {
        inputValue = playerControls.Player.Move.ReadValue<float>();
        transform.Translate(new Vector2(1,0) * inputValue * moveSpeed * Time.deltaTime);

        // Clamp between -10 and 10
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -10, 10);
        transform.position = clampedPosition;
    }



}
