//using System.Collections;
//using System.Collections.Generic;
//using System;
//using UnityEngine;
//using static BASE;
//using UniRx.Async;

//public class TimeManager : MonoBehaviour
//{
//    DateTime LastRealTime { get => DateTime.FromBinary(Convert.ToInt64(main.S.lastRealTimeOnServer)); set => main.S.lastRealTimeOnServer = value.ToBinary().ToString(); }
//    DateTime LastLocalTimeWhenSync { get => DateTime.FromBinary(Convert.ToInt64(main.S.dateTimeWhenLastSync)); set => main.S.dateTimeWhenLastSync = value.ToBinary().ToString(); }
//    DateTime LastLocalTime { get => DateTime.FromBinary(Convert.ToInt64(main.S.lastLocalTime)); set => main.S.lastLocalTime = value.ToBinary().ToString(); }
//    double TimeLag { get => (LastRealTime - LastLocalTimeWhenSync).TotalSeconds; }
//    bool Initialized { get => main.S.initialized_server_time; set => main.S.initialized_server_time = value; }
//    IGetTime timeGetter_fromServer = new GetTime_PlayFab();

//    /// <summary>
//    /// 現在のDatetime
//    /// </summary>
//    public DateTime CurrentDateTime()
//    {
//        return LastLocalTime.AddSeconds(TimeLag);
//    }

//    /// <summary>
//    /// 時間をサーバーと同期させる処理。たまに呼ぶだけでいい。
//    /// </summary>
//    public void ApplyCurrentDate()
//    {
//        var task = _ApplyCurrentDate();
//    }

//    async UniTask _ApplyCurrentDate()
//    {
//        var task = timeGetter_fromServer.GetTimeTask();
//        await task;
//        //Debug.Log((task.Result - LastRealTime).TotalSeconds + "秒の間で、差は " + (task.Result - CurrentDateTime()).TotalSeconds);
//        DateTime? current_server_time = task.Result;
//        if (current_server_time == null) { return; }
//        LastRealTime = (DateTime)current_server_time;
//        LastLocalTimeWhenSync = DateTime.Now;
//        LastLocalTime = DateTime.Now;
//    }

//    //　一度だけ呼ばれることになる
//    void Initialize()
//    {
//        if (Initialized) { return; }
//        Initialized = true;
//        LastRealTime = DateTime.Now;
//        LastLocalTimeWhenSync = DateTime.Now;
//        LastLocalTime = DateTime.Now;
//        ApplyCurrentDate();
//    }

//    private void Awake()
//    {
//        Initialize();
//    }

//    private void Start()
//    {
//        ApplyCurrentDate();
//        StartCoroutine(SaveTime());
//    }

//    readonly float _interval = 1.0f;
//    IEnumerator SaveTime()
//    {
//        while (true)
//        {
//            double span = (DateTime.Now - LastLocalTime).TotalSeconds;
//            if ((span >= 10f) || (span <= -10f)) //　不正チェック
//            {
//                //timeのずれの分lastLocaltimeもずらす
//                LastLocalTimeWhenSync = LastLocalTimeWhenSync.AddSeconds(span - _interval);
//            }

//            LastLocalTime = DateTime.Now;
//            yield return new WaitForSecondsRealtime(_interval);
//        }
//    }
//}
