/*
* Brought into existence by rzfzr
*/
using UnityEngine;

using System;
using System.Collections;

public class Even1s : MonoBehaviour {

	#region Declaration
	Head h;
	//public GameObject head;
	#endregion

	#region Setup
	void Start() {
		h = GameObject.Find("Head").GetComponent<Head>();
	}

	#endregion



	public void Run() {

		StartCoroutine(Next(1));


	}


	IEnumerator Next(int square) {
		int c = 0;
		while (h.ReadSquare() != square) {
			c++;
			h.Move(1);
			if (c > 100) break;
			yield return new WaitForSeconds(h.stepSpeed);
		}

		DoAfterStep(Q1);
	}

	void Q0() {//even
		print("Q0 " + h.ReadSquare());
		if (h.ReadSquare() == 1) {
			h.Move(1);
			DoAfterStep(Q1);
		} else {
			print("odd");
			DoAfterStep(Q3);
		}

	}


	void Q1() {//odd
		print("Q1 " + h.ReadSquare());
		if (h.ReadSquare() == 1) {
			h.Move(1);
			DoAfterStep(Q0);
		} else {
			print("even");
			DoAfterStep(Q2);
		}

	}

	void Q2() {
		print("Q2" + h.ReadSquare());
		h.Move(1);
		DoAfterStep(Q4);
	}

	void Q3() {
		print("Q3" + h.ReadSquare());
		h.Move(1);	
		DoAfterStep(Q5);
	}
	void Q4() {
		print("Q4" + h.ReadSquare());
		h.Write(0);
	}


	void Q5() {
		print("Q5" + h.ReadSquare());
		h.Write(1);
	}



	void DoAfterStep(Action nextMethod) {
		StartCoroutine(WasteTime(nextMethod));
	}
	//IEnumerator WasteTime() {
	//	yield return new WaitForSeconds(1f);
	//}
	IEnumerator WasteTime(Action nextMethod) {
		//SayHello();
		yield return new WaitForSeconds(h.stepSpeed);
		nextMethod();
	}

	//		StartCoroutine(h.WasteTime(0.5f,SayHello));
	void SayHello() {
		print("Hello " + Time.deltaTime);
	}

	#region Loop
	void Update() {

	}

	#endregion

}
