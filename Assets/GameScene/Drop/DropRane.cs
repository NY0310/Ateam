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

        [SerializeField]
        public Vector2 TargetPosition;
        [SerializeField]
        //ドロップの縦間隔
        public Vector2 INTERVAL_SIZE;


        //列に入るドロップの最大値
        public int MAX_DROP = 4;


    public GameObject CircleDropPrefab;
    public GameObject CrossDropPrefab;
    public GameObject TryangleDropPrefab;

    public GameObject Init(Drop.DROPTYPE droptype)
    {
        GameObject DropPrefab;
        switch (droptype)
        {
            case Drop.DROPTYPE.Circle:
                DropPrefab = Instantiate(CircleDropPrefab);
                DropPrefab.GetComponent<Drop>()._DropType = droptype;
                return DropPrefab;
            case Drop.DROPTYPE.Cross:
                DropPrefab = Instantiate(CrossDropPrefab);
                DropPrefab.GetComponent<Drop>()._DropType = droptype;
                return DropPrefab;
            case Drop.DROPTYPE.Tryangle:
                DropPrefab = Instantiate(TryangleDropPrefab);
                DropPrefab.GetComponent<Drop>()._DropType = droptype;
                return DropPrefab;
            default:
                return null;
        }
    }

    //どのレーンか
    LANEKIND LaneKind;

    public void Init(LANEKIND lanekind)
    {
        LaneKind = lanekind;

        Vector2 Pos = TargetPosition;
         Pos.x += (float)lanekind * INTERVAL_SIZE.x;
        for (int i = 0; i < MAX_DROP; i++)
        {
            GameObject inst = Create();
            Pos.y += INTERVAL_SIZE.y;
            inst.transform.position = new Vector3(Pos.x, Pos.y, transform.position.z);

        }
    }

    List<GameObject> DropList = new List<GameObject>();
   
    /// <summary>
    /// ドロップを生成
    /// </summary>
    /// <returns>ドロップ</returns>
    public GameObject Create()
    {
        GameObject inst;
        inst = Init((Drop.DROPTYPE)Random.Range((float)Drop.DROPTYPE.Circle, (float)Drop.DROPTYPE.Tryangle + 1));
        inst.transform.Translate(TargetPosition.x + (float)LaneKind * INTERVAL_SIZE.x, TargetPosition.y + INTERVAL_SIZE.y * (MAX_DROP + 1), transform.position.z);
        DropList.Add(inst);
        return inst;
    }

    /// <summary>
    /// ターゲットドロップの確定削除
    /// </summary>
    public void TargetDelete()
    {
        Destroy(DropList[(int)LANENUMBER.FIRST]);
        DropList.RemoveAt((int)LANENUMBER.FIRST);

        //削除されたら必ず移動＋作成
        Create();
        AllDropDown();

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
            dropdata.transform.position = new Vector3(dropdata.transform.position.x, dropdata.transform.position.y - INTERVAL_SIZE.y, dropdata.transform.position.z);
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
