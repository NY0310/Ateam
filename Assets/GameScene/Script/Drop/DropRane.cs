using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRane : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    /// <summary>
    /// ドロップをレーンで管理
    /// </summary>
        public GameObject drop;

        [SerializeField]
        public Vector2 TargetPosition;
        [SerializeField]
        //ドロップの縦間隔
        public Vector2 INTERVAL_SIZE;


        //列に入るドロップの最大値
        public int MAX_DROP = 4;

        public void Init(LANEKIND lanekind)
        {
            for (int i = 0; i < MAX_DROP; i++)
            {
                GameObject inst = Create();
                TargetPosition.x += INTERVAL_SIZE.x;
                TargetPosition.y += INTERVAL_SIZE.y;
                inst.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            }
        }

        List<GameObject> DropList;


        /// <summary>
        /// ドロップを生成
        /// </summary>
        /// <returns>ドロップ</returns>
        public GameObject Create()
        {
            GameObject inst;
            inst = Drop.Init((Drop.DROPTYPE)Random.Range((float)Drop.DROPTYPE.DROP1, (float)Drop.DROPTYPE.DROP3 + 1));
            DropList.Add(inst);
            return inst;
        }

        /// <summary>
        /// ターゲットドロップの確定削除
        /// </summary>
        public void TargetDelete()
        {
            DropList.RemoveAt((int)LANENUMBER.FIRST);
            Destroy(DropList[(int)LANENUMBER.FIRST].GetComponent<GameObject>());
        }


        /// <summary>
        /// ターゲットのドロップが引数と同じ種類なら削除
        /// </summary>
        /// <param name="droptype"></param>
        /// <returns>成功か失敗か</returns>
        public bool TargetDelete(Drop.DROPTYPE droptype)
        {
            if (DropList[(int)LANENUMBER.FIRST].GetComponent<Drop>()._DropType == droptype)
            {
                TargetDelete();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 全てのドロップを一段落とす
        /// </summary>
        public void AllDropDown()
        {
            foreach (GameObject dropdata in DropList)
                dropdata.transform.position = new Vector3(transform.position.x, transform.position.y - INTERVAL_SIZE.y, transform.position.z);
        }


        /// <summary>
        /// ターゲットドロップの種類プロパティ
        /// </summary>
        public Drop.DROPTYPE _TargetDrop
        {
            get { return DropList[(int)LANENUMBER.FIRST].GetComponent<Drop>()._DropType; }
            set { DropList[(int)LANENUMBER.FIRST].GetComponent<Drop>()._DropType = value; }
        }




        //列の種類
        public enum LANEKIND
        {
            LANE1,
            LANE2,
            LANE3
        }

        //列の番号
        public enum LANENUMBER
        {
            FIRST,
            SECOND,
            THIRD,
            FOURTH,
            MAX
    }


}
