using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectBar : MonoBehaviour {

    public float moveToPosition = 100;
    public string name{get;set;}
    string bpmRange;
    string composer;
	// Use this for initialization
	void Start () {
	
	}
    public void Initialize(int count,string n,string bpm,string com)
    {
        gameObject.transform.parent = GameObject.FindWithTag("SelectCanvas").transform;
        transform.localPosition = new Vector3(0, 0, 0);
        transform.position+=new Vector3(0,-moveToPosition*count,0);
        name = n;
        //textへの適応
        transform.GetComponentInChildren<Text>().text = name;
        bpmRange = bpm;
        composer = com;
    }
	
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
