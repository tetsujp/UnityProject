using UnityEngine;
using System.Collections;

public enum noteDisplayState { none,now,end };
public class Note : MonoBehaviour
{
//    double bpm;
    public double apperTime{get;set;}//画面内に出る時の時間
    public double judgeTime{get;set;}//Just判定になる時間
//    int line;




    //プレイステータス
    public noteDisplayState displayState{get;set;}

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
