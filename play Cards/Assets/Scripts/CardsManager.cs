using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour {

	public List<Image> CardsList = new List<Image>();
	public GameObject Hand1;
	public GameObject CardHolder;


	int playableCardCounter = 0;

	List<Image> DiamondImages = new List<Image>(); 
	List<Image> ClubImages = new List<Image>(); 
	List<Image> HeartImages = new List<Image>(); 
	List<Image> SpadesImages = new List<Image>();

	Image cardImage;
	Draggable draggble;

	CardProp cardPro;
	CardProp CardPropFirstCard;

	List<int> randomNum = new List<int>();
	int randIndex;

	void Start(){
		disreputeCards ();
		ceckCardType ();
	}

	void Update(){
		//ceckCardType ();
	}

	void ceckCardType(){
		CardPropFirstCard = CardHolder.transform.GetChild(0).GetComponent<CardProp> ();

		for (int i = 0; i < Hand1.transform.childCount; i++) {
			string cardType = setCard (i);
			if (cardType == CardPropFirstCard.Type) {
				draggble.enabled = true;

			} else if(cardType != CardPropFirstCard.Type) {
				draggble.enabled = false;
				cardImage.color = new Color32 (164,164,164,255);
				Debug.Log (CardPropFirstCard.Type);
				playableCardCounter++;
			}
		}
		if(playableCardCounter >=  Hand1.transform.childCount){
			Debug.Log (playableCardCounter);
			for (int i = 0; i < Hand1.transform.childCount; i++) {
				 setCard (i);
				draggble.enabled = true;
				cardImage.color = Color.white;
			}
		}
	}

	string setCard(int i){
		GameObject card = Hand1.transform.GetChild (i).gameObject;
		string type = card.GetComponent<CardProp> ().Type ;
		cardImage = card.GetComponent<Image> ();
		draggble = card.GetComponent<Draggable> ();

		return type;
	}

	void disreputeCards(){
		Image randomCard;
		for (int i = 0; i < 8; i++) {
			do {
				randIndex = Random.Range (0,51);
			}while(randomNum.Contains(randIndex));
			randomNum.Add (randIndex);
			randomCard = CardsList[randIndex];
			cardPro = randomCard.transform.GetComponent<CardProp> ();
			if(cardPro.Type == "Diamond"){
				DiamondImages.Add (randomCard);
			}else if(cardPro.Type == "club"){
				ClubImages.Add (randomCard);
			}else if(cardPro.Type == "Heart"){
				HeartImages.Add (randomCard);
			}else if(cardPro.Type == "Spade"){
				SpadesImages.Add (randomCard);
			}
		}

		//oreder the card in the hand.
		for (int i = 0; i < DiamondImages.Count; i++) {
			DiamondImages[i].transform.SetParent (Hand1.transform);
		}
		for (int i = 0; i < ClubImages.Count; i++) {
			ClubImages[i].transform.SetParent (Hand1.transform);
		}
		for (int i = 0; i < HeartImages.Count; i++) {
			HeartImages[i].transform.SetParent (Hand1.transform);
		}
		for (int i = 0; i < SpadesImages.Count; i++) {
			SpadesImages[i].transform.SetParent (Hand1.transform);
		}
	}


}
