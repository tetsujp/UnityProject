using UnityEngine;
using System.Collections;

public class SingleNote : Note {

    public GameObject[] highPosition;
    public GameObject lowPosition;
    Transform high;
    Transform low;
    public Color[] startHighColor;
    public Color[] startLowColor;

    public override void Initialize(double judgeTime,double apperTime, int line)
    {
        base.Initialize(judgeTime, apperTime, line);
        float[] JUDGE_TIME=GameObject.FindGameObjectWithTag("LineNote").GetComponent<LineNote>().JUDGE_TIME;

        //自分の座標を花火が出る点に変更
        transform.position = hitPosition[line].transform.position;
        startPostion = transform;

        //子要素の取得
        high = gameObject.transform.FindChild("High");
        low = gameObject.transform.FindChild("Low");
        high.position = highPosition[line].transform.position;
        low.position=lowPosition.transform.position;

        //画面に表示されている時間
        double inDisplayTime = judgeTime - apperTime;

        //パーティクルの設定
        //ParticleSystem particle = gameObject.GetComponentsInChildren<ParticleSystem>();
        //particle.startLifetime = (float)inDisplayTime;
        // 移動する距離を求める
        Vector3 distance = hitPosition[line].transform.position - highPosition[line].transform.position;
        high.rigidbody.velocity = new Vector3(distance.x / (float)inDisplayTime, distance.y / (float)inDisplayTime, distance.z / (float)inDisplayTime);
        high.LookAt(hitPosition[line].transform);

        Vector3 distance2 = hitPosition[line].transform.position - lowPosition.transform.position;
        low.rigidbody.velocity = new Vector3(distance2.x / (float)inDisplayTime, distance2.y / (float)inDisplayTime, distance2.z / (float)inDisplayTime);
        low.FindChild("Tail").rigidbody.velocity = new Vector3(distance2.normalized.x,distance2.normalized.y);

        //particle.startSpeed = (float)sumTime / particle.startLifetime;
        high.GetComponent<ParticleSystem>().startLifetime = (float)inDisplayTime + JUDGE_TIME[(int)JudgeKind.Good];
        high.GetComponent<ParticleSystem>().startColor = startHighColor[-Mathf.Abs(line-2)+2];
        low.GetComponent<ParticleSystem>().startLifetime = (float)inDisplayTime+JUDGE_TIME[(int)JudgeKind.Good];
        low.GetComponent<ParticleSystem>().startColor = startLowColor[-Mathf.Abs(line - 2) + 2];
    }
    public override void StopMove()
    {
        high.rigidbody.velocity = Vector3.zero;
        low.rigidbody.velocity = Vector3.zero;
    }
}
