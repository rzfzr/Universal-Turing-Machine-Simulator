/*
* Brought into existence by rzfzr
*/
using UnityEngine;
using UnityEngine.UI;

public class Head : MonoBehaviour {

	#region Declaration

	public Text current;
	public Transform tape;

	public GameObject s0, s1, ss;
	#endregion

	#region Setup
	void Start() {
		ReadSquare();
	}

	#endregion

	#region Loop
	void Update() {



	}





	#endregion



	public void DestroySquare() {
		RaycastHit hit;
		Ray ray = new Ray(transform.position,Vector3.down);
		if (Physics.Raycast(ray,out hit)) {
			Destroy(hit.transform.gameObject);
		}


		Invoke("ReadSquare",0.05f);

	}

	public void Move(int dir) {
		tape.transform.position -= new Vector3(dir,0,0);
		Invoke("ReadSquare",0.05f);
	}

	public void SpawnSquare(int i) {
		GameObject temp;
		if (i == 0) {
			temp = Instantiate(s0);
		} else if (i == 1) {
			temp = Instantiate(s1);
		} else {
			temp = Instantiate(ss);
		}

		temp.transform.position = new Vector3(0,0.01f,0);
		temp.transform.parent = tape.transform;
		Invoke("ReadSquare",0.05f);

	}
	public void ReadSquare() {
		RaycastHit hit;
		Ray ray = new Ray(transform.position,Vector3.down);
		if (Physics.Raycast(ray,out hit)) {
			if (hit.transform.tag == "s0") {
				current.text = "0";
				Debug.DrawLine(ray.origin,hit.point,Color.blue);

			} else if (hit.transform.tag == "s1") {
				Debug.DrawLine(ray.origin,hit.point,Color.green);
				current.text = "1";
			} else {
				Debug.DrawLine(ray.origin,hit.point,Color.grey);
				current.text = " ";
			}


		}
	}
}
