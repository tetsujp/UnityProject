using UnityEngine;
using System.Collections;

public class LongNote : Note {
    double longEndTime;

    public override void Initialize(double jt, double bt, double at, int li)
    {
        base.Initialize(jt, bt, at, li);
    }

    public void SetLongEndTime(double longEndTime) { this.longEndTime = longEndTime; } 
}
