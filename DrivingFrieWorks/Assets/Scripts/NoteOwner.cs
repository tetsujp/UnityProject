using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{

    LineNote[] allNoteList;

    // Use this for initialization
    void Start()
    {
        //ノートデータの取得
        allNoteList = GameObject.FindWithTag("LoadPlayMusic").GetComponent<LoadPlayMusic>().GetAllNoteList();

<<<<<<< HEAD
        startTime = Time.time;
<<<<<<< HEAD
        //StartCoroutine("noteDisplay");
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 8734fd1... GameObjectに変更前
        StartCoroutine("noteDisplay");
=======
        //StartCoroutine("noteDisplay");
>>>>>>> parent of 4bbc575... 変更後
=======
        //StartCoroutine("noteDisplay");
>>>>>>> parent of 4bbc575... 変更後
>>>>>>> origin/master
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

            }

            //for (var i = 0; i < Global.MAX_LINE; i++)
            //{
                
                ////画面に出すノートがない場合,終了へ
                ////if (noteList[i].Count < displayNoteNumber[i]) yield break;
                ////画面内に表示するかの判定
                //Note n = noteList[i][displayNoteNumber[i]];

                ////スタートする時間と現在時間を比較
                //if (pop.Judge_Start_Time(HIT_LINE / (bpm * highspeed) + delay) <= (now_time - start_time))
                //{
                //    //入れる作業
                //    //list_field_note[i].push_back(pop);

                //    //元リストの先頭削除
                //    //list_note[i].pop_front();
                //    //再びリストを見る
                //    //1フレーム内で高密度縦連用
                //    i--;
                //}
            //}
        }
        
        yield return new WaitForSeconds(displayInterval);
    }
}