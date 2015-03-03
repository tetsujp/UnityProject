using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    [SerializeField]
    RectTransform musicContent = null;

    void Start()
    {
        
    }
    public void AddMusicContent(MusicData d)
    {
        var item = GameObject.Instantiate(musicContent) as RectTransform;
        item.SetParent(transform, false);
        item.GetComponent<MusicContent>().Initialize(d);
    }
} 
