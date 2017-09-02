using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {


    public GameObject CirclePlayerPrefab;
    public GameObject CrossPlayerPrefab;
    public GameObject TryanglePlayerPrefab;



    // Use this for initialization
    void Start () {
        GameObject DropPrefab;
        DropPrefab = Instantiate(CirclePlayerPrefab);
        DropPrefab.GetComponent<Player>()._DropType = Drop.DROPTYPE.Circle;
        DropPrefab = Instantiate(CrossPlayerPrefab);
        DropPrefab.GetComponent<Player>()._DropType = Drop.DROPTYPE.Cross;
        DropPrefab = Instantiate(TryanglePlayerPrefab);
        DropPrefab.GetComponent<Player>()._DropType = Drop.DROPTYPE.Tryangle;
    }




    // Update is called once per frame
    void Update () {
		
	}
}
