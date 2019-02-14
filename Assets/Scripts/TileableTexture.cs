using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileableTexture : MonoBehaviour {
    public Material materialAGirar;
    public bool rotarEnX, rotarEnY;
    public float scrollSpeed;
    public bool ResetearPlayerPreferences=false;

    private void Start( )
    {
        if (ResetearPlayerPreferences)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void Update () {
		if (rotarEnX)
        {
            float offset = Time.time * scrollSpeed;
            materialAGirar.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        if (rotarEnY)
        {
            float offset = Time.time * scrollSpeed;
            materialAGirar.SetTextureOffset("_MainTex", new Vector2(0,offset));
        }
	}
}
