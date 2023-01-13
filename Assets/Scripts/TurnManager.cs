using Ono.MVP.Model;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class TurnManager : MonoBehaviour
{
    public static TurnManager I = null;

    public bool Turn => _turn;

    [SerializeField]
    bool _turn = true;

    public void Start()
    {
        I = this;

        //false‚É‚È‚Á‚½‚ç“G‚ªUŒ‚
        this.ObserveEveryValueChanged(x => !x._turn)
        .Where(x => x)
        .Subscribe(_ => RandomTarget());
    }

    void RandomTarget()
    {
        var num = UnityEngine.Random.Range(0,2);
        CharacterHpModel.I.Damage(SaveCharacterData.I.Atk[3], num);
        DelayTime();
    }

    private async void DelayTime()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3f));
        _turn = true;
    }
}
