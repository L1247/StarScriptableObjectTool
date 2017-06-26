using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMyGameDataMono : MonoBehaviour {
    public MyGameData m_MyGameData;
    // Use this for initialization
    void Start () {
        print( m_MyGameData.Speed );
        print( m_MyGameData.Time );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
