using UnityEngine;
using System.Collections;

public class MainScene : BasicScene
{
    //曲データ
    public GameObject loadPlayMusic;

    //ノートデータ
    public GameObject prefabNoteOwner;
    GameObject noteOwner;
	// Use this for initialization
	void Start () {
	}
    override public void Initialize()
    {
        GameObject play=(GameObject)Instantiate(loadPlayMusic);
        noteOwner=(GameObject)Instantiate(prefabNoteOwner);

        Destroy(play);
    }
    override public void SceneFinalize()
    {
        Destroy(noteOwner);
        gameObject.SetActive(false);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
