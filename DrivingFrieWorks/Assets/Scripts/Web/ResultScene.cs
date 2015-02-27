using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;


public class ResultScene : BasicScene
{
    ScoreManager scoreManager;
    Dictionary<string, Text> resultTextData = new Dictionary<string, Text>();//曲情報、Bpmやこめんとなど
    List<KeyValuePair<double, string>> rankData = new List<KeyValuePair<double, string>>(){
        new KeyValuePair<double,string>(100,"SS"),
        new KeyValuePair<double,string>(95,"S"),
        new KeyValuePair<double,string>(90,"A"),
        new KeyValuePair<double,string>(80,"B"),
        new KeyValuePair<double,string>(70,"C"),
        new KeyValuePair<double,string>(0,"E")
    };
    static int CompareKey(KeyValuePair<double, string> a, KeyValuePair<double, string> b)
    {
        return a.Key.CompareTo(b.Key);
    }
    // Use this for initialization
	void Start () {
        SetDataTable();
	}
    public override void Initialize()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        SetTextTable();

    }
    void SetScore()
    {

    }
    public override void SceneFinalize()
    {
        scoreManager.Finalizer();
    }
	
	// Update is called once per frame
	void Update () {

        //シーン切り替え
        if (Input.GetButtonDown("Decide"))
        {

            ChangeScene(SceneName.Select);
        }
	}
    void SetTextTable()
    {
        //判定数
        resultTextData["ResultJust"].text = scoreManager.GetJudgeScore(JudgeKind.Just).ToString();
        resultTextData["ResultGreat"].text = scoreManager.GetJudgeScore(JudgeKind.Great).ToString();
        resultTextData["ResultGood"].text = scoreManager.GetJudgeScore(JudgeKind.Good).ToString();
        resultTextData["ResultMiss"].text = scoreManager.GetJudgeScore(JudgeKind.Miss).ToString();
        //musicDataTable["HighScore"].text = "Score: "+selectBarList[playCounter].data.;

        double p = scoreManager.percentScore;
        resultTextData["Percent"].text = p<100 ? p.ToString("F1") + "%":"100%";
        //textのセット
        rankData.Sort(CompareKey);
        rankData.Reverse();
        foreach (var rank in rankData)
        {
            if (p >= rank.Key)
            {
                resultTextData["Rank"].text = rank.Value;
                break;
            }
        }
    }
    void SetDataTable()
    {
        var list = gameObject.GetComponentsInChildren<Transform>().Where(c =>c.CompareTag("ResultText")).ToArray();
        foreach (var l in list)
        {
            resultTextData.Add(l.name, l.GetComponent<Text>());
        }
        
    }
}
