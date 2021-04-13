//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using PlayFab;
//using PlayFab.ServerModels;
//using UniRx.Async;

//public interface IGetTime
//{
//    UniTask<DateTime?> GetTimeTask();
//}

//public class GetTime_PlayFab : IGetTime
//{
//    bool finishedGetTime;
//    DateTime? now;
//    public async UniTask<DateTime?> GetTimeTask()
//    {
//        now = null;
//        finishedGetTime = false;
//        GetCurrentTime();
//        await UniTask.WaitWhile(() => finishedGetTime == false);
//        return now;
//    }

//    void GetCurrentTime()
//    {
//        PlayFabServerAPI.GetTime(new GetTimeRequest(), OnGetTimeSuccess, LogFailure);
//    }
//    void OnGetTimeSuccess(GetTimeResult result)
//    {
//        now = result.Time;
//        finishedGetTime = true;
//    }
//    void LogFailure(PlayFabError error)
//    {
//        Debug.Log("There was a problem getting the time. Error: " + error.GenerateErrorReport());
//        //nowはnullのまま
//        finishedGetTime = true;
//    }
//}

//public class GetTime_Default : IGetTime
//{
//    public async UniTask<DateTime?> GetTimeTask()
//    {
//        DateTime? now = DateTime.Now;
//        await UniTask.DelayFrame(1);
//        return now;
//    }
//}