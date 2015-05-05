using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public Texture2D crosshairTexture;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height), crosshairTexture);
	}
}
