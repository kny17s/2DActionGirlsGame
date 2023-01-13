using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    async void Start()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(0.8f));
        Destroy(this.gameObject);
    }
}
