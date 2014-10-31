using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{
    public GameObject prefabLoadPlayMusic;
    LineNote[] allNoteList;
    float startTime;
    double endTime;
    AudioSource playMusic;

    // Use this for initialization
    void Start()
    {
        //ノートデータの取得
        GameObject loadPlayMusic = (GameObject)Instantiate(prefabLoadPlayMusic);
        LoadPlayMusic playMusicScript = loadPlayMusic.GetComponent<LoadPlayMusic>();
        allNoteList = playMusicScript.GetAllNoteList();
        Destroy(loadPlayMusic);
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
    }

    //画面に内に出す判定
    //コルーチンで実装
    public float displayInterval = 0.005f;//ループ時間10ms
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
    public bool IsEnd()
    {
        if (Time.time - startTime > endTime)
        {
            return true;
        }
        return false;
    }
    //オブジェクト削除
    public void FinalizeObj()
    {
        //Note削除
        foreach (var note in GameObject.FindGameObjectsWithTag("Note"))
        {
            Destroy(note);
        }
        //NoteList削除
        foreach (var line in GameObject.FindGameObjectsWithTag("LineNote"))
        {
            Destroy(line);
        }
        playMusic.Stop();
    }
}