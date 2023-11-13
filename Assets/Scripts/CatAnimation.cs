using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnimation : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Animator m_Animator;

    /// <summary>
    /// 고양이 방향이 전환되었을 때 호출되는 메서드
    /// </summary>
    /// <param name="direction">변경된 방향이 전달됩니다.</param>
    public void OnDirectionChanged(HorizontalDirection direction)
    {
        m_SpriteRenderer.flipX = (direction == HorizontalDirection.Left);
    }

    /// <summary>
    /// 고양이 행동이 변경되었을 경우 호출되는 메서드입니다.
    /// </summary>
    /// <param name="behaviorType">변경된 행동이 전달됩니다.</param>
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
