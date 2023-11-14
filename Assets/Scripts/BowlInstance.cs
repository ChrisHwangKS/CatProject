using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlInstance : MonoBehaviour
{
    // 밥 수치를 나타냅니다.
    public float m_Value;

    public Transform m_ValueBarPivot;

    private void Awake()
    {
        // 오브젝트를 비활성화 시킵니다.
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
    /// 그릇 객체를 활성화 시킵니다.
    /// </summary>
    public void EnableBowl()
    {
        m_Value = 100.0f;

        // 오브젝트를 활성화 시킵니다.
        gameObject.SetActive(true);
    }
}
