using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;
using Cysharp.Threading;
using System;
using Cysharp.Threading.Tasks;

public class TargetManager : SingletonMonoBehaviour<TargetManager>
{
    public List<GameObject> EnemyObjects => _enemyObjects;

    public List<GameObject> CharacterDatas => _characterDatas;

    public List<GameObject> _CharacterImage => _characterImage;

    [SerializeField]
    [Header("“G‚ÌŽí—Þ")]
    List<GameObject> _enemyObjects = new();

    [SerializeField]
    [Header("–¡•û‚ÌŽí—Þ")]
    List<GameObject> _characterDatas = new();

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

    Character _character;

    [SerializeField]
    Enemy _enemy;

    [SerializeField]
    BarrieEnemy _barrieEnemy;

    [SerializeField]
    EnemyBoss _enemyBoss;

    [SerializeField]
    GameObject _enemyObject;

    [SerializeField]
    GameObject _barrieEnemyObject;

    [SerializeField]
    GameObject _enemyBossObject;

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
            _characterDatas.Add(childobj.gameObject);
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
    public async void CharacterDeathCheck()
    {
        for(int i = 0; i < _characterDatas.Count; i++)
        {
            _character = _characterDatas[i].GetComponent<Character>();
            Debug.Log(_character);

            if (_character.Death == true)
            {
                _characterDatas.Remove(_characterDatas[i]);
            }
        }

        if (_characterDatas.Count == 0)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            SceneLoader.Instance.ChangeScene("GameOverScene");
        }
    }

    public async void EnemyDeathCheck()
    {
        if(_enemy.Death == true)
        {
            _enemyObjects.Remove(_enemyObject);
        }

        if (_barrieEnemy.Death == true)
        {
            _enemyObjects.Remove(_barrieEnemyObject);
        }

        if (_enemyBoss.Death == true)
        {
            _enemyObjects.Remove(_enemyBossObject);
        }

        if (_enemyObjects.Count == 0)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3.0f));
            SceneLoader.Instance.ChangeScene("GameClearScene");
        }
    }
}
