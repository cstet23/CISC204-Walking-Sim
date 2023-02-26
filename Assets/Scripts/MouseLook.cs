using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensHor = 9.0f;
    public float sensVert = 9.0f;
    public float minVert = -55.0f;
    public float maxVert = 55.0f;
    private float _rotationX = 0;
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null) body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
     if(axes == RotationAxes.MouseX) {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensHor, 0);
     } else if (axes == RotationAxes.MouseY) {
        _rotationX -= Input.GetAxis("Mouse Y") * sensVert;
        _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
        float rotationY = transform.localEulerAngles.y;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
     } else {
        _rotationX -= Input.GetAxis("Mouse Y") * sensVert;
        _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
        float delta = Input.GetAxis("Mouse X") * sensHor;
        float rotationY = transform.localEulerAngles.y + delta;
        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
     }
    }
}
