using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class DamageText : MonoBehaviour
{
    [SerializeField]
    [Header("消えるまでの時間")]
    float _delay;

    void Start()
    {
        //var x = UnityEngine.Random.Range(-90, 90);
        var y = UnityEngine.Random.Range(100, 280);
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, y, 0));
        DestroyObject();
    }

    public async void DestroyObject()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(_delay));
        Destroy(this.gameObject);
    }
}