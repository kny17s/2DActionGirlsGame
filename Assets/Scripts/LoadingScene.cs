using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private float step_time;    // �o�ߎ��ԃJ�E���g�p

    void Awake()
    {
        step_time = 0.0f;       // �o�ߎ��ԏ�����
    }

    void Update()
    {
        // �o�ߎ��Ԃ��J�E���g
        step_time += Time.deltaTime;

        // 3�b��ɉ�ʂ��y�ȑI���ֈړ�
        if (step_time >= 3.0f)
        {
            SceneLoader.I.LoadScene("BattleScene");
        }
    }
}
