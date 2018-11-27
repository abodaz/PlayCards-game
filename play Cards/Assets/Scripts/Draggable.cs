using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
	Transform FirstParent;
	Vector3 FirstPosition;


	public void OnBeginDrag (PointerEventData eventData){
		FirstParent = transform.parent;
		FirstPosition = transform.position;

	}

	public void OnDrag (PointerEventData eventData){
		transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData){

		if (transform.position.y > FirstPosition.y +50) {
			transform.SetParent (FirstParent.parent.GetChild(0).transform);
			RectTransform rt = transform.GetComponent<RectTransform> ();
			rt.localPosition = FirstParent.parent.GetChild (0).localPosition;
			transform.localScale = new Vector3 (0.37f,0.37f,0f);
			transform.GetComponent<Draggable> ().enabled = false;
		} else {
			transform.position = FirstPosition;
		}
		//transform.SetParent (FirstParent);
	}

}
