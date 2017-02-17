using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    Vector2 mouse;
    Vector2 smooth;

    public float sensitivity = 5.0f;
    public float smoothness = 2.0f;
    public bool active = false;
    GameObject character;
	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject;
	}
    public void setActive()
    {
        this.active = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(active)
        {
            Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDirection = Vector2.Scale(mouseDirection, new Vector2(sensitivity * smoothness, sensitivity * smoothness));

            smooth.x = Mathf.Lerp(smooth.x, mouseDirection.x, 1f / smoothness);
            smooth.y = Mathf.Lerp(smooth.y, mouseDirection.y, 1f / smoothness);

            mouse += smooth;
            mouse.y = Mathf.Clamp(mouse.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-mouse.y, Vector3.right);

            character.transform.localRotation = Quaternion.AngleAxis(mouse.x, character.transform.up);
        }
        
	}
}
