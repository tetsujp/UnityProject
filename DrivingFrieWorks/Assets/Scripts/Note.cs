﻿using UnityEngine;
using System.Collections;

public enum noteDisplayState { none,now,end };
public class Note : MonoBehaviour
{
<<<<<<< HEAD
//    double bpm;
    public double apperTime{get;set;}//画面内に出る時の時間
    public double judgeTime{get;set;}//Just判定になる時間
//    int line;
=======
    double bpm = -1;
    double apperTime = -1;//画面内に出る時の時間
    double judgeTime = -1;//Just判定になる時間
    int line = -1;
>>>>>>> parent of 8734fd1... GameObjectに変更前


    //プレイステータス
    public noteDisplayState displayState{get;set;}
    public double GetApperTime(){return apperTime;}
    public double GetJudgeTime(){return judgeTime;}

    private char c_buf;

    public virtual void Initialize(double j, double b, double a, int l)
    {
        judgeTime = j;
  //      bpm = b;
        apperTime = a;
  //      line = l;
        displayState=noteDisplayState.none;
    }
    //bool JudgeStart(double play_time);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
