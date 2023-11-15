using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� ������Ʈ�� ����� ��ü�� ��ǥ�ϴ� Ŭ�����̸�,
/// �� ������Ʈ�� ���� ����� ��ü�� �߰��� �ٸ� ������Ʈ���� �����մϴ�.
/// </summary>
public class CatInstance : MonoBehaviour
{
    /// <summary>
    /// ��������� ��ġ
    /// </summary>
    public const float HUNGRY_MIN = 30.0f;

    /// <summary>
    /// ����� ��ġ �Դϴ�.
    /// </summary>
    public float m_Hungry;

    /// <summary>
    /// ������� ��Ÿ���ϴ�.
    /// </summary>
    public bool m_IsHungry;

    // ����� �ൿ ������ ����ϴ� ��ü�Դϴ�.
    public CatBehavior m_CatBehavior;

    // �̵��� ����ϴ� ��ü�Դϴ�.
    public CatMovement m_CatMovement;

    // ����� �ִϸ��̼��� ����ϴ� ��ü�Դϴ�.
    public CatAnimation m_CatAnimation;

    // �׸� ��ü�� ��Ÿ���ϴ�.
    public BowlInstance m_BowlInstance;

    private void Update()
    {
        UpdateHungryValue();
    }

    /// <summary>
    /// ����� ��ġ�� �����մϴ�.
    /// </summary>
    private void UpdateHungryValue()
    {
        m_Hungry += Time.deltaTime * 0.01f;

        // ��������� ���
        m_IsHungry = m_Hungry >= HUNGRY_MIN;
        if (m_IsHungry)
        {
            OnHungry();
        }
    }

    /// <summary>
    /// ��������� ��� ȣ��Ǵ� �޼��� �Դϴ�.
    /// </summary>
    private void OnHungry()
    {
        // �׸��� Ȱ��ȭ ������ ���
        if(m_BowlInstance.IsEnable())
        {
            // �׸� ������Ʈ ��ġ
            Vector2 bowlPosition = m_BowlInstance.transform.position;

            // ����� ������Ʈ ��ġ
            Vector2 catPosition = transform.position;

            // �׸��� ����̰� �����ٸ�
            if(Vector2.Distance(bowlPosition, catPosition) < 0.05f)
            {
                // �Ե��� �մϴ�.
                m_Hungry -= m_BowlInstance.Eat();
            }
        }
    }


    /// <summary>
    /// �ൿ�� ����Ǿ��� ��� CatBehavior ��ü���� ȣ���մϴ�.
    /// </summary>
    /// <param name="currentBehavior">������ �ൿ�� ���޵˴ϴ�.</param>
    public void OnBehaviorChanged(BehaviorType currentBehavior)
    {
        // �ൿ�� ����Ǿ����� ��ü�鿡�� �˸��ϴ�.
        m_CatMovement.OnBehaviorChanged(currentBehavior);
        m_CatAnimation.OnBehaviorChanged(currentBehavior);
    }

    /// <summary>
    /// ������ ����Ǿ��� ��� CatAnimation ��ü���� ȣ���մϴ�.
    /// </summary>
    /// <param name="direction">������ ������ ���޵˴ϴ�.</param>
    public void OnDirectionChanged(HorizontalDirection direction)
    {
        // ������ ����Ǿ����� ��ü�鿡�� �˸��ϴ�.
        m_CatAnimation.OnDirectionChanged(direction);
    }

    /// <summary>
    /// �׸� ��ü�� ��ȯ�մϴ�.
    /// </summary>
    /// <returns>�׸� ��ü�� ��ȯ�˴ϴ�.</returns>
    public BowlInstance GetBowlInstance()
    {
        return m_BowlInstance;
    }
}
