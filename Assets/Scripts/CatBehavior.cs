using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 행동 타입을 나타내기 위한 열거 형식
/// </summary>
public enum BehaviorType : sbyte
{
    // 대기 상태
    Idle = 0,

    // 이동 상태
    Move = 1,

    // 열거 형식의 시작, 마지막 값을 나타냅니다.
    // 열거 형식의 범위를 나타내기 위하여 사용됩니다.
    BehaviorFirstValue = Idle,
    BehaviorLastValue = Move
}

public class CatBehavior : MonoBehaviour
{
    // 고양이 객체를 나타냅니다.
    private CatInstance _CatInstance;

    // 현재 설덩된 고양이의 행동을 나타냅니다.
    private BehaviorType _BehaviorType;

    // 다음 행동이 결정될 시간을 나타냅니다.
    private DateTime _NextBevaiorTime;

    private void Start()
    {
        // 이 컴포넌트(CatBehavior) 가 추가된 오브젝트 내에서
        // CatInstance 형식의 컴포넌트를 찾아 _CatInstance 변수에 설정합니다.
        _CatInstance = GetComponent<CatInstance>();
        // GetComponent<Type>() : 이 오브젝트 내에 추가된 Type 과
        // 일치하는 컴포넌트를 찾아 반환합니다.
    }

    private void Update()
    {
        // 행동에 대한 시간을 확인합니다.
        CheckBehaviorTime();
    }

    // 행동에 대한 시간을 확인합니다.
    private void CheckBehaviorTime()
    {
        // 현재 시간을 얻습니다.
        DateTime nowTime = DateTime.Now;

        // 다음 행동을 설정할 시간이 되었다면
        if (nowTime >= _NextBevaiorTime)
        {
            // 새로운 행동을 결정시킵니다.
            PickNewBehavior();

            //다음 행동을 결정할 시간을 설정합니다.
            SetNextBehaviorTime();

        }
    }

    /// <summary>
    /// 새로운 행동을 결정합니다.
    /// </summary>
    private void PickNewBehavior()
    {
        // 랜덤한 행동 값을 얻습니다.
        int randomBehaviorValue = UnityEngine.Random.Range(
            // 행동의 첫 번째 요소
            (int)BehaviorType.BehaviorFirstValue,
           // 행동의 마지막 요소 + 1
           (int)BehaviorType.BehaviorLastValue + 1);

        // 뽑은 행동 타입을 설정합니다.
        _BehaviorType = (BehaviorType)randomBehaviorValue;

        // 고양이 객체에 행동이 설정되었음을 알립니다.
        _CatInstance.OnBehaviorChanged(_BehaviorType);
    }

    /// <summary>
    /// 다음 행동을 결정할 시간을 설정합니다.
    /// </summary>
    private void SetNextBehaviorTime()
    {
        int addMinute = 0;
        int addSecond = 0;

        switch (_BehaviorType)
        {
            case BehaviorType.Idle:
                // 5초에서 10초까지 랜덤한 시간만큼 대기 후, 다음 행동을 설정합니다.
                addSecond = UnityEngine.Random.Range(5, 11);
                break;

            case BehaviorType.Move:
                // 2초에서 5초까지 랜덤한 시간만큼 이동 후, 다음 행동을 설정합니다.
                addSecond = UnityEngine.Random.Range(2, 6);
                break;
        }

        // 다음 행동을 결정시킬 시간을 설정합니다.
        _NextBevaiorTime = DateTime.Now + new TimeSpan(0, addMinute, addSecond);
    }
}
