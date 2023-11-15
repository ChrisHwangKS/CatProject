using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 수평 방향을 나타내기 위한 열거 형식
/// </summary>
public enum HorizontalDirection : sbyte
{
    // 왼쪽 방향
    Left,

    // 오른쪽 방향
    Right
}



public class CatMovement : MonoBehaviour
{
    /// <summary>
    /// 고양이 객체를 나타냅니다.
    /// </summary>
    private CatInstance _CatInstance;

    /// <summary>
    /// 고양이의 방향을 나타냅니다.
    /// </summary>
    private HorizontalDirection _Direction = HorizontalDirection.Right;

    /// <summary>
    /// 맵의 반지름을 나타냅니다.
    /// </summary>
    public float m_Radius;

    /// <summary>
    /// 목적지를 나타냅니다.
    /// 고양이는 이 위치를 향해 이동합니다.
    /// </summary>
    private Vector2 _Destination;

    /// <summary>
    /// 고양이의 이동 속력을 나타냅니다.
    /// </summary>
    public float m_MoveSpeed;

    /// <summary>
    /// 목표 위치에 도달했을 경우 이동을 계속하도록 허용할 것인지에 대한 여부
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
        // 현재 고양이 오브젝트의 위치를 얻습니다.
        Vector2 currentPosition = transform.position;

        // 다음 위치를 얻습니다.
        Vector2 nextPosition = Vector2.MoveTowards(currentPosition, _Destination, m_MoveSpeed * Time.deltaTime);
        // Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        // - 목표 위치로 maxDistanceDelta 만큼 이동시킨 결과를 반환합니다.
        // - current : 현재 위치를 전달합니다.
        // - target : 목표 위치를 전달합니다.
        // - maxDistanceDelta : 목표 위치 이동까지 사용될 속력을 전달합니다.
        //
        // Time.deltaTime : 이전 프레임과 현재 프레임 사이의 시간 간격을 나타냅니다.
        // 환경이 다른 PC에서도 실행 결과가 동일하도록 하기 위해 연산됩니다.

        // 목표 위치로 이동시킵니다.
        transform.position = nextPosition;

        // 현재 위치를 얻습니다.
        // Vector2 currentPosition = transform.position;
        // Vector2 : 2차원 공간 내에 위치한 점을 나타내기 위한 방식
        // 멤버는 X 와 Y 로 구성되어 있습니다.
        // transform : 오브젝트에 기본적으로 추가되는 Transform 컴포넌트를 나타냅니다.
        // position  : Transform 컴포넌트의 position 속성을 나타냅니다.
        //             절대 위치(월드 위치)를 나타냅니다.

        //currentPosition.x += 0.1f;
        //transform.position = currentPosition;

        if (_AllowKeepMoving)
        {
            // 목표 지점에 거의 도달했다면
            bool isFinished = Vector2.Distance(currentPosition, _Destination) < 0.001f;
            if (isFinished)
            {
                // 새로운 목적지로 이동시킵니다.
                StartMovement();
            }
        }
    }

    /// <summary>
    /// 땅 영역 내부의 랜덤한 위치를 반환합니다.
    /// 랜덤 이동 목표 지점을 설정하기 위하여 사용됩니다.
    /// </summary>
    /// <returns>랜덤한 위치가 반환됩니다.</returns>
    private Vector2 GetRandomPositionInGround()
    {
        float randomX = Random.Range(-1.0f, 1.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        // Random.Range(float min, float max) : (min ~ max) 값을 반환합니다.
        // Random.Range(int min, int max) : (min ~ (max - 1)) 값을 반환합니다.

        Vector2 newDirection = new Vector2(randomX, randomY);
        newDirection.Normalize();
        // Vector2 객체.normalized : 벡터의 길이를 1로 변환한 결과를 반환
        // Vector2 객체.Normalize() : 벡터의 길이를 1로 변환합니다.

        // 각 축 값에 반지름을 곱하여 원 안의 위치를 반환합니다.
        return newDirection * m_Radius;
    }

    /// <summary>
    /// 이동을 멈추도록 지시합니다.
    /// </summary>
    private void StopMovement()
    {
        // 계속된 이동 허용 X
        _AllowKeepMoving = false;

        // 현재 위치를 얻습니다.
        Vector2 currentPosition = transform.position;
        
        // 현재 고양이의 위치를 목적지로 설정하여 이동을 멈춥니다.
        _Destination = currentPosition;
    }

    /// <summary>
    /// 이동을 시작하도록 지시합니다.
    /// </summary>
    private void StartMovement()
    {
        // 계속된 이동 허용
        _AllowKeepMoving = true;

        // 밥먹기 위한 조건식을 작성하기 위한 변수들
        bool isHungry = _CatInstance.m_IsHungry;
        bool bowlIsEnable = _CatInstance.GetBowlInstance().IsEnable();

        // 그릇 위치
        Vector2 bowlPosition = _CatInstance.GetBowlInstance().transform.position;

        // 목적지를 설정합니다.
        _Destination = (isHungry && bowlIsEnable)?  // 배가 고프며, 그릇이 활성화된 경우
            bowlPosition :                          // 목적지를 그릇 위치로 설정
            GetRandomPositionInGround();            // 아니라면 랜덤한 위치를 설정

        // 현재 위치를 얻습니다.
        Vector2 currentPosition = transform.position;

        // 목적지로 향하는 방향을 얻습니다.
        Vector2 directionVector = (_Destination - currentPosition).normalized;

        // 목적지에 대한 방향을 얻습니다.
        HorizontalDirection direction = 
            // 방향의 x 축 값이 양수라면 (오른쪽 방향이라면)
            ((directionVector.x) > 0.0f) ?
            // 방향을 오른쪽으로 설정
            HorizontalDirection.Right: 
            // 방향을 왼쪽으로 설정
            HorizontalDirection.Left;

        // 이전 방향과 다른 방향으로 이동하는 경우
        if (direction != _Direction)
        {
            // 방향을 전환하며 고양이 객체에 알립니다.
            _Direction = direction;

            _CatInstance.OnDirectionChanged(_Direction);
        }
    }

    /// <summary>
    /// 행동이 변경되었을 경우 CatInstance 에서 호출됩니다.
    /// </summary>
    /// <param name="behaviorType">설정된 행동이 전달됩니다.</param>
    public void OnBehaviorChanged(BehaviorType behaviorType)
    {
        switch (behaviorType)
        {
            case BehaviorType.Idle:
                // 이동 중단
                StopMovement();
                break;

            case BehaviorType.Move:
                // 이동 시작
                StartMovement();
                break;
        }
    }
}
