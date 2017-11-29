/*
* Brought into existence by rzfzr
*/
using UnityEngine;

using System;
using System.Collections;


public class Sum : MonoBehaviour {

	#region Declaration

	Head h;
	//public GameObject head;
	#endregion

	#region Setup
	void Start() {
		h = GameObject.Find("Head").GetComponent<Head>();
	}

	#endregion

	#region Loop
	void Update() {

	}

	#endregion



	public void Run() {

		StartCoroutine(Next(1,0));


	}


	IEnumerator Next(int square0,int square1) {
		int c = 0;
		while (h.ReadSquare() != square0 && h.ReadSquare() != square1) {
			c++;
			h.Move(1);
			if (c > 100) break;
			yield return new WaitForSeconds(h.stepSpeed);
		}

		DoAfterStep(Q0);


	}

	void Q0() {
		print("Q0 " + h.ReadSquare());
		if (h.ReadSquare() == 0) {
			h.DestroySquare();
			h.Write(1);
			h.Move(1);
			DoAfterStep(Q0);
		} else if (h.ReadSquare() == 1) {
			h.DestroySquare();
			h.Write(0);
			h.Move(1);
			DoAfterStep(Q0);
		} else {
			h.Move(-1);
			DoAfterStep(Q1);
		}

	}


	void Q1() {//odd
		print("Q1 " + h.ReadSquare());

		if (h.ReadSquare() == 1) {
			h.DestroySquare();
			h.Write(0);
			h.Move(-1);
			DoAfterStep(Q1);
		} else if (h.ReadSquare() == 0) {
			h.DestroySquare();
			h.Write(1);
			h.Move(-1);
			DoAfterStep(Q2);
		}

		//h.Move(1);
		//DoAfterStep(Q4);
	}

	void Q2() {
		print("Q2 " + h.ReadSquare());
		if (h.ReadSquare() == 0 || h.ReadSquare() == 1) {
			h.Move(-1);
			DoAfterStep(Q2);
		} else {
			h.Move(1);
			DoAfterStep(Q3);
		}
	}

	void Q3() {
		print("Q3 " + h.ReadSquare());
		if (h.ReadSquare() == 0) {
			h.DestroySquare();
			h.Write(1);
			h.Move(1);
			DoAfterStep(Q3);
		} else if (h.ReadSquare() == 1) {
			h.DestroySquare();
			h.Write(0);
			h.Move(1);
			DoAfterStep(Q3);
		} else {

			h.Move(1);
			DoAfterStep(Q4);
		}
		//h.Move(1);
		//DoAfterStep(Q5);
	}

	void Q4() {
		print("Q4" + h.ReadSquare());
		if (h.ReadSquare() == 0 || h.ReadSquare() == 1) {
			h.Move(1);
			DoAfterStep(Q4);
		} else {
			h.Move(-1);
			DoAfterStep(Q5);
		}

		//h.Write(0);
	}

	void Q5() {
		print("Q5" + h.ReadSquare());
		if (h.ReadSquare() == 1) {
			h.DestroySquare();
			h.Write(0);
			h.Move(-1);
			DoAfterStep(Q5);
		} else if (h.ReadSquare() == 0) {
			h.DestroySquare();
			h.Write(1);
			h.Move(-1);
			DoAfterStep(Q6);

		}

	}

	void Q6() {
		print("Q6" + h.ReadSquare());
		if (h.ReadSquare() == 0 || h.ReadSquare() == 1) {
			h.Move(-1);
			DoAfterStep(Q6);
		} else {
			h.Move(-1);
			DoAfterStep(Q7);
		}


	}
	void Q7() {
		print("Q7" + h.ReadSquare());
		if (h.ReadSquare() == 0 || h.ReadSquare() == 1) {
			h.Move(-1);
			DoAfterStep(Q7);
		} else {
			h.Move(1);
			DoAfterStep(Q0);
		}


	}


	void DoAfterStep(Action nextMethod) {
		StartCoroutine(WasteTime(nextMethod));
	}

	IEnumerator WasteTime(Action nextMethod) {
		//SayHello();
		yield return new WaitForSeconds(h.stepSpeed);
		nextMethod();
	}
}
