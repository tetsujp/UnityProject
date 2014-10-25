using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class MusicData
{
    public string musicName { get; set; }
    public string bpmRange { get; set; }
    public string composer { get; set; }
    public string genre { get; set; }
    public string commnet { get; set; }
}

public class SelectBar : MonoBehaviour {

    public float moveToPosition = 100;
    MusicData data
	// Use this for initialization
	void Start () {
	
	}
    public void Initialize(int count, string n, string bpm, string com)
    {
        gameObject.transform.parent = GameObject.FindWithTag("SelectCanvas").transform;
        transform.localPosition = new Vector3(0, 0, 0);
        transform.position += new Vector3(0, -moveToPosition * count, 0);
        musicName = n;
        //textへの適応
        transform.GetComponentInChildren<Text>().text = musicName;
        bpmRange = bpm;
        composer = com;
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
        if (Input.GetButtonDown("Up"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveToPosition, transform.position.z);
        }
        else if (Input.GetButtonDown("Down"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y -moveToPosition, transform.position.z);
        }
    }
    //選択中のみ左に出す

}
