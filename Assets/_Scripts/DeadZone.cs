using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.tag.Equals("Pipe")) return;
        
        PipeManager.Instance.KillPipe(col.gameObject);
    }
}
