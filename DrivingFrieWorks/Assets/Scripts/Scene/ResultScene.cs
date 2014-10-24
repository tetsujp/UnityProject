using UnityEngine;
using System.Collections;

public class ResultScene : BasicScene
{

	// Use this for initialization
	void Start () {
	
	}
    public override void Initialize()
    {
    }
    public override void SceneFinalize()
    {

    }
	
	// Update is called once per frame
	void Update () {

        //シーン切り替え
        if (Input.GetButtonDown("Decide"))
        {

            ChangeScene(sceneName.Select);
        }
	}
}
