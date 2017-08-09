using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSheet", menuName = "Data/Character")]
public class CharacterSheet : ScriptableObject {

	public string displayName;
	public string faceTexturePath;
	private Texture2D _faceTexture;
	public Texture2D faceTexture{
		get {
			if(_faceTexture == null){
				_faceTexture = Resources.Load(faceTexturePath, typeof(Texture2D)) as Texture2D;
			}
			return _faceTexture;
		}
	}
	
	public void UnloadFaceTexture(){
		Resources.UnloadAsset(_faceTexture);
		_faceTexture = null;
	}

	public string description;
	public int level = 1;


	public AnimationCurve healthCurve = AnimationCurve.Linear(1, 10, 100, 9999);
	public int health {
		get {return Mathf.CeilToInt(healthCurve.Evaluate(level));
		}
	}

	public AnimationCurve strengthCurve = AnimationCurve.Linear(1, 10, 100, 9999);
	public int strength {
		get {return Mathf.CeilToInt(strengthCurve.Evaluate(level));
		}
	}
	public AnimationCurve speedCurve = AnimationCurve.Linear(1, 10, 100, 9999);
	public int speed {
		get {return Mathf.CeilToInt(speedCurve.Evaluate(level));
		}
	}
}
