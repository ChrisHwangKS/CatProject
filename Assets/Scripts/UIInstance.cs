using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIInstance : MonoBehaviour
{
    /// <summary>
    /// ���ֱ� ��ư
    /// </summary>
    public Button m_FeedButton;

    /// <summary>
    /// ��׸� ��ü
    /// </summary>
    public BowlInstance m_BowlInstance;

    private void Awake()
    {
        // �� �ֱ� ��ư Ŭ�� �̺�Ʈ�� �����մϴ�.
        m_FeedButton.onClick.AddListener(OnFeedButtonClicked);
        /// - OnClick : ��ư Ŭ�� �̺�Ʈ�� ��Ÿ���ϴ�.
        /// - AddListener() : ������ �޼��带 ����մϴ�.
    }

    /// <summary>
    /// ���ֱ� ��ư�� Ŭ���Ǿ��� ��� ȣ���ϴ� �޼����Դϴ�.
    /// </summary>
    private void OnFeedButtonClicked()
    {
        // �׸� ��ü�� Ȱ��ȭ ��ŵ�ϴ�.
        m_BowlInstance.EnableBowl();
    }
}
