using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{

    LineNote[] allNoteList;
    float startTime;
    AudioSource playMusic;
    public float delayTime=0;//曲の再生開始を遅らせる
    // Use this for initialization
    void Start()
    {
        //ノートデータの取得
        allNoteList = GameObject.FindWithTag("LoadPlayMusic").GetComponent<LoadPlayMusic>().GetAllNoteList();

        //曲の再生
        playMusic = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        playMusic.PlayDelayed(delayTime);

        startTime = Time.time;
        StartCoroutine("NoteDisplay");
        //StartCoroutine("CheckHit");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
    }

    //画面に内に出す判定
    //コルーチンで実装
    public float displayInterval = 0.01f;//ループ時間10ms
    IEnumerator NoteDisplay()
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
    //入力をコルーチンで行えない
    //public float hitInterval = 0.01f;
    //IEnumerator CheckHit()
    //{
    //    while (true)
    //    {
    //        //入力
    //        foreach (var list in allNoteList)
    //        {
    //            list.CheckHit(startTime);
    //        }
    //            yield return new WaitForSeconds(hitInterval);
    //    }
    //}
    void CheckHit()
    {
            //入力
            foreach (var list in allNoteList)
            {
                list.CheckHit(startTime);
            }
    }
}