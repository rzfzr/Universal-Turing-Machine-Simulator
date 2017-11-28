/*
* Brought into existence by rzfzr
*/
using UnityEngine;
using UnityEngine.UI;

public class SpawnTape : MonoBehaviour {

	#region Declaration

	public GameObject s0, s1, ss;
	public InputField input;

	#endregion

	#region Setup
	void Start() {
		input.text = "111111";
	}

	#endregion

	#region Loop
	void Update() {


	}

	#endregion


	public void CleanAll(string tag) {
		GameObject[] used = GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject go in used) {
			Destroy(go);
		}
	}

	public void Spawn() {

		CleanAll("s0");
		CleanAll("s1");
		CleanAll("ss");


		GameObject temp;
		string tape = input.text;
		//foreach (char c in tape) 
		for (int i = 0; i < tape.Length; i++) {
			if (tape[i] == '0') {
				temp = Instantiate(s0);
			} else if (tape[i] == '1') {
				temp = Instantiate(s1);
			} else {
				temp = Instantiate(ss);
			}

			temp.transform.position = new Vector3(i + 1,0.01f,0);
			temp.transform.parent = transform;
		}

	}

}
