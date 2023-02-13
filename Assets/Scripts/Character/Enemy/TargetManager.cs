using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : SingletonMonoBehaviour<TargetManager>
{
    public List<GameObject> Enemy => _enemy;

    public List<GameObject> Character => _character;

    public List<GameObject> _CharacterImage => _characterImage;

    [SerializeField]
    [Header("“G‚ÌŽí—Þ")]
    List<GameObject> _enemy = new();

    [SerializeField]
    [Header("–¡•û‚ÌŽí—Þ")]
    List<GameObject> _character = new();

    [SerializeField]
    List<GameObject>_characterImage;

    [SerializeField]
    List<Image> _image = new();

    [SerializeField]
    GameObject[] _characterObjectData;

    [SerializeField]
    Transform _parentObject;

    [SerializeField]
    Transform[] _parentImage;

    private void Start()
    {
        for (int i = 0; i < UsableCharacter.Instance.CharaNum.Count; i++)
        {
            var j = UsableCharacter.Instance.CharaNum[i];

            Instantiate(_image[j], _parentImage[i]);
            Instantiate(_characterObjectData[j], _parentObject);

            GetImageChildren(_parentImage[i].gameObject);
        }

        GetObjectChildren(_parentObject.gameObject);
    }

    public void GetObjectChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();

        if (children.childCount == 0)
        {
            return;
        }

        foreach (Transform childobj in children)
        {
            _character.Add(childobj.gameObject);
        }
    }

    public void GetImageChildren(GameObject obj)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        if (children.childCount == 0)
        {
            return;
        }

        foreach (Transform childobj in children)
        {

            _characterImage.Add(childobj.gameObject);
        }
    }
}
