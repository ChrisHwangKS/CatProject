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
    Idle = 0,

    // �̵� ����
    Move = 1,

    // ���� ������ ����, ������ ���� ��Ÿ���ϴ�.
    // ���� ������ ������ ��Ÿ���� ���Ͽ� ���˴ϴ�.
    BehaviorFirstValue = Idle,
    BehaviorLastValue = Move
}

public class CatBehavior : MonoBehaviour
{
    // ����� ��ü�� ��Ÿ���ϴ�.
    private CatInstance _CatInstance;

    // ���� ������ ������� �ൿ�� ��Ÿ���ϴ�.
    private BehaviorType _BehaviorType;

    // ���� �ൿ�� ������ �ð��� ��Ÿ���ϴ�.
    private DateTime _NextBevaiorTime;

    private void Start()
    {
        // �� ������Ʈ(CatBehavior) �� �߰��� ������Ʈ ������
        // CatInstance ������ ������Ʈ�� ã�� _CatInstance ������ �����մϴ�.
        _CatInstance = GetComponent<CatInstance>();
        // GetComponent<Type>() : �� ������Ʈ ���� �߰��� Type ��
        // ��ġ�ϴ� ������Ʈ�� ã�� ��ȯ�մϴ�.
    }

    private void Update()
    {
        // �ൿ�� ���� �ð��� Ȯ���մϴ�.
        CheckBehaviorTime();
    }

    // �ൿ�� ���� �ð��� Ȯ���մϴ�.
    private void CheckBehaviorTime()
    {
        // ���� �ð��� ����ϴ�.
        DateTime nowTime = DateTime.Now;

        // ���� �ൿ�� ������ �ð��� �Ǿ��ٸ�
        if (nowTime >= _NextBevaiorTime)
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

        // ����� ��ü�� �ൿ�� �����Ǿ����� �˸��ϴ�.
        _CatInstance.OnBehaviorChanged(_BehaviorType);
    }

    /// <summary>
    /// ���� �ൿ�� ������ �ð��� �����մϴ�.
    /// </summary>
    private void SetNextBehaviorTime()
    {
        int addMinute = 0;
        int addSecond = 0;

        switch (_BehaviorType)
        {
            case BehaviorType.Idle:
                // 5�ʿ��� 10�ʱ��� ������ �ð���ŭ ��� ��, ���� �ൿ�� �����մϴ�.
                addSecond = UnityEngine.Random.Range(5, 11);
                break;

            case BehaviorType.Move:
                // 2�ʿ��� 5�ʱ��� ������ �ð���ŭ �̵� ��, ���� �ൿ�� �����մϴ�.
                addSecond = UnityEngine.Random.Range(2, 6);
                break;
        }

        // ���� �ൿ�� ������ų �ð��� �����մϴ�.
        _NextBevaiorTime = DateTime.Now + new TimeSpan(0, addMinute, addSecond);
    }
}
