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
    [Header("“G‚ÌŽí—Þ")]
    List<GameObject> _enemy = new();

    [SerializeField]
    [Header("–¡•û‚ÌŽí—Þ")]
    List<GameObject> _character = new();

    [SerializeField]
    GameObject[] _characterObjectData;

    [SerializeField]
    Transform _parentObject;

    private void Awake()
    {
        I = this;

        for(int i = 0; i < 5; i++)
        {
            var j = CharacterSelecter.I.CharaNum[i];
            switch (j)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
              /*case 5:
                case 6:
                case 7:
                case 8:*/
                    Instantiate(_characterObjectData[j], _parentObject);
                    break;
            }
        }
    }

}
