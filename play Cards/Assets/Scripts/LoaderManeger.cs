using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaderManeger : MonoBehaviour {

	public Slider slider;


	void Start(){
		if(SceneManager.GetActiveScene().buildIndex == 0)
		sceneLoader (1);
	}

	public void sceneLoader(int sceneNum){
		StartCoroutine (loadScene(sceneNum));
	}

	IEnumerator loadScene(int sceneNum){
		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneNum);
		while(!operation.isDone){
			float loadProg = Mathf.Clamp01 (operation.progress/0.9f);
			Debug.Log (loadProg);
			slider.value = loadProg;	

			yield return null;
		}
	}
}
