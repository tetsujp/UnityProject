using UnityEngine;
using System.Collections;

public class MainScene : BasicScene
{
    //曲データ

    //ノートデータ
    public GameObject prefabNoteOwner;
    GameObject noteOwner;
	// Use this for initialization
	void Start () {
	}
    override public void Initialize()
    {
        noteOwner=(GameObject)Instantiate(prefabNoteOwner);
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
            ChangeScene(sceneName.Result);
        }

	}
}
