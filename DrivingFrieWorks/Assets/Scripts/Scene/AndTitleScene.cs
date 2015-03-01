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
        IT_Gesture.onMultiTapE += OnTouchDown;
    }
    void SceneFinalize()
    {
        IT_Gesture.onMultiTapE -= OnTouchDown;
    }

    void OnTouchDown(Tap tap)
    {
        Application.LoadLevel("SelectScene");
        //ChangeScene(SceneName.Select);
    }
}