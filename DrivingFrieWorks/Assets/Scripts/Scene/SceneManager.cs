using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
public enum SceneName { Title,Select,Main,Result,NUM};
public class SceneManager : MonoBehaviour {

	// Use this for initialization
    //mapでの実装のほうが良い
    List<GameObject> sceneList = new List<GameObject>();

    void Start () {
	//Sceneを検索して登録
        for(int i=0;i<(int)SceneName.NUM;i++){
            string sceneN=((SceneName)i).ToString()+"Scene";
            sceneList.Add(GameObject.FindWithTag(sceneN));
        }
        //title以外をfalse
        var list = from l in sceneList
                   where l.CompareTag("TitleScene") != true
                   select l;
        foreach (var l in list)
        {
            l.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeScene(SceneName s)
    {
        //シーン切り替え
        sceneList[(int)s].SetActive(true);
        sceneList[(int)s].GetComponent<BasicScene>().Initialize();
    }
}
