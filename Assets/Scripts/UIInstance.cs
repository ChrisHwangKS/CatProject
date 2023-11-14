using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInstance : MonoBehaviour
{
    /// <summary>
    /// 밥주기 버튼
    /// </summary>
    public Button m_FeedButton;

    /// <summary>
    /// 밥그릇 객체
    /// </summary>
    public BowlInstance m_BowlInstance;

    private void Awake()
    {
        // 밥 주기 버튼 클릭 이벤트를 설정합니다.
        m_FeedButton.onClick.AddListener(OnFeedButtonClicked);
        /// - OnClick : 버튼 클릭 이벤트를 나타냅니다.
        /// - AddListener() : 지정한 메서드를 등록합니다.
    }

    /// <summary>
    /// 밥주기 버튼이 클릭되었을 경우 호출하는 메서드입니다.
    /// </summary>
    private void OnFeedButtonClicked()
    {
        // 그릇 객체를 활성화 시킵니다.
        m_BowlInstance.EnableBowl();
    }
}
