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
	Head h;
	int qCounter = 0;
	#endregion

	#region Setup
	void Start() {

		h = GameObject.Find("Head").GetComponent<Head>();
		EvenTest();
	}



	void EvenTest() {

		h0[0].text = "0s3"; h1[0].text = "1r1"; hs[0].text = "ss3";
		h0[1].text = "0s2"; h1[1].text = "1r0"; hs[1].text = "ss2";
		h0[2].text = "0r4"; h1[2].text = "1r4"; hs[2].text = "sr4";
		h0[3].text = "0r5"; h1[3].text = "1r5"; hs[3].text = "sr5";
		//finals
		h0[4].text = "0sf"; h1[4].text = "0sf"; hs[4].text = "0sf";
		h0[5].text = "1sf"; h1[5].text = "1sf"; hs[5].text = "1sf";


	}
	#endregion




	public void Run() {

		state = 1;
		Q();

	}


	public int state;

	void Q() {
		qCounter++;
		print("count: " + qCounter + " state: " + state);
		if (state == -1) {
			return;
		}
		int head = h.ReadSquare();
		if (head == 0) {
			h.DestroySquare();
			h.Write((int)char.GetNumericValue(h0[state].text[0]));
			h.MoveC(h0[state].text[1]);
			state = ((int)char.GetNumericValue(h0[state].text[2]));
			DoAfterStep(Q);
		} else if (head == 1) {
			h.DestroySquare();
			h.Write((int)char.GetNumericValue(h1[state].text[0]));
			h.MoveC(h1[state].text[1]);
			state = ((int)char.GetNumericValue(h1[state].text[2]));
			DoAfterStep(Q);
		} else {
			h.DestroySquare();
			h.Write((int)char.GetNumericValue(hs[state].text[0]));
			h.MoveC(hs[state].text[1]);
			state = ((int)char.GetNumericValue(hs[state].text[2]));
			DoAfterStep(Q);
		}
	}


	void DoAfterStep(Action nextMethod) {
		StartCoroutine(WasteTime(nextMethod));
	}
	IEnumerator WasteTime(Action nextMethod) {
		yield return new WaitForSeconds(h.stepSpeed);
		nextMethod();
	}


}
