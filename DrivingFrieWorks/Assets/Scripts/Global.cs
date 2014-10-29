using UnityEngine;
using System.Collections;


public enum Difficulty { Easy, Normal, Hard };
public enum LineName { KeyLeft, KeyLeftCenter, KeyCenter, KeyRightCenter, KeyRight ,KeyLeftLeft,KeyRightRight}
public enum JudgeKind { Just, Great, Good, Miss, NUM }

public class Global : MonoBehaviour
{
    public const int MAX_LINE = 7;
    //public const int MILLI_SECONDS = 1000;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}