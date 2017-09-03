using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    //スタート座標
    Vector3 StartPos;
    //ゴール座標
    Vector3 GoralPos;
    //目標時間
    float TotalTime;
    //経過時間
    float Time;
    //対象ゲームオブジェクト
    GameObject gameobject;
    //バトルマネージャのゲームオブジェクト
    GameObject ButtlegameObject;
  //  bool Isupdate = true;

    public GameObject _gameobject
    {
        get { return gameobject; }
        set { gameobject = value; }
    }

    //public float _GoralPosY
    //{
    //    get { return GoralPos.y; }
    //    set { GoralPos.y = value; }
    //}


    //public float _TotalTime
    //{
    //    get { return TotalTime; }
    //    set { TotalTime = value; }
    //}


    // Use this for initialization
    void Start () {
        this.Time = 0;
        //タッチ不可にする
        ButtlegameObject = GameObject.Find("FightManager");
        ButtlegameObject.GetComponent<FightManager>()._IsTouch = false;
    }

    
    public void MoveTo( GameObject gameobject, Vector3 gorlpos,float time)
    {
        this.gameobject = gameobject;
        StartPos = gameobject.transform.position;
        GoralPos = gorlpos;
        TotalTime = time;
    }

    public void MoveBy(GameObject gameobject, Vector3 gorlpos, float time)
    {

        this.gameobject = gameobject;
        StartPos = gameobject.transform.position;
        GoralPos = gameobject.transform.position + gorlpos;
        TotalTime = time;
    }

    // Update is called once per frame
    void Update () {
        
            this.Time++;
            float time = this.Time  - TotalTime  / TotalTime;


        Vector3 pos = Lerp(StartPos, GoralPos, time);
            if (gameobject != null)
            {
                //算出した座標を適用する
                gameobject.transform.position = pos;
            }
        else
        {
            Destroy(this.gameObject);
        }
        //else if(Isupdate)
        //{
        //    GoralPos *= 4;
        //    TotalTime *= 4;
        //    Isupdate = false;
        //}

        if (time > 1.0f)
            {
                //タッチ可にする
                ButtlegameObject = GameObject.Find("FightManager");
                ButtlegameObject.GetComponent<FightManager>()._IsTouch = true;
                Destroy(this.gameObject);
             }
      

    }

    Vector3 Lerp(Vector3 StartPosition, Vector3 GorlPosition , float Time)
    {
        return (1 - Time) * StartPosition + GorlPosition * Time;
    }


}
