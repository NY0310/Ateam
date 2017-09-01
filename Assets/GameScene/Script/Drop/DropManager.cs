﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}

    const int MAX_RANE = 3;
    List<GameObject> DropRaneList = new List<GameObject>();

    /// <summary>
    /// 全てのレーンを総括するクラス
    /// </summary>
    /// <summary>
    /// 全てのレーンを生成
    /// </summary>
    /// 


    // Use this for initialization
    void Start()
    {
        Init();
    }

    public GameObject DropRanePrefab;

     public void Init()
     {
         
         for (int i = 0; i < MAX_RANE; i++)
         {
              GameObject inst;
              inst = Instantiate(DropRanePrefab);
              DropRaneList.Add(inst);
              DropRaneList[i].GetComponent<DropRane>().Init((DropRane.LANEKIND)i);
                  //droprane[i].Init((DropRane.LANEKIND)i);
         }
     }



     /// <summary>
     /// 全てのレーンにドロップを生成
     /// </summary>
     public void Create()
     {
         for (int i = 0; i < MAX_RANE; i++)
         {
         DropRaneList[i].GetComponent<DropRane>().Create();
         }
     }

     /// <summary>
     /// 全てのレーンのターゲットドロップ確定削除
     /// </summary>
     public void TargetDelete()
     {
         for (int i = 0; i < MAX_RANE; i++)
         {
              DropRaneList[i].GetComponent<DropRane>().TargetDelete();
         }
     }


     /// <summary>
     /// 全てのレーンのターゲットドロップが引数と同じ種類なら削除
     /// </summary>
     /// <param name="droptype"></param>
     /// <returns>成功した回数</returns>
     public int TargetDelete(Drop.DROPTYPE droptype)
     {
         //成功した回数
         int successTimes = 0;
         bool IsSuccess;
         for (int i = 0; i < MAX_RANE; i++)
         {
             IsSuccess = DropRaneList[i].GetComponent<DropRane>().TargetDelete(droptype);

         if (IsSuccess)
                 successTimes++;
         IsSuccess = false;
         }

         return successTimes;

     }

     /// <summary>
     /// 全てのレーンのドロップを一段落とす
     /// </summary>
     public void AllDropDown()
     {
         for (int i = 0; i < MAX_RANE; i++)
         {
         DropRaneList[i].GetComponent<DropRane>().AllDropDown();
     }
 }

     /// <summary>
     /// 全てのレーンのターゲットドロップが同じ種類なら全削除する
     /// </summary>
     /// <returns>全削除したかどうか</returns>
     public bool IfNeeded()
     {
         Drop.DROPTYPE droptype = Drop.DROPTYPE.MAX;
         Drop.DROPTYPE _droptype;
         for (int i = 0; i < MAX_RANE; i++)
         {
             _droptype = DropRaneList[i].GetComponent<DropRane>()._TargetDrop;
         ;
         if (droptype != _droptype)
             {
                 break;
             }

             //全て同じドロップなら
             if (i == MAX_RANE - 1)
             {
                 //全てのターゲットドロップ削除
                 for (int j = 0; j < MAX_RANE; j++)
                 {
                 DropRaneList[i].GetComponent<DropRane>().Create();
             }
             return true;
             }
         }

         return false;
     }

   
 }
