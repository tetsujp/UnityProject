using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{

    LineNote[] allNoteList;
    float startTime;
    // Use this for initialization
    void Start()
    {
        //ノートデータの取得
        allNoteList = GameObject.FindWithTag("LoadPlayMusic").GetComponent<LoadPlayMusic>().GetAllNoteList();

        startTime = Time.time;
        StartCoroutine("noteDisplay");
    }

    // Update is called once per frame
    void Update()
    {

    }

    //画面に内に出す判定
    //コルーチンで実装
    public float displayInterval = 0.01f;//ループ時間10ms
    IEnumerator noteDisplay()
    {
        while (true)
        {
            //float nowTime = Time.time;

            foreach(var list in allNoteList){
                list.UpdateDisplay(startTime);
            }
            yield return new WaitForSeconds(displayInterval);
        }
    }
}