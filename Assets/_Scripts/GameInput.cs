using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions _playerInputActions;

    public event Action OnFlapAction;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There are more than one GameInput");
        Instance = this;

        _playerInputActions = new PlayerInputActions();
        
        _playerInputActions.Player.Enable();

        _playerInputActions.Player.Flap.performed += context => OnFlapAction?.Invoke();
    }
}
