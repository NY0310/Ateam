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

    DROPTYPE DropType;

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
  

  
}


