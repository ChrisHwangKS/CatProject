using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO ���� ���� ��� 5�� �� ��������� �ؾ� �մϴ�. 


public class BowlInstance : MonoBehaviour
{
    private const int TURNOFFSECOND = 5000;

    // �� �׸� ��������Ʈ�� ��Ÿ���ϴ�.
    public Sprite m_EmptyBowl;

    // ä���� ��׸� ��������Ʈ�� ��Ÿ���ϴ�.
    public Sprite m_FeedBowl;

    // �� ��ġ�� ��Ÿ���ϴ�.
    public float m_Value;

    public Transform m_ValueBarPivot;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();


        // ������Ʈ�� ��Ȱ��ȭ ��ŵ�ϴ�.
        DestroyBowl();
    }

    private void Update()
    {
        UpdateValueBar();
    }

    private void UpdateValueBar()
    {
        Vector3 currentScale = m_ValueBarPivot.localScale;
        currentScale.x = m_Value / 100.0f;
        m_ValueBarPivot.localScale = currentScale;

        CheckEmpty();
    }

    /// <summary>
    /// �׸� ��ü�� Ȱ��ȭ ��ŵ�ϴ�.
    /// </summary>
    public void EnableBowl()
    {
        m_Value = 100.0f;

        // ������Ʈ�� Ȱ��ȭ ��ŵ�ϴ�.
        gameObject.SetActive(true);

        // SpriteRenderer ������Ʈ�� ã��, ��������Ʈ �̹����� �����մϴ�.
        //GetComponent<SpriteRenderer>().sprite = m_FeedBowl;
        _spriteRenderer.sprite = m_FeedBowl;
    }

    /// <summary>
    /// �׸� ��ü�� Ȱ��ȭ�Ǿ��� ��츦 ��Ÿ���ϴ�.
    /// </summary>
    /// <returns></returns>
    public bool IsEnable()
    {
        bool isObjectEnable = gameObject.activeSelf;
        /// gameObject.activeSelf : ������Ʈ�� Ȱ��ȭ ���¸� ��ȯ�մϴ�.

        bool isExist = m_Value > 0.0f;

        return isObjectEnable && isExist;
    }

       /// <summary>
       /// �Ե��� �մϴ�.
       /// </summary>
       /// <returns>���� ���� ��ȯ�մϴ�.</returns>
    public float Eat()
    {
        // ���� ���� ���ٸ� 0 ����
        if(Mathf.Approximately(m_Value, 0.0f))
        {
            return 0.0f;
        }

        float change = Time.deltaTime * 0.1f;
        //m_Value -= change;
        // m_Value ���� change �� ���� ����,
        // �� ����� 0�� 100 ������ ���� �� �� �ֵ��� �մϴ�.
        m_Value = Mathf.Clamp(m_Value - (change * 100), 0.0f, 100.0f);

        return change;
    }

    /// <summary>
    /// �׸��� ������� Ȯ���մϴ�.
    /// </summary>
    private void CheckEmpty()
    {
        // ���� ���� ���
        if (Mathf.Approximately(m_Value, 0.0f))
        {
            // �� �׸� �̹����� �����մϴ�.
            _spriteRenderer.sprite = m_EmptyBowl;
            //GetComponent<SpriteRenderer>().sprite = m_EmptyBowl;
            /// - �� ������ ȿ�������� ���� �ʽ��ϴ�.
            /// - ����, SpriteRenderer ������ ������ ����� ������Ʈ�� ã�� �۾��� 
            ///   �ּ�ȭ �����ִ� ���� �����ϴ�. 

            // �� �׸� ���� �ٲ�� 5���� �̹��� ����
            Invoke("DestroyBowl", 5.0f);
        }
    }

    /// <summary>
    /// �� �׸� ��Ȱ��ȭ �޼���
    /// </summary>
    private void DestroyBowl()
    {
        gameObject.SetActive(false);
    }


}
