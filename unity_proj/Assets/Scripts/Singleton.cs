using UnityEngine;
using System.Collections;

public abstract class Singleton<T> : MonoBehaviour where T : UnityEngine.Component {
	private static T instance;
	public static T Instance(){
		if(instance == null){
			T sceneInstance = GameObject.FindObjectOfType<T>();
			if(sceneInstance == null){
				GameObject sceneStub = new GameObject();
				instance = sceneStub.AddComponent<T>();
				DontDestroyOnLoad(instance);
			}
			else if(instance != sceneInstance){
				instance = sceneInstance;
			}
		}
		return instance;
	}
}
