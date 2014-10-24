using UnityEngine;
using System.Collections;

public class TitleScene :  BasicScene
{

	// Use this for initialization
	void Start () {

        Initialize();
	}
    public override void Initialize()
    {
        
    }
    public override void SceneFinalize()
    {
        
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Decide"))
        {
            //曲選択画面へ

            ChangeScene(sceneName.Select);
        }
	}
}
