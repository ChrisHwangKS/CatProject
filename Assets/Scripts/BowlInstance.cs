using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO 밥이 없는 경우 5초 후 사라지도록 해야 합니다. 


public class BowlInstance : MonoBehaviour
{
    private const int TURNOFFSECOND = 5000;

    // 빈 그릇 스프라이트를 나타냅니다.
    public Sprite m_EmptyBowl;

    // 채워진 밥그릇 스프라이트를 나타냅니다.
    public Sprite m_FeedBowl;

    // 밥 수치를 나타냅니다.
    public float m_Value;

    public Transform m_ValueBarPivot;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();


        // 오브젝트를 비활성화 시킵니다.
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
    /// 그릇 객체를 활성화 시킵니다.
    /// </summary>
    public void EnableBowl()
    {
        m_Value = 100.0f;

        // 오브젝트를 활성화 시킵니다.
        gameObject.SetActive(true);

        // SpriteRenderer 컴포넌트를 찾고, 스프라이트 이미지를 설정합니다.
        //GetComponent<SpriteRenderer>().sprite = m_FeedBowl;
        _spriteRenderer.sprite = m_FeedBowl;
    }

    /// <summary>
    /// 그릇 객체가 활성화되었을 경우를 나타냅니다.
    /// </summary>
    /// <returns></returns>
    public bool IsEnable()
    {
        bool isObjectEnable = gameObject.activeSelf;
        /// gameObject.activeSelf : 오브젝트의 활성화 상태를 반환합니다.

        bool isExist = m_Value > 0.0f;

        return isObjectEnable && isExist;
    }

       /// <summary>
       /// 먹도록 합니다.
       /// </summary>
       /// <returns>먹은 양을 반환합니다.</returns>
    public float Eat()
    {
        // 남은 밥이 없다면 0 리턴
        if(Mathf.Approximately(m_Value, 0.0f))
        {
            return 0.0f;
        }

        float change = Time.deltaTime * 0.1f;
        //m_Value -= change;
        // m_Value 에서 change 의 값을 빼고,
        // 그 결과가 0과 100 사이의 값이 될 수 있도록 합니다.
        m_Value = Mathf.Clamp(m_Value - (change * 100), 0.0f, 100.0f);

        return change;
    }

    /// <summary>
    /// 그릇이 비었음을 확인합니다.
    /// </summary>
    private void CheckEmpty()
    {
        // 밥이 없을 경우
        if (Mathf.Approximately(m_Value, 0.0f))
        {
            // 빈 그릇 이미지로 설정합니다.
            _spriteRenderer.sprite = m_EmptyBowl;
            //GetComponent<SpriteRenderer>().sprite = m_EmptyBowl;
            /// - 이 구문은 효율적으로 좋지 않습니다.
            /// - 추후, SpriteRenderer 형식의 변수를 만들고 컴포넌트를 찾는 작업을 
            ///   최소화 시켜주는 것이 좋습니다. 

            // 빈 그릇 으로 바뀌고 5초후 이미지 삭제
            Invoke("DestroyBowl", 5.0f);
        }
    }

    /// <summary>
    /// 밥 그릇 비활성화 메서드
    /// </summary>
    private void DestroyBowl()
    {
        gameObject.SetActive(false);
    }


}
