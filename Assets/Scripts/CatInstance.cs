using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이 컴포넌트는 고양이 객체를 대표하는 클래스이며,
/// 이 컴포넌트를 통해 고양이 객체에 추가된 다른 컴포넌트들을 관리합니다.
/// </summary>
public class CatInstance : MonoBehaviour
{
    // 배고픔 수치 입니다.
    public float m_Hungry;

    // 고양이 행동 결정을 담당하는 객체입니다.
    public CatBehavior m_CatBehavior;

    // 이동을 담당하는 객체입니다.
    public CatMovement m_CatMovement;

    // 고양이 애니메이션을 담당하는 객체입니다.
    public CatAnimation m_CatAnimation;

    private void Update()
    {
        UpdateHungryValue();
    }

    private void UpdateHungryValue()
    {
        m_Hungry += Time.deltaTime * 0.01f;
    }

    /// <summary>
    /// 행동이 변경되었을 경우 CatBehavior 객체에서 호출합니다.
    /// </summary>
    /// <param name="currentBehavior">설정된 행동이 전달됩니다.</param>
    public void OnBehaviorChanged(BehaviorType currentBehavior)
    {
        // 행동이 변경되었음을 객체들에게 알립니다.
        m_CatMovement.OnBehaviorChanged(currentBehavior);
        m_CatAnimation.OnBehaviorChanged(currentBehavior);
    }

    /// <summary>
    /// 방향이 변경되었을 경우 CatAnimation 객체에서 호출합니다.
    /// </summary>
    /// <param name="direction">설정된 방향이 전달됩니다.</param>
    public void OnDirectionChanged(HorizontalDirection direction)
    {
        // 방향이 변경되었음을 객체들에게 알립니다.
        m_CatAnimation.OnDirectionChanged(direction);
    }
}
