using Ono.MVP.Model;
using Ono.MVP.View;
using UniRx;
using UnityEngine;

namespace Ono.MVP.Presenter
{
    public class EnemyPresenter : MonoBehaviour
    {
        [SerializeField]
        EnemyView _enemyterView;

        [SerializeField]
        EnemyModel _enemyModel;

        private void Start()
        {
            _enemyModel.CurrentEnemyHp
                .Subscribe(value => { _enemyterView.SetValue(value); }).AddTo(this);
        }
    }
}
