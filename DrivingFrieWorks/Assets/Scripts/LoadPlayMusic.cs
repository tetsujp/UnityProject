using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class LoadPlayMusic : MonoBehaviour
{

    //ロードしたNoteを一時的に入れるリスト
    //リストの実態はまだ作られていない
    //LineNoteのリスト
    LineNote[] tempLoadList;
<<<<<<< HEAD
//    double endTime;
    
    //プレハブ
    public GameObject prefabLineNote;//Line
    public GameObject prefabSingleNote;//Single
    public GameObject prefabLongNote;//Long
    public GameObject prefabNoteOwner;
=======
    double endTime;
    public GameObject lineNote;

<<<<<<< HEAD
>>>>>>> parent of 8734fd1... GameObjectに変更前

=======
>>>>>>> parent of 4bbc575... 変更後
    SingleNote singleN;
    LongNote longN;
    LongNote[] tempLongData;
    Note data;
    //int readCount = 0;

    // Use this for initialization
    void Start()
    {
        int countNote = 0;

        double bpmTemp = 0;
        double judgeTime = 0;
        bool readEndFlag = false;

        //共通情報取得
        PlayState playStateScript = GameObject.Find("PlayState").GetComponent<PlayState>();
        string filePath = "Assets/music/" + playStateScript.selectName + "note[" + difficulty.GetName(Type.GetType("difficulty"), playStateScript.diff) + "].txt";
        FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(f);
        //読み込み失敗
        if (reader == null)
        {
            Debug.Log("ファイルオープン失敗");
            return;
        }
        string loopBuf;
        tempLoadList = new LineNote[Global.MAX_LINE];
        //リストのインスタンス作成
        //空のリストを実際に入れる
        for (var i = 0; i < Global.MAX_LINE; i++) tempLoadList[i] = (LineNote)Instantiate(lineNote);

        while (!readEndFlag)
        {
            //行読み込み
            loopBuf = reader.ReadLine();

            //名前取得
            if (loopBuf == "FILENAME")
            {
                loopBuf = reader.ReadLine();
                playStateScript.selectName = loopBuf;
            }
            //Delay取得
            else if (loopBuf == "DELAY")
            {
                loopBuf = reader.ReadLine();
                judgeTime = Convert.ToDouble(loopBuf);
            }
            //BPM取得
            else if (loopBuf == "STARTBPM")
            {
                loopBuf = reader.ReadLine();

                bpmTemp = Convert.ToDouble(loopBuf);
            }

            //コメント文
            else if (loopBuf[0] == '/')
            {
                continue;
            }

            //ノート部
            else if (loopBuf == "NOTE")
            {

                string buf;
                bool[] longLineFlag = new bool[Global.MAX_LINE];
                for (int i = 0; i < Global.MAX_LINE; i++) longLineFlag[i] = false;
                //一時的なLongNote
                //List<LongNote> tempLongData=new LongNote[Global.MAXLINE];
                //実態は持っていない
<<<<<<< HEAD
<<<<<<< HEAD
                LongNote[] tempLongData = new LongNote[Global.MAX_LINE];
<<<<<<< HEAD
                //tempLongData = new LongNote[Global.MAX_LINE];
=======
                //LongNote[] tempLongData = new LongNote[Global.MAX_LINE];
                tempLongData = new LongNote[Global.MAX_LINE];
>>>>>>> parent of 4bbc575... 変更後
=======
                //LongNote[] tempLongData = new LongNote[Global.MAX_LINE];
                tempLongData = new LongNote[Global.MAX_LINE];
>>>>>>> parent of 4bbc575... 変更後
               

                
=======
>>>>>>> parent of 8734fd1... GameObjectに変更前
                //ダミーのデータ挿入
                //for (var i = 0; i < Global.MAXLINE; i++) tempLongData.Add(new LongNote());

                double syosetsuNum = 4;//初期が4分
                //InformationNote tempLongData[];

                //初期の1泊設定
                double hakuTime = (60 * 4 / (bpmTemp * syosetsuNum));
                //表示時間
                //multspdが4の場合1小節
                double dispTime = hakuTime;
                bool longStartFlag = false;

                //1行ずつ読む
                while ((buf = reader.ReadLine()) != null)
                {
                    int readCount = 0;
                    //改行時飛ばし
                    if (buf == "\n") continue;
                    //1文字読み込み
<<<<<<< HEAD
                    while (readCount < buf.Length)
=======
                    char c_buf = buf[readCount];
                    readCount++;

                    //次の泊へ
                    if (c_buf == ',')
>>>>>>> parent of 8734fd1... GameObjectに変更前
                    {
                        //int readCount = 0;
                        //charでは取得できない?
                        //char c_buf = buf[readCount];
                        string c_buf = buf[readCount].ToString();
                        readCount++;

                        //次の泊へ
                        if (c_buf == ",")
                        {
                            judgeTime += hakuTime;
                        }

<<<<<<< HEAD
                        //Bpm変更開始
                        else if (c_buf == "#")
=======
                    //Bpm変更開始
                    else if (c_buf == '#')
                    {
                        string tBpm = String.Empty; ;
                        //&が出るまでの数字
                        while (buf[readCount] != '&')
>>>>>>> parent of 8734fd1... GameObjectに変更前
                        {
                            string tBpm = String.Empty;
                            //&が出るまでの数字
                            while (buf[readCount] != '&')
                            {
                                tBpm += buf[readCount];
                                readCount++;
                            }
                            //&の分
                            readCount++;
                            //BPM変更とhakutimeの修正
                            //bpmTemp = Convert.ToDouble(tBpm);
                            bpmTemp = double.Parse(tBpm);
                            hakuTime = (60 * 4 / (bpmTemp * syosetsuNum));
                            dispTime = hakuTime * syosetsuNum * 4;
                        }
<<<<<<< HEAD

                            //泊数変更
                        else if (c_buf == "@")
=======
                        //BPM変更とhakutimeの修正
                        bpmTemp = Convert.ToDouble(tBpm);
                        hakuTime = (60 * Global.MILLI_SECONDS * 4 / (bpmTemp)) * syosetsuNum;
                    }

                        //泊数変更
                    else if (c_buf == '@')
                    {
                        string tSyosetsuNum = String.Empty; ;
                        //&が出るまでの数字
                        while (buf[readCount] != '&')
>>>>>>> parent of 8734fd1... GameObjectに変更前
                        {
                            string tSyosetsuNum = String.Empty; ;
                            //&が出るまでの数字
                            while (buf[readCount] != '&')
                            {
                                tSyosetsuNum += buf[readCount];
                                readCount++;
                            }
                            //&の分
                            readCount++;
                            //１泊の時間変更
                            //syosetsuNum = Convert.ToDouble(tSyosetsuNum);
                            syosetsuNum = double.Parse(tSyosetsuNum);
                            hakuTime = (60 * 4 / (bpmTemp * syosetsuNum));
                        }
<<<<<<< HEAD

                            //コメント
                        else if (c_buf == "/")
=======
                        //１泊の時間変更
                        syosetsuNum = Convert.ToDouble(tSyosetsuNum);
                        hakuTime = (60 * Global.MILLI_SECONDS * 4 / (bpmTemp)) * syosetsuNum;
                    }

                        //コメント
                    else if (c_buf == '/')
                    {
                        while (buf[readCount] != '&')
>>>>>>> parent of 8734fd1... GameObjectに変更前
                        {
                            while (buf[readCount] != '&')
                            {
                                readCount++;
                            }
                            //&の分
                            readCount++;
                        }
<<<<<<< HEAD

                            //終了時間
                        else if (c_buf == "E")
                        {
                            //endTime = judgeTime;
=======
                    }

                        //終了時間
                    else if (c_buf == 'E')
                    {
                        endTime = judgeTime;
                    }
                    //ロングノート開始
                    //次の数字のノートをロングノートにする
                    else if (c_buf == '!')
                    {
                        longStartFlag = true;

                    }

                        //数字の時ノート追加
                    else
                    {
                        //charからintへ変換
                        int intBuf = Convert.ToInt32(c_buf);

                        //リストにデータを入れる
                        Note data;

                        //表示時間の設定
                        //変更が必要？

                        double apperTime = judgeTime - hakuTime * playStateScript.multspd;
                        
                        
                        //ロングノートにする
                        if (longStartFlag)
                        {

                            longLineFlag[intBuf] = true;
                            LongNote l = new LongNote();
                            l.Initialize(judgeTime, bpmTemp, apperTime, intBuf);
                            tempLongData[intBuf] = l;

                            longStartFlag = false;
                            continue;
>>>>>>> parent of 8734fd1... GameObjectに変更前
                        }
                        //ロングノート開始
                        //次の数字のノートをロングノートにする
                        else if (c_buf == "!")
                        {
<<<<<<< HEAD
                            longStartFlag = true;
=======
                            SingleNote s=new SingleNote();
                            s.Initialize(judgeTime, bpmTemp, apperTime, intBuf);
>>>>>>> parent of 8734fd1... GameObjectに変更前

                        }

                            //数字の時ノート追加
                        else
                        {
                            //charからintへ変換
                            //int intBuf = Convert.ToInt32(c_buf);
                            int intBuf = int.Parse(c_buf);
                            //リストにデータを入れる
                            //Note data;

                            //表示時間の設定

                            double apperTime = judgeTime - dispTime * playStateScript.multspd;


                            //ロングノートにする
                            if (longStartFlag)
                            {

                                longLineFlag[intBuf] = true;
                                //LongNote l = new LongNote();

                                longN = ((GameObject)Instantiate(prefabSingleNote)).GetComponent<LongNote>();
                                //LongNote tempLong = l.GetComponent<LongNote>();
                                longN.Initialize(judgeTime, bpmTemp, apperTime, intBuf);
                                //l.Initialize(judgeTime, bpmTemp, apperTime, intBuf);
                                tempLongData[intBuf] = longN;

                                longStartFlag = false;
                                continue;
                            }

                            //データが入る場合のみ下へ
                            //データ格納

                            //単ノートはこのまま入る
                            if (longLineFlag[intBuf] == false)
                            {
                                //SingleNote s=new SingleNote();
                                //SingleNote s= (SingleNote)Instantiate(prefabSingleNote);
                                singleN = ((GameObject)Instantiate(prefabSingleNote)).GetComponent<SingleNote>();
                                //s =single.GetComponent<SingleNote>();
                                singleN.Initialize(judgeTime, bpmTemp, apperTime, intBuf);
                                data = singleN;
                            }

                            //ロングノートは終点を適用
                            else
                            {
                                tempLongData[intBuf].SetLongEndTime(judgeTime);
                                data = tempLongData[intBuf];
                            }
                            //Noteの追加
                            //最初は非アクティブ
                            data.gameObject.SetActive(false);
                            tempLoadList[intBuf].Add(data);
                            //終点用にカウント数増加
                            countNote++;
                        }
<<<<<<< HEAD
=======
                        //Noteの追加
                        tempLoadList[intBuf].Add(data);
                        //終点用にカウント数増加
                        countNote++;
>>>>>>> parent of 8734fd1... GameObjectに変更前
                    }
                }

                readEndFlag = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {


    }

    public LineNote[] GetAllNoteList() { return tempLoadList; }



    
}
