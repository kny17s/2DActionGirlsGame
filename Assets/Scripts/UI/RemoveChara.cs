using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveChara : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Header("�L�����N�^�[ID")]
    int _id;

    bool _chara = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        CharacterSelecter.I.Reduction(_id);
        Destroy(this.gameObject);
    }
}
