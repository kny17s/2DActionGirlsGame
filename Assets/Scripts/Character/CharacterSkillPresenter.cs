using Ono.MVP.Model;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Cysharp.Threading.Tasks;
using System;
using UniRx;

public class CharacterSkillPresenter : MonoBehaviour
{
    [SerializeField]
    CharacterSkillView _characterSkillView;

    [SerializeField]
    CharacterSkillModel _characterSkillModel;

    private void Start()
    {
        _characterSkillModel.CurrentSp_0
            .Subscribe(value => { _characterSkillView.SetValueCharacter0(value); }).AddTo(this);

        _characterSkillModel.CurrentSp_1
            .Subscribe(value => { _characterSkillView.SetValueCharacter1(value); }).AddTo(this);

        _characterSkillModel.CurrentSp_2
            .Subscribe(value => { _characterSkillView.SetValueCharacter2(value); }).AddTo(this);

    }

}