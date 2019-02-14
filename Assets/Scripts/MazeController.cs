using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour {
    public GameObject Mecu;
    public Camera cam;
    public float velocidad;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Move the cube if the screen has the finger moving.
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 v = new Vector3(touch.position.x, touch.position.y, 10);
                Mecu.transform.position = (
                    cam.ScreenToWorldPoint(v)
                    );

            }
        }
    }
}
