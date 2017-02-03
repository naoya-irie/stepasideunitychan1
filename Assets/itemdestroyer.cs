using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdestroyer: MonoBehaviour {
    public GameObject carprefab;
    public GameObject coinprefab;
    public GameObject coneprefab;
    private GameObject unitychan;
    void Start () {
        
		
	}
	

	void Update () {
        unitychan = GameObject.Find("unitychan");
        if (gameObject.transform.position.z + 10 < unitychan.transform.position.z)
        { Destroy(gameObject); }

    }
}
