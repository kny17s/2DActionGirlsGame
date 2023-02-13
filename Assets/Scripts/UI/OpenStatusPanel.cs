using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenStatusPanel : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    [Header("キャラクターID")]
    int _id;

    public void OnPointerClick(PointerEventData eventData)
    {
        UIManager.Instance.OpenCharaStatusPanel(_id);
    }
}
