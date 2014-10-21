using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

//曲データの全ロード
public class SelectScene : MonoBehaviour
{

	// Use this for initialization
    public GameObject selectBar;
    public GameObject loadPlayMusic;
    PlayState playState;
    List<SelectBar> selectBarList = new List<SelectBar>();
    int playCounter = 0;
    int MaxMusicNumber=-1;
	void Start () {
        //自動でフォルダから曲情報を読み込み


        //フォルダ列挙
        string folderPath = string.Format("{0}/Music", Application.dataPath);
        string[] allFolderPath = System.IO.Directory.GetDirectories(folderPath, "*");
        if (allFolderPath.Length==0)
        {
            Debug.Log("フォルダが見つかりません");
            return;
        }
        //曲取得
        for (var i = 0; i < allFolderPath.Length;i++ )
        {

            FileStream f = new FileStream(allFolderPath[i] + "/info.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(f);
            //読み込み失敗
            if (reader == null)
            {
                Debug.Log("ファイルが見つかりません");
                return;
            }
            string loopBuf;

            //曲情報
            string name = string.Empty;
            string bpm = string.Empty;
            string composer = string.Empty;
            while ((loopBuf = reader.ReadLine()) != null)
            {

                //名前取得
                if (loopBuf == "FILENAME")
                {
                    loopBuf = reader.ReadLine();
                    name = loopBuf;
                }
                //BPM取得
                else if (loopBuf == "BPMRANGE")
                {
                    loopBuf = reader.ReadLine();
                    bpm = loopBuf;
                }
                else if (loopBuf == "COMPOSER")
                {
                    loopBuf = reader.ReadLine();
                    composer = loopBuf;
                }
                //コメント文
                else if (loopBuf[0] == '/')
                {
                    continue;
                }
            }
            var select = (GameObject)Instantiate(selectBar);
            var script=select.GetComponent<SelectBar>();
            script.Initialize(i, name, bpm, composer);
            selectBarList.Add(script);
            MaxMusicNumber++;
        }
        playState = GameObject.FindGameObjectWithTag("PlayState").GetComponent<PlayState>();
        playState.selectName = selectBarList[0].name;
	}
	
	// Update is called once per frame
	void Update () {
        //SelectBarの移動
        if (Input.GetButtonDown("Up")&&playCounter<MaxMusicNumber)
        {
            playCounter++;
            foreach (var select in selectBarList)
            {
                select.Move();
            }

            playState.selectName = selectBarList[playCounter].name;
        }
        else if(Input.GetButtonDown("Down")&&playCounter>0){
            playCounter--;
            foreach (var select in selectBarList)
            {
                select.Move();
            }

            playState.selectName = selectBarList[playCounter].name;
        }
            //難易度変更
        else if (Input.GetButtonDown("Left")&&playState.diff>difficulty.easy)
        {
            playState.diff=playState.diff++;
        }
        else if(Input.GetButtonDown("Right")&&playState.diff<difficulty.extreme)
        {
            playState.diff = playState.diff--;
        }
        //曲の決定
        else if (Input.GetButtonDown("Decide"))
        {
            Instantiate(loadPlayMusic);
            gameObject.SetActive(false);
        }
	}
}
