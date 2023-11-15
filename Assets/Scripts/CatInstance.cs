using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 이 컴포넌트는 고양이 객체를 대표하는 클래스이며,
/// 이 컴포넌트를 통해 고양이 객체에 추가된 다른 컴포넌트들을 관리합니다.
/// </summary>
public class CatInstance : MonoBehaviour
{
    /// <summary>
    /// 배고파지는 수치
    /// </summary>
    public const float HUNGRY_MIN = 30.0f;

    /// <summary>
    /// 배고픔 수치 입니다.
    /// </summary>
    public float m_Hungry;

    /// <summary>
    /// 배고픔을 나타냅니다.
    /// </summary>
    public bool m_IsHungry;

    // 고양이 행동 결정을 담당하는 객체입니다.
    public CatBehavior m_CatBehavior;

    // 이동을 담당하는 객체입니다.
    public CatMovement m_CatMovement;

    // 고양이 애니메이션을 담당하는 객체입니다.
    public CatAnimation m_CatAnimation;

    // 그릇 객체를 나타냅니다.
    public BowlInstance m_BowlInstance;

    private void Update()
    {
        UpdateHungryValue();
    }

    /// <summary>
    /// 배고픔 수치를 갱신합니다.
    /// </summary>
    private void UpdateHungryValue()
    {
        m_Hungry += Time.deltaTime * 0.01f;

        // 배고파지는 경우
        m_IsHungry = m_Hungry >= HUNGRY_MIN;
        if (m_IsHungry)
        {
            OnHungry();
        }
    }

    /// <summary>
    /// 배고파지는 경우 호출되는 메서드 입니다.
    /// </summary>
    private void OnHungry()
    {
        // 그릇이 활성화 상태인 경우
        if(m_BowlInstance.IsEnable())
        {
            // 그릇 오브젝트 위치
            Vector2 bowlPosition = m_BowlInstance.transform.position;

            // 고양이 오브젝트 위치
            Vector2 catPosition = transform.position;

            // 그릇과 고양이가 가깝다면
            if(Vector2.Distance(bowlPosition, catPosition) < 0.05f)
            {
                // 먹도록 합니다.
                m_Hungry -= m_BowlInstance.Eat();
            }
        }
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

    /// <summary>
    /// 그릇 객체를 반환합니다.
    /// </summary>
    /// <returns>그릇 객체가 반환됩니다.</returns>
    public BowlInstance GetBowlInstance()
    {
        return m_BowlInstance;
    }
}
