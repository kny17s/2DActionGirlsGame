using Ono.MVP.Model;
using Ono.MVP.View;
using UniRx;
using UnityEngine;

namespace Ono.MVP.Presenter
{
    public class CharacterHpPresenter : MonoBehaviour
    {
        [SerializeField]
        CharacterHpView _characterView;

        [SerializeField]
        CharacterHpModel _characterModel;

        private void Start()
        {
            _characterModel.CurrentHp_0
                .Subscribe(value => { _characterView.SetValueCharacter0(value); }).AddTo(this);

            _characterModel.CurrentHp_1
                .Subscribe(value => { _characterView.SetValueCharacter1(value);}).AddTo(this);

            _characterModel.CurrentHp_2
                .Subscribe(value => { _characterView.SetValueCharacter2(value); }).AddTo(this);

            _characterModel.CurrentHp_3
                .Subscribe(value => { _characterView.SetValueCharacter3(value); }).AddTo(this);

            _characterModel.CurrentHp_4
                .Subscribe(value => { _characterView.SetValueCharacter4(value); }).AddTo(this);

        }
    }
}
