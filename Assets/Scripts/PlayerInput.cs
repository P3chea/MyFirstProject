using UnityEngine;

[RequireComponent (typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float horizontalDirections = Input.GetAxis(Movement.HORIZONTA_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(Movement.JUMP);

         _playerMovement.Move(horizontalDirections, isJumpButtonPressed);
    }
}
