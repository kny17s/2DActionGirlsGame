using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenMaxStatusPanel : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    [Header("�L�����N�^�[ID")]
    int _id;

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.OpenCharaGachaStatusPanel(_id);
    }
}
