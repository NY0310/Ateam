using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ドロップクラス(基底)
/// </summary>
public  class Drop : MonoBehaviour {

    
    //ドロップ種類
    public enum DROPTYPE
    {
        Circle,
        Cross,
        Tryangle,
        MAX
    }

    DROPTYPE DropType;

    public DROPTYPE _DropType
    {
        get { return DropType; }
        set { DropType = value; }
    }


    //移動時間
    bool IsMove = false;

    //public bool _IsMove
    //{
    //    get { return IsMove; }
    //    set { IsMove = value; }
    //}


    GameObject MoveGameObject;

    public GameObject _MoveGameObject
    {
        get { return MoveGameObject; }
        set { MoveGameObject = value; }
    }
    //[SerializeField]
    //public Material circle_material;
    //[SerializeField]
    //public Material cross_material;
    //[SerializeField]
    //public Material tryangle_material;
 

}


