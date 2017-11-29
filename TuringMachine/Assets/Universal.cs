/*
* Brought into existence by rzfzr
*/
using UnityEngine;

using System;
using System.Collections;
using UnityEngine.UI;

public class Universal : MonoBehaviour {

	#region Declaration

	public InputField[] h0, h1, hs;
	int states = 6;

	#endregion

	#region Setup
	void Start() {

		EvenTest();
	}



	void EvenTest() {

		h0[0].text = "0r3"; h1[0].text = "1r1"; hs[0].text = "sr3";
		h0[1].text = "0r2"; h1[1].text = "1r0"; hs[1].text = "sr2";
		h0[2].text = "0r4"; h1[2].text = "1r4"; hs[2].text = "sr4";
		h0[3].text = "0r5"; h1[3].text = "1r5"; hs[3].text = "sr5";

		//finals
		h0[4].text = "0sf"; h1[4].text = "0sf"; hs[4].text = "0sf";
		h0[5].text = "1sf"; h1[5].text = "1sf"; hs[5].text = "1sf";


	}
	#endregion
	public void Q0() {


	}



	#region Loop
	void Update() {

	}

	#endregion

}
