using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainScene : BasicScene
{
    //曲データ
    //ノートデータ
    public GameObject prefabNoteOwner;
    GameObject noteOwner;
    GameObject scoreManager;
    Transform score;
    //曲をいれておく
    public Dictionary<string, AudioClip> stockMusic = new Dictionary<string, AudioClip>();

	// Use this for initialization
	void Start () {
	}
    override public void Initialize()
    {
        noteOwner=(GameObject)Instantiate(prefabNoteOwner);
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager");
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
        if (Input.GetButtonDown("Stop"))
        {
            noteOwner.GetComponent<NoteOwner>().FinalizeObj();
            ChangeScene(SceneName.Result);
        }
        
	}
}
