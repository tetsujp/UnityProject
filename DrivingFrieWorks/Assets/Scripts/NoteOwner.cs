using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{

    LineNote[] allNoteList;
    float startTime;
    double endTime;
    AudioSource playMusic;

    // Use this for initialization
    void Start()
    {
        //ノートデータの取得
        LoadPlayMusic playMusicScript = GameObject.FindWithTag("LoadPlayMusic").GetComponent<LoadPlayMusic>();
        allNoteList = playMusicScript.GetAllNoteList();
        float delayTime = playMusicScript.delayEmptyTime;
        endTime = playMusicScript.endTime;
        //曲の再生
        playMusic = GameObject.FindWithTag("Music").GetComponent<AudioSource>();
        //曲の先頭に空白をつける
        playMusic.PlayDelayed(delayTime);

        startTime = Time.time;
        StartCoroutine("NoteDisplay");
        //StartCoroutine("CheckHit");
    }

    // Update is called once per frame
    void Update()
    {
        CheckHit();
        CheckEnd();
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
    void CheckEnd()
    {
        if (Time.time - startTime > endTime)
        {
            //Instantiate(prefabResultScene);
            Destroy(this);
        }
    }
}