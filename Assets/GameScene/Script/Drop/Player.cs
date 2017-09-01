using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public DropManager dropmanager;

    Drop.DROPTYPE droptype = Drop.DROPTYPE.MAX;

    public void Attack()
    {
        GetComponent<DropManager>().TargetDelete(droptype);
    }   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       if(GetComponent<DropManager>().IfNeeded())
        {

        }
    }
}
