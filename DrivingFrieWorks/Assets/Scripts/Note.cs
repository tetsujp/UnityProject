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
    protected Transform startPostion;
    protected Transform justAnimation;
    MainCamera camera;

    public virtual void Initialize(double j,double a, int l)
    {
        judgeTime = j;
        apperTime = a;
        line = l;
        justAnimation = gameObject.transform.FindChild("JustAnimation");
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent <MainCamera>();
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
            if (line == (int)LineName.KeyLeftLeft || line == (int)LineName.KeyRightRight)
            {
                camera.SetRotate((LineName)line);
            }
            CreateFlower(kind);
        }
        Destroy(gameObject);
    }
    void CreateFlower(JudgeKind kind)
    {
        Instantiate(prefabFlower[(int)kind],transform.position,Quaternion.identity);
    }
    public virtual void StopMove()
    {
    }
    public void StartJustAnimation()
    {

    }

}
