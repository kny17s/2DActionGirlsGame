using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttakTarget : MonoBehaviour
{
    public static AttakTarget I = null;

    public List<GameObject> Enemy => _enemy;

    public List<GameObject> Character => _character;

    [SerializeField]
    [Header("敵の種類")]
    List<GameObject> _enemy = new();

    [SerializeField]
    [Header("味方の種類")]
    List<GameObject> _character = new();

    [SerializeField]
    GameObject[] _characterObjectData;

    [SerializeField]
    Transform _parentObject;

    [SerializeField]
    List<Image> _characterImage = new();

    [SerializeField]
    Transform[] _parentImage;

    private void Awake()
    {
        I = this;
        for (int i = 0; i < UsableCharacter.I.CharaNum.Count; i++)
        {
            var j = UsableCharacter.I.CharaNum[i];
            switch (j)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                    Instantiate(_characterObjectData[j], _parentObject);
                    //var num = Random.Range(0, _parentImage.Length);
                    //Instantiate(_characterImage[j], _parentImage[num]);
                    break;
                default:
                    Debug.LogError("error　error　error　error　error　error");
                    break;
            }
        }

        GetChildren(_parentObject.gameObject);
    }

    public void GetChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }

        foreach (Transform childobj in children)
        {
            //子要素をaddする
            _character.Add(childobj.gameObject);
        }
    }
}
