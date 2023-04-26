using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static Bird Instance { get; private set; }
    
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float flapStrength = 10f;
    [SerializeField] private LayerMask pipeLayer;
    [SerializeField] private LayerMask pipeScoreLayer;
    
    public int Score { get; private set; }

    public event Action OnScoreChanged;
    public event Action OnGameOver;
    
    private bool IsAlive { get; set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There are more than one Bird");
        Instance = this;
        
        _rigidbody = GetComponent<Rigidbody2D>();
        IsAlive = true;
    }

    private void Start()
    {
        GameInput.Instance.OnFlapAction += GameInput_OnFlapAction;
    }

    private void GameInput_OnFlapAction()
    {
        if (!IsAlive) return;
        
        _rigidbody.velocity = Vector2.up * flapStrength;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer != ToLayer(pipeScoreLayer)) return;
        
        Score += 1;
        OnScoreChanged?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != ToLayer(pipeLayer)) return;
        
        Score = 0;
        OnScoreChanged?.Invoke();
        OnGameOver?.Invoke();
        IsAlive = false;
    }

    private int ToLayer(int bitmask)
    {
        int result = bitmask>0 ? 0 : 31;
        while( bitmask>1 ) {
            bitmask = bitmask>>1;
            result++;
        }
        return result;
    }
}
