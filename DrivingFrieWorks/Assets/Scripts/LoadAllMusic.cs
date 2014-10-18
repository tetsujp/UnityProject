using UnityEngine;
using System.Collections;
using System.IO;

//曲データの全ロード
public class LoadAllMusic : MonoBehaviour {

	// Use this for initialization
    public GameObject selectBar;
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
            select.GetComponent<SelectBar>().Initialize(i, name, bpm, composer);
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
