using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		
	}


    /// <summary>
    /// 全てのレーンを総括するクラス
    /// </summary>
        const int MAX_RANE = 3;
        DropRane[] droprane = null;

        /// <summary>
        /// 全てのレーンを生成
        /// </summary>
        /// 

        // Use this for initialization
        void Start()
        {
            Init();
        }

        public void Init()
        {
            for (int i = 0; i > MAX_RANE; i++)
            {
                droprane[i] = new DropRane();
                droprane[i].Init((DropRane.LANEKIND)i);
            }
        }




        /// <summary>
        /// 全てのレーンにドロップを生成
        /// </summary>
        public void Create()
        {
            for (int i = 0; i < MAX_RANE; i++)
            {
                droprane[i].Create();
            }
        }

        /// <summary>
        /// 全てのレーンのターゲットドロップ確定削除
        /// </summary>
        public void TargetDelete()
        {
            for (int i = 0; i < MAX_RANE; i++)
            {
                droprane[i].TargetDelete();
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
                IsSuccess = droprane[i].TargetDelete(droptype);
                if (IsSuccess)
                    successTimes++;
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
                droprane[i].AllDropDown();
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
                _droptype = droprane[i]._TargetDrop;
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
                        droprane[i].TargetDelete();
                    }
                    return true;
                }
            }

            return false;
        }


 }
