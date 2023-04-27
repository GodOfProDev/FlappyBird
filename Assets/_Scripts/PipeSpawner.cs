using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 2f;

    [SerializeField] private float heightOffset = 10f;

    private float _timer = 0;

    private void Update()
    {
        if (_timer < spawnRate)
            _timer += Time.deltaTime;
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }

    private void SpawnPipe()
    {
        Vector3 transformPosition = transform.position;
        
        float lowestPoint = transformPosition.y - heightOffset;
        float highestPoint = transformPosition.y + heightOffset;

        PipeManager.Instance.SpawnPipe(new Vector3(transformPosition.x, Random.Range(lowestPoint, highestPoint), 0));
    }
}