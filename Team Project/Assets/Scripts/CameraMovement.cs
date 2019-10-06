using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    Vector2 mousePosition;
    Vector2 smoothValue;
    public float sensitivity = 5.0f;
    public float smoothness = 2.0f;

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothness, sensitivity * smoothness));
        smoothValue.x = Mathf.Lerp(smoothValue.x, md.x, 1.0f / smoothness);
        smoothValue.y = Mathf.Lerp(smoothValue.y, md.y, 1.0f / smoothness);
        mousePosition += smoothValue;
        mousePosition.y = Mathf.Clamp(mousePosition.y, -90.0f, 90.0f);

        transform.localRotation = Quaternion.AngleAxis(-mousePosition.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mousePosition.x, character.transform.up);
    }
}
