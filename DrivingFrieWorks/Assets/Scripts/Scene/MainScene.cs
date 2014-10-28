using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScene : BasicScene
{
    //曲データ
    //ノートデータ
    public GameObject prefabNoteOwner;
    GameObject noteOwner;
    ScoreManager scoreManager;
    Transform score;
	// Use this for initialization
	void Start () {
	}
    override public void Initialize()
    {
        noteOwner=(GameObject)Instantiate(prefabNoteOwner);
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        score = transform.FindChild("Canvas").transform.FindChild("Score");
    }
    override public void SceneFinalize()
    {
        Destroy(noteOwner);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {

        //曲の終了
        if (noteOwner.GetComponent<NoteOwner>().IsEnd())
        {
            noteOwner.GetComponent<NoteOwner>().FinalizeObj();
            ChangeScene(SceneName.Result);
        }
        SetScore();
	}
    void SetScore()
    {
        double s=scoreManager.percentScore;
        if (s < 100) score.GetComponent<Text>().text = s.ToString("F1");
        else score.GetComponent<Text>().text = "100";
    }
}
