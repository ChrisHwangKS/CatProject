using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ������Ʈ�� ����� ��ü�� ��ǥ�ϴ� Ŭ�����̸�,
/// �� ������Ʈ�� ���� ����� ��ü�� �߰��� �ٸ� ������Ʈ���� �����մϴ�.
/// </summary>
public class CatInstance : MonoBehaviour
{
    // ����� �ൿ ������ ����ϴ� ��ü�Դϴ�.
    public CatBehavior m_CatBehavior;

    // �̵��� ����ϴ� ��ü�Դϴ�.
    public CatMovement m_CatMovement;

    /// <summary>
    /// �ൿ�� ����Ǿ��� ��� CatBehavior ��ü���� ȣ���մϴ�.
    /// </summary>
    /// <param name="currentBehavior">������ �ൿ�� ���޵˴ϴ�.</param>
    public void OnBehaviorChanged(BehaviorType currentBehavior)
    {
        // �ൿ�� ����Ǿ����� ��ü�鿡�� �˸��ϴ�.
        m_CatMovement.OnBehaviorChanged(currentBehavior);
    }
}
