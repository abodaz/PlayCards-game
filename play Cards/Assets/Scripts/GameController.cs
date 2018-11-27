using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject targetOject;
	GameObject firstCard;
	CardProp cardProp;
	public string cardType;

	void Start(){
		playGround ();
	}
	void playGround(){
		firstCard = targetOject.transform.GetChild (0).gameObject;
		cardProp = firstCard.GetComponent<CardProp> ();
		cardType = cardProp.Type;
		Debug.Log (cardType);
	}
}
