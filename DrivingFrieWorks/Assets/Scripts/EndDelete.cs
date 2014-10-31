using UnityEngine;
using System.Collections;

public class EndDelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void DeleteObject()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
