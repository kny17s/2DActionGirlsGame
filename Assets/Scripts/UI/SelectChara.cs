using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectChara : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    bool _chara = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_chara)
        {
            UsableCharacter.I.AddCharacter(_id);
        }
    }
}
