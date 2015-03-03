using UnityEngine;
using System.Collections;

public class AndTitleScene : MonoBehaviour{


    // Use this for initialization
    void Start()
    {
        Initialize();
    }
    void Initialize()
    {
    }
    void SceneFinalize()
    {
    }

    public void OnTouchDown()
    {
        Application.LoadLevel("SelectScene");
        //ChangeScene(SceneName.Select);
    }
}