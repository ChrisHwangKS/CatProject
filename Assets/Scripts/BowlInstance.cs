using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlInstance : MonoBehaviour
{
    // �� ��ġ�� ��Ÿ���ϴ�.
    public float m_Value;

    public Transform m_ValueBarPivot;

    private void Awake()
    {
        // ������Ʈ�� ��Ȱ��ȭ ��ŵ�ϴ�.
        gameObject.SetActive(false);
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
    }

    /// <summary>
    /// �׸� ��ü�� Ȱ��ȭ ��ŵ�ϴ�.
    /// </summary>
    public void EnableBowl()
    {
        m_Value = 100.0f;

        // ������Ʈ�� Ȱ��ȭ ��ŵ�ϴ�.
        gameObject.SetActive(true);
    }
}
