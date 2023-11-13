using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Animator m_Animator;

    /// <summary>
    /// ����� ������ ��ȯ�Ǿ��� �� ȣ��Ǵ� �޼���
    /// </summary>
    /// <param name="direction">����� ������ ���޵˴ϴ�.</param>
    public void OnDirectionChanged(HorizontalDirection direction)
    {
        m_SpriteRenderer.flipX = (direction == HorizontalDirection.Left);
    }

    /// <summary>
    /// ����� �ൿ�� ����Ǿ��� ��� ȣ��Ǵ� �޼����Դϴ�.
    /// </summary>
    /// <param name="behaviorType">����� �ൿ�� ���޵˴ϴ�.</param>
    public void OnBehaviorChanged(BehaviorType behaviorType)
    {
        switch (behaviorType)
        {
            case BehaviorType.Idle:
                m_Animator.SetFloat("_Speed", 0.0f);
                break;

            case BehaviorType.Move:
                m_Animator.SetFloat("_Speed", 1.0f);
                break;
        }
    }
}
