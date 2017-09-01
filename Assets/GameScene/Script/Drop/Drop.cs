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
        DROP1,
        DROP2,
        DROP3,
        MAX
    }

    static DROPTYPE DropType = DROPTYPE.DROP1;

    public DROPTYPE _DropType
    {
        get { return DropType; }
        set { DropType = value; }
    }



    //[SerializeField]
    //public Material circle_material;
    //[SerializeField]
    //public Material cross_material;
    //[SerializeField]
    //public Material tryangle_material;
 
    public static GameObject Init(DROPTYPE droptype)
    {
        //属性を登録
        DropType = droptype;
        GameObject CircleDropPrefab = (GameObject)Resources.Load("Drop1");
        GameObject CrossDropPrefab = (GameObject)Resources.Load("Drop2");
        GameObject TryangleDropPrefab = (GameObject)Resources.Load("Drop3");

        switch (droptype)
        {
            case DROPTYPE.DROP1:
                return Instantiate(CircleDropPrefab);
            case DROPTYPE.DROP2:
                return Instantiate(CrossDropPrefab);
            case DROPTYPE.DROP3:
                return Instantiate(TryangleDropPrefab);
            default:
                return null;
        }
    }


  
}


