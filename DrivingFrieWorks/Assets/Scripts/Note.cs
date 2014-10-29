using UnityEngine;
using System.Collections;
public class Note : MonoBehaviour
{
    public double apperTime{get;set;}//画面内に出る時の時間
    public double judgeTime{get;set;}//Just判定になる時間
    int line;
    //public double sumTime = 10;//speed*LifeTime
    
    public GameObject[] prefabFlower;

    public GameObject[] hitPosition;


    public virtual void Initialize(double j,double a, int l)
    {
        judgeTime = j;
        apperTime = a;
        line = l;
        //自分の座標を花火が出る点に変更
        transform.position = hitPosition[line].transform.position;
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
        if (kind != JudgeKind.Miss)
        {
            CreateFlower(kind);
        }
        Destroy(gameObject);
    }
    void CreateFlower(JudgeKind kind)
    {
        Instantiate(prefabFlower[(int)kind],transform.position,Quaternion.identity);
    }
    public void StopMove()
    {
        transform.position = hitPosition[line].transform.position;
    }

}
