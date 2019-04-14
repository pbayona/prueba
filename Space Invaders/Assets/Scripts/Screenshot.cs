using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour {
	
	public Camera myCamera;
	public bool photo;

	public void OnPostRender() 
	{
		if (photo) {
			photo = false;
			RenderTexture renderTexture = myCamera.targetTexture;
		
			Texture2D renderResult = new Texture2D (renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
			Rect rect = new Rect (0, 0, renderTexture.width, renderTexture.height);
			renderResult.ReadPixels (rect, 0, 0);

			byte[] byteArray = renderResult.EncodeToPNG ();
			System.IO.File.ReadAllBytes ("/CameraScreenshot.png");
			System.IO.File.WriteAllBytes (Application.dataPath + "/CameraScreenshot.png", byteArray);
			Debug.Log ("Saved CameraScreenshot.png");

			RenderTexture.ReleaseTemporary (renderTexture);
			myCamera.targetTexture = null;
		}
		
	}

	public void takeScreenshot(int[]array)
	{
		myCamera.targetTexture = RenderTexture.GetTemporary (array[0], array[1], 16);
		photo = true;

	}

}
