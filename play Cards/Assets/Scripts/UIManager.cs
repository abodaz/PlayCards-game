using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public GameObject SVObj;
	public float startPoint;
	public float endPoint;
	public float DisToMove;

	ScrollRect ScrollView;
	Vector3 dToMove;

	public void rightBTN(){
		dToMove = new Vector3 (DisToMove,0,0);
		ScrollView = SVObj.GetComponent<ScrollRect> ();
		Vector3 lastPos = ScrollView.content.transform.localPosition;
		Vector3 newPos = lastPos - dToMove;
		if(lastPos.x > -endPoint )
			ScrollView.content.transform.localPosition = newPos;
	}
	public void liftBTN(){
		dToMove = new Vector3 (DisToMove,0,0);
		ScrollView = SVObj.GetComponent<ScrollRect> ();
		Vector3 lastPos = ScrollView.content.transform.localPosition;
		Vector3 newPos = lastPos - dToMove;
		if(lastPos.x < startPoint )
			ScrollView.content.transform.localPosition = lastPos + dToMove;
	}

}
