using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private void Update()
    {
        transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
    }
}
