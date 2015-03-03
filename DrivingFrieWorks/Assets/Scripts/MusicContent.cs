using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*public class MusicData
{
    public string musicName { get; set; }
    public string bpmRange { get; set; }
    public string composer { get; set; }
    public string genre { get; set; }
    public string comment { get; set; }
    public string[] diff { get; set; }
    public MusicData()
    {
        musicName = string.Empty;
        bpmRange = string.Empty;
        composer = string.Empty;
        genre = string.Empty;
        comment = string.Empty;
        diff = new string[3];
    }
}*/

public class MusicContent : MonoBehaviour
{
    public MusicData data;
    AndSelectScene selectScene;
    // Use this for initialization
    void Start()
    {

    }
    public void Initialize(MusicData d)
    {
        //gameObject.transform.parent = GameObject.FindWithTag("SelectCanvas").transform;
        //gameObject.transform.SetParent(GameObject.FindWithTag("SelectCanvas").transform);
        //transform.localPosition = new Vector3(0, 0, 0);
        //transform.position += new Vector3(0, -moveToPosition * count, 0);
        //firstPositionX = transform.position.x;
        data = d;
        transform.GetComponentInChildren<Text>().text = data.musicName;
        selectScene = GameObject.FindGameObjectWithTag("SelectScene").GetComponent<AndSelectScene>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetInfomation()
    {
        selectScene.SetInfomation(data);
    }

}
