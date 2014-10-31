using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MusicData
{
    public string musicName { get; set; }
    public string bpmRange { get; set; }
    public string composer { get; set; }
    public string genre { get; set; }
    public string comment { get; set; }
    public string[] diff{get;set;}
    public MusicData(){
        musicName = string.Empty;
        bpmRange = string.Empty;
        composer = string.Empty;
        genre = string.Empty;
        comment = string.Empty;
        diff=new string[3];
    }
}

public class SelectBar : MonoBehaviour {

    public float moveToPosition = 100;
    float firstPositionX;
    public MusicData data;
	// Use this for initialization
	void Start () {
	
	}
    public void Initialize(int count, MusicData d)
    {
        gameObject.transform.parent = GameObject.FindWithTag("SelectCanvas").transform;
        //transform.localPosition = new Vector3(0, 0, 0);
        transform.position += new Vector3(0, -moveToPosition * count, 0);
        firstPositionX = transform.position.x;
        data = d;
        transform.GetComponentInChildren<Text>().text = data.musicName;
    }
    //public void Initialize(int count,string n,string bpm,string com)
    //{
    //    gameObject.transform.parent = GameObject.FindWithTag("SelectCanvas").transform;
    //    transform.localPosition = new Vector3(0, 0, 0);
    //    transform.position+=new Vector3(0,-moveToPosition*count,0);
    //    musicName = n;
    //    //textへの適応
    //    transform.GetComponentInChildren<Text>().text = musicName;
    //    bpmRange = bpm;
    //    composer = com;
    //}
	
	// Update is called once per frame
	void Update () {
	}
    public void Move()
    {
        //右に戻す
        transform.position = new Vector3(firstPositionX, transform.position.y, transform.position.z);
        if (Input.GetButtonDown("Down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveToPosition, transform.position.z);
        }
        else if (Input.GetButtonDown("Up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -moveToPosition, transform.position.z);
        }
    }
    //選択中のみ左に出す
    public void MoveNowSelect()
    {
        transform.position = new Vector3(firstPositionX - 100, transform.position.y, transform.position.z);

    }
}
