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

    public double endTime{get;set;}
    double startEditTime = 0;
    public float delayEmptyTime { get; set; }

    //プレハブ
    public GameObject prefabLineNote;//Line
    public GameObject prefabSingleNote;//Single
    public GameObject prefabSideNote;
    public GameObject prefabLongNote;//Long


    // Use this for initialization
    void Awake()
    {
        int countNote = 0;

        double bpmTemp = 0;
        double judgeTime = 0;
        bool readEndFlag = false;
        bool startSetFlag = false;

        //共通情報取得
        PlayState playStateScript = GameObject.Find("PlayState").GetComponent<PlayState>();
        string filePath = string.Format("{0}/Music/{1}/{2}.txt", Application.dataPath, playStateScript.selectName,playStateScript.diff.ToString());
        using(FileStream f = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (StreamReader reader = new StreamReader(f))
        {
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
            for (var i = 0; i < Global.MAX_LINE; i++)
            {
                /*tempLoadList[i] = (LineNote)Instantiate(prefabLineNote);*/
                GameObject obj = (GameObject)Instantiate(prefabLineNote);
                obj.GetComponent<LineNote>().lineName = (LineName)i;
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
                    //playStateScript.selectName = loopBuf;
                }
                //Delay取得
                else if (loopBuf == "DELAY")
                {
                    loopBuf = reader.ReadLine();
                    delayEmptyTime = float.Parse(loopBuf);
                }
                //BPM取得
                else if (loopBuf == "STARTBPM")
                {
                    loopBuf = reader.ReadLine();

                    bpmTemp = double.Parse(loopBuf);
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

                    LongNote[] tempLongData = new LongNote[Global.MAX_LINE];


                    double syosetsuNum = 4;//初期が4分
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
                        if (buf == "") continue;
                        string a_buf = buf[0].ToString();
                        if (a_buf == "/")
                        {
                            continue;
                        }
                        //1文字読み込み

                        while (readCount < buf.Length)
                        {
                            string c_buf = buf[readCount].ToString();
                            readCount++;

                            //次の泊へ
                            if (c_buf == ",")
                            {
                                judgeTime += hakuTime;
                            }

                                //スタート位置の変更
                            else if (c_buf == "S")
                            {
                                startEditTime = judgeTime;
                                judgeTime = 0;
                                startSetFlag = true;
                            }
                            //Bpm変更開始
                            else if (c_buf == "#")
                            {
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
                                    //4分の時間
                                    //4分にして時間を変更する
                                    dispTime = hakuTime * 4 / syosetsuNum;
                                }
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
                                ////先頭
                                //if (readCount == 0)
                                //{
                                //    readCount = buf.Length;
                                //    continue;  
                                //}
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
                                endTime = judgeTime;
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
                                //startEditTimeより前
                                if (startSetFlag == false) continue;

                                int intBuf = int.Parse(c_buf);
                                Note data = null;

                                //表示時間の設定

                                double apperTime = judgeTime - dispTime * playStateScript.multspd;


                                //ロングノートにする
                                if (longStartFlag)
                                {

                                    longLineFlag[intBuf] = true;

                                    LongNote longN = ((GameObject)Instantiate(prefabLongNote)).GetComponent<LongNote>();
                                    longN.Initialize(judgeTime, apperTime, intBuf);
                                    tempLongData[intBuf] = longN;

                                    longStartFlag = false;
                                    continue;
                                }

                                //データが入る場合のみ下へ
                                //データ格納

                                //単ノートはこのまま入る
                                if (longLineFlag[intBuf] == false)
                                {
                                    if (intBuf < (int)LineName.KeyLeftLeft)
                                    {
                                        SingleNote singleN = ((GameObject)Instantiate(prefabSingleNote)).GetComponent<SingleNote>();
                                        singleN.Initialize(judgeTime, apperTime, intBuf);
                                        data = singleN;
                                    }
                                    else
                                    {
                                        SideNote sideN = ((GameObject)Instantiate(prefabSideNote)).GetComponent<SideNote>();
                                        sideN.Initialize(judgeTime, apperTime, intBuf);
                                        data = sideN;
                                    }
                                  
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
        }
        //judgetimeでリストソート
        //foreach (var l in tempLoadList)
        //{
        //    l.SortList();
        //}
        LoadSelectMusic();
        //スコアセット
        GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>().Initalize(countNote);
    }


    // Update is called once per frame
    void Update()
    {


    }
    // member
    private WavFileInfo m_WavInfo = new WavFileInfo();
    void LoadSelectMusic()
    {
        AudioClipMaker m_ClipMaker = GameObject.FindWithTag("AudioClipMaker").GetComponent<AudioClipMaker>();
        GameObject m_AudioPlayer = GameObject.FindWithTag("Music");
        PlayState playStateScript = GameObject.Find("PlayState").GetComponent<PlayState>();
        string path = string.Format("{0}/Music/{1}/{1}.wav", Application.dataPath, playStateScript.selectName);

        AudioSource source = m_AudioPlayer.GetComponent<AudioSource>();
            byte[] buf = File.ReadAllBytes(path);
            // analyze wav file
            m_WavInfo.Analyze(buf);
            // create audio clip
            //再利用を可能にしたい
            AudioClip clip = m_ClipMaker.Create(
            playStateScript.selectName,
            buf,
            m_WavInfo.TrueWavBufIdx,
            m_WavInfo.BitPerSample,
            m_WavInfo.TrueSamples,
            m_WavInfo.Channels,
            m_WavInfo.Frequency,
            false,
            false
            );
            source.clip = clip;

        source.time = (float)startEditTime;

    }

    public LineNote[] GetAllNoteList() { return tempLoadList; }




}
