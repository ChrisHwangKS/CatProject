using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Animator m_Animator;

    // �׸��� ������ ������ų Transform Component
    public Transform m_DrawPivotTransform;

    // �׸��� ������ ������Ű�� ���� ���� Transform Component
    public Transform m_BowlDrawPivotTransform;

    private void Update()
    {
        UpdateDrawOrder();
    }

    /// <summary>
    /// �׸��� ������ �����մϴ�.
    /// </summary>
    private void UpdateDrawOrder()
    {
        float catYPosition = m_DrawPivotTransform.position.y;
        float bowlYPosition = m_BowlDrawPivotTransform.position.y;

        // ������� ��ġ�� �׸� ��ġ���� ���� ��ġ�� ��� �׸��� ���� �׷��� �� �ֵ��� �մϴ�.
        m_SpriteRenderer.sortingOrder = (catYPosition > bowlYPosition) ? -1 : 1;
    }

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
