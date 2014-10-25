using UnityEngine;
using System.Collections;
public class Note : MonoBehaviour
{
    double bpm;
    public double apperTime{get;set;}//画面内に出る時の時間
    public double judgeTime{get;set;}//Just判定になる時間
    int line;
    public GameObject[] startPosition;
    public double sumTime = 10;//speed*LifeTime
    
    public GameObject prefabFlower;



    public virtual void Initialize(double j, double b, double a, int l)
    {
        judgeTime = j;
        bpm = b;
        apperTime = a;
        line = l;
        transform.position = startPosition[line].transform.position;

        //画面に表示されている時間
        double inDisplayTime = judgeTime - apperTime;
        //パーティクルの設定
        ParticleSystem particle = gameObject.GetComponentInChildren<ParticleSystem>();
        particle.startLifetime=(float)inDisplayTime;
        particle.startSpeed = (float)sumTime / particle.startLifetime;
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hit(JudgeKind kind)
    {
        CreateFlower(kind);
    }
    void CreateFlower(JudgeKind kind)
    {
        Instantiate(prefabFlower,transform.position,Quaternion.identity);
    }

}
