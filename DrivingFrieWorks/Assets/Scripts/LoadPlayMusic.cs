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
//    double endTime;
    
    //プレハブ
    public GameObject prefabLineNote;//Line
    public GameObject prefabSingleNote;//Single
    public GameObject prefabLongNote;//Long
    public GameObject prefabNoteOwner;

    //SingleNote singleN;
    //LongNote longN;
    //LongNote[] tempLongData;
    //Note data;

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
        string filePath = "Assets/Music/" + playStateScript.selectName + difficulty.GetName(Type.GetType("difficulty"), playStateScript.diff) + ".txt";
        FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(f);
        //読み込み失敗
        if (reader == null)
        {
            Debug.Log("ファイルオープン失敗");
            return;
        }
        string loopBuf;
        //tempLoadList = new LineNote[Global.MAX_LINE];
        //リストのインスタンス作成
        tempLoadList = new LineNote[Global.MAX_LINE];
        //空のリストを実際に入れる
        for (var i = 0; i < Global.MAX_LINE; i++)
        {
            /*tempLoadList[i] = (LineNote)Instantiate(prefabLineNote);*/
            GameObject obj = (GameObject)Instantiate(prefabLineNote);
            tempLoadList[i] = obj.GetComponent<LineNote>();
        }


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
                LongNote[] tempLongData = new LongNote[Global.MAX_LINE];
                //tempLongData = new LongNote[Global.MAX_LINE];
               

                
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
                    while (readCount < buf.Length)
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

                        //Bpm変更開始
                        else if (c_buf == "#")
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

                            //泊数変更
                        else if (c_buf == "@")
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

                            //コメント
                        else if (c_buf == "/")
                        {
                            while (buf[readCount] != '&')
                            {
                                readCount++;
                            }
                            //&の分
                            readCount++;
                        }

                            //終了時間
                        else if (c_buf == "E")
                        {
                            //endTime = judgeTime;
                        }
                        //ロングノート開始
                        //次の数字のノートをロングノートにする
                        else if (c_buf == "!")
                        {
                            longStartFlag = true;

                        }

                            //数字の時ノート追加
                        else
                        {
                            //charからintへ変換
                            //int intBuf = Convert.ToInt32(c_buf);
                            int intBuf = int.Parse(c_buf);
                            //リストにデータを入れる
                            Note data;

                            //表示時間の設定

                            double apperTime = judgeTime - dispTime * playStateScript.multspd;


                            //ロングノートにする
                            if (longStartFlag)
                            {

                                longLineFlag[intBuf] = true;
                                //LongNote l = new LongNote();

                                LongNote longN = ((GameObject)Instantiate(prefabLongNote)).GetComponent<LongNote>();
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
                                
                                SingleNote singleN = ((GameObject)Instantiate(prefabSingleNote)).GetComponent<SingleNote>();
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
                    }
                }

                readEndFlag = true;
            }
        }

        Instantiate(prefabNoteOwner);
    }


    // Update is called once per frame
    void Update()
    {


    }

    public LineNote[] GetAllNoteList() { return tempLoadList; }



    
}
