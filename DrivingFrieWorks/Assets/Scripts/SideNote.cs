using UnityEngine;
using System.Collections;

public class SideNote : Note {

	// Use this for initialization
    Transform[] child;
    public override void Initialize(double judgeTime, double apperTime, int line)
    {
        base.Initialize(judgeTime, apperTime, line);
        //float[] JUDGE_TIME = GameObject.FindGameObjectWithTag("LineNote").GetComponent<LineNote>().JUDGE_TIME;
        //自分の座標を花火が出る点に変更
        transform.position = hitPosition[line-(int)LineName.KeyLeftLeft].transform.position;
        startPostion = transform;

        //子オブジェクト
        child = new Transform[5];
        child[0] = gameObject.transform.FindChild("LeftUp");
        child[1] = gameObject.transform.FindChild("RightUp");
        child[2] = gameObject.transform.FindChild("RightDown");
        child[3] = gameObject.transform.FindChild("LeftDown");
        child[4] = gameObject.transform.FindChild("Down");
        //画面に表示されている時間
        double inDisplayTime = judgeTime - apperTime;
       
        //パーティクルの設定
        ParticleSystem[] particle = gameObject.GetComponentsInChildren<ParticleSystem>();
        foreach(var par in particle){
            par.startLifetime = (float)inDisplayTime;
        }

            // 移動する距離を求める   
        foreach(var chi in child){
            Vector3 distance = hitPosition[line - (int)LineName.KeyLeftLeft].transform.position - chi.transform.position;
        chi.rigidbody.velocity = new Vector3(distance.x / (float)inDisplayTime, distance.y / (float)inDisplayTime, distance.z / (float)inDisplayTime);
        //if (chi.name == child[4].name)
        //{
        //    chi.FindChild("Tail").rigidbody.velocity = new Vector3(distance.normalized.x, distance.normalized.y);
        //}
            //chi.LookAt(hitPosition[line].transform);
        }
    }
    public override void StopMove()
    {
        foreach (var chi in child)
        {
            chi.rigidbody.velocity = Vector3.zero;
        }
    }
}
