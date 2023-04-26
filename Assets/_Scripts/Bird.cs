using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float flapStrength = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameInput.Instance.OnFlapAction += GameInput_OnFlapAction;
    }

    private void GameInput_OnFlapAction()
    {
        _rigidbody.velocity = Vector2.up * flapStrength;
    }
}
