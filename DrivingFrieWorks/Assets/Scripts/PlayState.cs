using UnityEngine;
using System.Collections;
public enum difficulty { easy, normal, hard, extreme };
public class PlayState : MonoBehaviour {

    public const double MAXSPD = 4.0;//4分
    public const double MINSPD = 0.5;//全音×2
    public const double CHANGESPD = 0.25;

    //プロパティ
    public difficulty diff { get; set; }
    public string selectName { get; set; }
    //public string musicFileName { get; set; }
    public double multspd { get; set; }//画面内に表示する泊数,mult=1で一泊

    public GameObject loadPlayMusic;
    // Use this for initialization
    void Start()
    {

        multspd = 4;
        Instantiate(loadPlayMusic);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
