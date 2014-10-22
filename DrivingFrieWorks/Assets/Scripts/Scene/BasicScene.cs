using UnityEngine;
using System.Collections;

//シーンの基底クラス
public class BasicScene:MonoBehaviour {

    //シーンに入る時
    public virtual void Initialize(){}
    //シーンから出る時
    public virtual void SceneFinalize(){}
}
