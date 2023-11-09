using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
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

    private void Start()
    {
        _Destination = GetRandomPositionInGround();
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
        Vector2 nextPosition = Vector2.MoveTowards(currentPosition,_Destination,m_MoveSpeed * Time.deltaTime);
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
}
