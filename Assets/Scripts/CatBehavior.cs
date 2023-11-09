using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ൿ Ÿ���� ��Ÿ���� ���� ���� ����
/// </summary>
public enum BehaviorType : sbyte
{
    // ��� ����
    Idle =0,

    // �̵� ����
    Move = 1,

    // ���� ������ ����, ������ ���� ��Ÿ���ϴ�.
    // ���� ������ ������ ��Ÿ���� ���Ͽ� ���˴ϴ�.
    BehaviorFirstValue = Idle,
    BehaviorLastValue = Move
}

public class CatBehavior : MonoBehaviour
{
    // ���� ������ ������� �ൿ�� ��Ÿ���ϴ�.
    BehaviorType _BehaviorType;

    // ���� �ൿ�� ������ �ð��� ��Ÿ���ϴ�.
    DateTime _NextBevaiorTime;

    void Update()
    {
        // �ൿ�� ���� �ð��� Ȯ���մϴ�.
        CheckBehaviorTime();
    }

    // �ൿ�� ���� �ð��� Ȯ���մϴ�.
    void CheckBehaviorTime()
    {
        // ���� �ð��� ����ϴ�.
        DateTime nowTime = DateTime.Now;

        // ���� �ൿ�� ������ �ð��� �Ǿ��ٸ�
        if(nowTime >= _NextBevaiorTime)
        {
            // ���ο� �ൿ�� ������ŵ�ϴ�.
            PickNewBehavior();

            //���� �ൿ�� ������ �ð��� �����մϴ�.
            SetNextBehaviorTime();
        }
    }

    /// <summary>
    /// ���ο� �ൿ�� �����մϴ�.
    /// </summary>
    private void PickNewBehavior()
    {
        // ������ �ൿ ���� ����ϴ�.
        int randomBehaviorValue = UnityEngine.Random.Range(
            // �ൿ�� ù ��° ���
            (int)BehaviorType.BehaviorFirstValue,
            // �ൿ�� ������ ��� + 1
           (int)BehaviorType.BehaviorLastValue + 1);

        // ���� �ൿ Ÿ���� �����մϴ�.
        _BehaviorType = (BehaviorType)randomBehaviorValue;

        Debug.Log($"���� �ൿ : {_BehaviorType}");
    }

    /// <summary>
    /// ���� �ൿ�� ������ �ð��� �����մϴ�.
    /// </summary>
    private void SetNextBehaviorTime()
    {

    }
}
