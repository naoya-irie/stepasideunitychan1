using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemgenerater : MonoBehaviour {
    public GameObject carprefab;
    public GameObject coinprefab;
    public GameObject coneprefab;
    private int startpos = -160;
    private int goalpos = 120;
    private float posrange = 3.4f;

	void Start () {
        for (int i = startpos; i < goalpos; i += 15)
        {
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(coneprefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                for (int j = -1; j < 2; j++)
                {
                    int item = Random.Range(1, 11);
                    int offsetz = Random.Range(-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinprefab) as GameObject;
                        coin.transform.position = new Vector3(posrange * j, coin.transform.position.y, i + offsetz);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carprefab) as GameObject;
                        car.transform.position = new Vector3(posrange * j, car.transform.position.y, i + offsetz);
                    }
                }

            }
        }
		
	}
	
	void Update () {
        
	}
}
