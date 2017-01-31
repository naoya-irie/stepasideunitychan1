using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemdestroyer: MonoBehaviour {
    public GameObject carprefab;
    public GameObject coinprefab;
    public GameObject coneprefab;
    private GameObject unitychan;
    void Start () {
        unitychan = GameObject.Find("unitychan");
        if (gameObject.transform.position.z + 30 < unitychan.transform.position.z)
        { Destroy(gameObject); }
		
	}
	

	void Update () {
		
	}
}
