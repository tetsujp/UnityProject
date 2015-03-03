using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

//曲データの全ロード
public class AndSelectScene : MonoBehaviour
{

    // Use this for initialization
    ScrollController scroll;///曲選択リスト表示オブジェクト
    GameObject selectCanvas;
    GameObject stateCanvas;
    PlayState playState;
    //List<MusicContent> selectBarList = new List<SelectBar>();
    Dictionary<string, Text> musicDataTable = new Dictionary<string, Text>();//曲情報、Bpmやこめんとなど

    void Start()
    {

        scroll = GameObject.FindGameObjectWithTag("Content").GetComponent<ScrollController>();
        //自動でフォルダから曲情報を読み込み
        //曲取得
        //Resources内のテキストデータ取得
        foreach (var allMusicInfoData in Resources.LoadAll<TextAsset>("Music"))
        {
            //infoのみ取得
            if (allMusicInfoData.name != "info")
            {
                continue;
            }

            //using(FileStream f = new FileStream(allFolderPath[i] + "/info.txt", FileMode.Open, FileAccess.Read))
            using (StringReader reader = new StringReader(allMusicInfoData.text))
            {
                string loopBuf;

                //曲情報
                MusicData d = new MusicData();

                while ((loopBuf = reader.ReadLine()) != null)
                {

                    //名前取得
                    if (loopBuf == "FILENAME")
                    {
                        loopBuf = reader.ReadLine();
                        d.musicName = loopBuf;
                    }
                    //BPM取得
                    else if (loopBuf == "BPMRANGE")
                    {
                        loopBuf = reader.ReadLine();
                        d.bpmRange = loopBuf;
                    }
                    else if (loopBuf == "COMPOSER")
                    {
                        loopBuf = reader.ReadLine();
                        d.composer = loopBuf;
                    }
                    else if (loopBuf == "GENRE")
                    {
                        loopBuf = reader.ReadLine();
                        d.genre = loopBuf;

                    }
                    else if (loopBuf == "DIFFICULTY")
                    {
                        loopBuf = reader.ReadLine();
                        d.diff = loopBuf.Split(',');
                    }
                    else if (loopBuf == "COMMENT")
                    {
                        loopBuf = reader.ReadLine();
                        d.comment = loopBuf;
                    }
                    //コメント文
                    else if (loopBuf[0] == '/')
                    {
                        continue;
                    }
                }

                //var select = (GameObject)Instantiate(selectBar);
                //var script = select.GetComponent<SelectBar>();
                //script.Initialize(MaxMusicNumber + 1, d);
                //selectBarList.Add(script);
                //MaxMusicNumber++;
                scroll.AddMusicContent(d);

            }
        }
        playState = GameObject.FindGameObjectWithTag("PlayState").GetComponent<PlayState>();
        stateCanvas = GameObject.FindGameObjectWithTag("StateCanvas");
        selectCanvas = GameObject.FindGameObjectWithTag("SelectCanvas");
        SetDataTable();
        //SetMusicData();
        Initialize();
    }
    void Initialize()
    {
        InitializeTouch();
    }
    void InitializeTouch()
    {
        //IT_Gesture.onMultiTapE
    }
    void SceneFinalize()
    {
        //IT_Gesture.onMultiTapE
    }
    // Update is called once per frame
    void Update()
    {

    }
    //曲のタッチ

    //難易度のタッチ

    //曲選択スワイプ



    void UpdateInputTouch()
    {
        
    }
    /*void SetMusicData()
    {
        playState.selectName = selectBarList[playCounter].data.musicName;
        selectBarList[playCounter].MoveNowSelect();

        selectCanvas.transform.FindChild("Easy").gameObject.SetActive(false);
        selectCanvas.transform.FindChild("Normal").gameObject.SetActive(false);
        selectCanvas.transform.FindChild("Hard").gameObject.SetActive(false);


        selectCanvas.transform.FindChild(playState.diff.ToString()).gameObject.SetActive(true);

        musicDataTable["DiffNumber"].text = "Difficulty: " + selectBarList[playCounter].data.diff[(int)playState.diff];
        musicDataTable["HighSpeed"].text = "PlaySpeed: " + playState.multspd.ToString();
        //musicDataTable["HighScore"].text = "Score: "+selectBarList[playCounter].data.;
        musicDataTable["HighScore"].text = "None";
        musicDataTable["BPM"].text = "BPM: " + selectBarList[playCounter].data.bpmRange;
        musicDataTable["Composer"].text = "composer: " + selectBarList[playCounter].data.composer;
        musicDataTable["Genre"].text = "Genre: " + selectBarList[playCounter].data.genre;
        musicDataTable["Comment"].text = "Comment: " + selectBarList[playCounter].data.comment;
    }*/
    /*void SetDataTable()
    {
        var list = stateCanvas.GetComponentsInChildren<Transform>().Where(c => stateCanvas.transform != c).ToArray();
        foreach (var l in list)
        {
            musicDataTable.Add(l.name, l.GetComponent<Text>());
        }
    }*/
    void SetDataTable()
    {
        var list = stateCanvas.GetComponentsInChildren<Transform>().Where(c => stateCanvas.transform != c).ToArray();
        foreach (var l in list)
        {
            musicDataTable.Add(l.name, l.GetComponent<Text>());
        }
    }
    public void SetInfomation(MusicData data)
    {

        playState.selectName = data.musicName;

        selectCanvas.transform.FindChild("Easy").gameObject.SetActive(false);
        selectCanvas.transform.FindChild("Normal").gameObject.SetActive(false);
        selectCanvas.transform.FindChild("Hard").gameObject.SetActive(false);
        selectCanvas.transform.FindChild(playState.diff.ToString()).gameObject.SetActive(true);


        musicDataTable["DiffNumber"].text = "Difficulty: " + data.diff[(int)playState.diff];
        musicDataTable["HighSpeed"].text = "PlaySpeed: " + playState.multspd.ToString();
        //musicDataTable["HighScore"].text = "Score: "+selectBarList[playCounter].data.;
        musicDataTable["HighScore"].text = "None";
        musicDataTable["BPM"].text = "BPM: " + data.bpmRange;
        musicDataTable["Composer"].text = "composer: " + data.composer;
        musicDataTable["Genre"].text = "Genre: " + data.genre;
        musicDataTable["Comment"].text = "Comment: " + data.comment;
    }
}
