using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ������ ��Ÿ���� ���� ���� ����
/// </summary>
public enum HorizontalDirection : sbyte
{
    // ���� ����
    Left,

    // ������ ����
    Right
}



public class CatMovement : MonoBehaviour
{
    /// <summary>
    /// ����� ��ü�� ��Ÿ���ϴ�.
    /// </summary>
    private CatInstance _CatInstance;

    /// <summary>
    /// ������� ������ ��Ÿ���ϴ�.
    /// </summary>
    private HorizontalDirection _Direction = HorizontalDirection.Right;

    /// <summary>
    /// ���� �������� ��Ÿ���ϴ�.
    /// </summary>
    public float m_Radius;

    /// <summary>
    /// �������� ��Ÿ���ϴ�.
    /// ����̴� �� ��ġ�� ���� �̵��մϴ�.
    /// </summary>
    private Vector2 _Destination;

    /// <summary>
    /// ������� �̵� �ӷ��� ��Ÿ���ϴ�.
    /// </summary>
    public float m_MoveSpeed;

    /// <summary>
    /// ��ǥ ��ġ�� �������� ��� �̵��� ����ϵ��� ����� �������� ���� ����
    /// </summary>
    private bool _AllowKeepMoving;

    private void Start()
    {
        _CatInstance = GetComponent<CatInstance>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        // ���� ����� ������Ʈ�� ��ġ�� ����ϴ�.
        Vector2 currentPosition = transform.position;

        // ���� ��ġ�� ����ϴ�.
        Vector2 nextPosition = Vector2.MoveTowards(currentPosition, _Destination, m_MoveSpeed * Time.deltaTime);
        // Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        // - ��ǥ ��ġ�� maxDistanceDelta ��ŭ �̵���Ų ����� ��ȯ�մϴ�.
        // - current : ���� ��ġ�� �����մϴ�.
        // - target : ��ǥ ��ġ�� �����մϴ�.
        // - maxDistanceDelta : ��ǥ ��ġ �̵����� ���� �ӷ��� �����մϴ�.
        //
        // Time.deltaTime : ���� �����Ӱ� ���� ������ ������ �ð� ������ ��Ÿ���ϴ�.
        // ȯ���� �ٸ� PC������ ���� ����� �����ϵ��� �ϱ� ���� ����˴ϴ�.

        // ��ǥ ��ġ�� �̵���ŵ�ϴ�.
        transform.position = nextPosition;

        // ���� ��ġ�� ����ϴ�.
        // Vector2 currentPosition = transform.position;
        // Vector2 : 2���� ���� ���� ��ġ�� ���� ��Ÿ���� ���� ���
        // ����� X �� Y �� �����Ǿ� �ֽ��ϴ�.
        // transform : ������Ʈ�� �⺻������ �߰��Ǵ� Transform ������Ʈ�� ��Ÿ���ϴ�.
        // position  : Transform ������Ʈ�� position �Ӽ��� ��Ÿ���ϴ�.
        //             ���� ��ġ(���� ��ġ)�� ��Ÿ���ϴ�.

        //currentPosition.x += 0.1f;
        //transform.position = currentPosition;

        if (_AllowKeepMoving)
        {
            // ��ǥ ������ ���� �����ߴٸ�
            bool isFinished = Vector2.Distance(currentPosition, _Destination) < 0.001f;
            if (isFinished)
            {
                // ���ο� �������� �̵���ŵ�ϴ�.
                StartMovement();
            }
        }
    }

    /// <summary>
    /// �� ���� ������ ������ ��ġ�� ��ȯ�մϴ�.
    /// ���� �̵� ��ǥ ������ �����ϱ� ���Ͽ� ���˴ϴ�.
    /// </summary>
    /// <returns>������ ��ġ�� ��ȯ�˴ϴ�.</returns>
    private Vector2 GetRandomPositionInGround()
    {
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        // Random.Range(float min, float max) : (min ~ max) ���� ��ȯ�մϴ�.
        // Random.Range(int min, int max) : (min ~ (max - 1)) ���� ��ȯ�մϴ�.

        Vector2 newDirection = new Vector2(randomX, randomY);
        newDirection.Normalize();
        // Vector2 ��ü.normalized : ������ ���̸� 1�� ��ȯ�� ����� ��ȯ
        // Vector2 ��ü.Normalize() : ������ ���̸� 1�� ��ȯ�մϴ�.

        // �� �� ���� �������� ���Ͽ� �� ���� ��ġ�� ��ȯ�մϴ�.
        return newDirection * m_Radius;
    }

    /// <summary>
    /// �̵��� ���ߵ��� �����մϴ�.
    /// </summary>
    private void StopMovement()
    {
        // ��ӵ� �̵� ��� X
        _AllowKeepMoving = false;

        // ���� ��ġ�� ����ϴ�.
        Vector2 currentPosition = transform.position;
        
        // ���� ������� ��ġ�� �������� �����Ͽ� �̵��� ����ϴ�.
        _Destination = currentPosition;
    }

    /// <summary>
    /// �̵��� �����ϵ��� �����մϴ�.
    /// </summary>
    private void StartMovement()
    {
        // ��ӵ� �̵� ���
        _AllowKeepMoving = true;

        // ��Ա� ���� ���ǽ��� �ۼ��ϱ� ���� ������
        bool isHungry = _CatInstance.m_IsHungry;
        bool bowlIsEnable = _CatInstance.GetBowlInstance().IsEnable();

        // �׸� ��ġ
        Vector2 bowlPosition = _CatInstance.GetBowlInstance().transform.position;

        // �������� �����մϴ�.
        _Destination = (isHungry && bowlIsEnable)?  // �谡 ������, �׸��� Ȱ��ȭ�� ���
            bowlPosition :                          // �������� �׸� ��ġ�� ����
            GetRandomPositionInGround();            // �ƴ϶�� ������ ��ġ�� ����

        // ���� ��ġ�� ����ϴ�.
        Vector2 currentPosition = transform.position;

        // �������� ���ϴ� ������ ����ϴ�.
        Vector2 directionVector = (_Destination - currentPosition).normalized;

        // �������� ���� ������ ����ϴ�.
        HorizontalDirection direction = 
            // ������ x �� ���� ������ (������ �����̶��)
            ((directionVector.x) > 0.0f) ?
            // ������ ���������� ����
            HorizontalDirection.Right: 
            // ������ �������� ����
            HorizontalDirection.Left;

        // ���� ����� �ٸ� �������� �̵��ϴ� ���
        if (direction != _Direction)
        {
            // ������ ��ȯ�ϸ� ����� ��ü�� �˸��ϴ�.
            _Direction = direction;

            _CatInstance.OnDirectionChanged(_Direction);
        }
    }

    /// <summary>
    /// �ൿ�� ����Ǿ��� ��� CatInstance ���� ȣ��˴ϴ�.
    /// </summary>
    /// <param name="behaviorType">������ �ൿ�� ���޵˴ϴ�.</param>
    public void OnBehaviorChanged(BehaviorType behaviorType)
    {
        switch (behaviorType)
        {
            case BehaviorType.Idle:
                // �̵� �ߴ�
                StopMovement();
                break;

            case BehaviorType.Move:
                // �̵� ����
                StartMovement();
                break;
        }
    }
}
