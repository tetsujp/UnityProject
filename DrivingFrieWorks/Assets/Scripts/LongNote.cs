using UnityEngine;
using System.Collections;

public class LongNote : Note {
    double longEndTime;

    public override void Initialize(double jt, double at, int li)
    {
        base.Initialize(jt, at, li);
    }

    public void SetLongEndTime(double longEndTime) { this.longEndTime = longEndTime; } 
}
