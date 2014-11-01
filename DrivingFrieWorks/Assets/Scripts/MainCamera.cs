using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour
{
    enum RotateKind {Left=0,Right}
    float angle =400f;
    Vector3 center=new Vector3(0,0,0);
    Vector3 startPos;
    //bool[] rotateFlag;
	// Use this for initialization
    void Start()
    {
        startPos = transform.position;
        //rotateFlag = new bool[2];
    }
	
	// Update is called once per frame
	void Update ()
	{
        //for(var i=0;i<(int)RotateKind.Right;i++){
        //    if (rotateFlag[i]==true)
        //        StartCoroutine(Rotate((RotateKind)i));
        //    rotateFlag[i]=false;
        //}
            float dis = transform.position.x - startPos.x;
            Vector3 axis = transform.TransformDirection(Vector3.up);
            if (dis > 0)
            {
                transform.RotateAround(center, axis, angle / 30 * Time.deltaTime * dis);
            }
            else
            {
                transform.RotateAround(center, axis, angle /30 * Time.deltaTime * dis);
            }
            transform.LookAt(center);
        
    }
    public void SetRotate(LineName lName)
    {
        if (lName == LineName.KeyLeftLeft) StartCoroutine(Rotate(RotateKind.Left));
        if (lName == LineName.KeyRightRight) StartCoroutine(Rotate(RotateKind.Right));
    }
    float displayInterval = 0.01f;//ループ時間10ms
    IEnumerator Rotate(RotateKind k)
    {
        for (int i = 0; i < 90;i++ )
        {
            if (transform.position.z < -15f)
            {
                // Sampleを中心に自分を現在の上方向に、毎秒angle分だけ回転する。
                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(center, axis, -angle * Time.deltaTime * (k == RotateKind.Left ? -1 : 1));
                transform.LookAt(center);
            }
            yield return new WaitForSeconds(displayInterval);
            if (i == 9)
            {
                yield break;
            }
        }
    }
}