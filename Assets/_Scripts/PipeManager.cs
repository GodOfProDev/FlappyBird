using System;
using UnityEngine;
using UnityEngine.Pool;


public class PipeManager : MonoBehaviour
{
    public static PipeManager Instance { get; private set; }
    
    [SerializeField] private GameObject _pipePrefab;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There are more than one PipeManager");
        Instance = this;
    }

    private void Start()
    {
        _pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(_pipePrefab);
        }, pipe =>
        {
            pipe.SetActive(true);
            
        }, pipe =>
        {
            pipe.SetActive(false);
        }, pipe =>
        {
            Destroy(pipe);
        }, false, 10, 20);
        
    }

    private void Update()
    {
        //for (_pool.ac)
    }

    public void SpawnPipe(Vector3 position)
    {
        var pipe = _pool.Get();
        pipe.transform.position = position;
    }

    public void KillPipe(GameObject pipe)
    {
        _pool.Release(pipe);
    }
}