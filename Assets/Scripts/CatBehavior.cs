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
    Idle =0,

    // 이동 상태
    Move = 1,

    // 열거 형식의 시작, 마지막 값을 나타냅니다.
    // 열거 형식의 범위를 나타내기 위하여 사용됩니다.
    BehaviorFirstValue = Idle,
    BehaviorLastValue = Move
}

public class CatBehavior : MonoBehaviour
{
    // 현재 설덩된 고양이의 행동을 나타냅니다.
    BehaviorType _BehaviorType;

    // 다음 행동이 결정될 시간을 나타냅니다.
    DateTime _NextBevaiorTime;

    void Update()
    {
        // 행동에 대한 시간을 확인합니다.
        CheckBehaviorTime();
    }

    // 행동에 대한 시간을 확인합니다.
    void CheckBehaviorTime()
    {
        // 현재 시간을 얻습니다.
        DateTime nowTime = DateTime.Now;

        // 다음 행동을 설정할 시간이 되었다면
        if(nowTime >= _NextBevaiorTime)
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

        Debug.Log($"뽑은 행동 : {_BehaviorType}");
    }

    /// <summary>
    /// 다음 행동을 결정할 시간을 설정합니다.
    /// </summary>
    private void SetNextBehaviorTime()
    {

    }
}
