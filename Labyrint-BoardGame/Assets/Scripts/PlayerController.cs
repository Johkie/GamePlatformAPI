using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotateFactor = 20f;

    private float minRotationX = -6.0f;
    private float maxRotationX = 6.0f;

    private float minRotationZ = -6.0f;
    private float maxRotationZ = 6.0f;

    public Transform XPlane;
    public Transform ZPlane;

    void FixedUpdate()
    {
        RotateBoard();
    }

    private float ClampAround180(float value)
    {
        float newValue = 0;

        if (value >= 0 && value < 180)
        {
            return value;
        }
        else if (value > 180)
        {
            newValue = value % 180;
            newValue -= 180;
        }

        return newValue;
    }

    private void RotateBoard()
    {
        float rotateZ = Input.GetAxisRaw("Horizontal") * rotateFactor * Time.deltaTime;
        float rotateX = Input.GetAxisRaw("Vertical") * rotateFactor * Time.deltaTime;

        XPlane.transform.eulerAngles += new Vector3(rotateX, 0, -rotateZ);

        // Clamp X values
        if (ClampAround180(XPlane.transform.eulerAngles.x) > maxRotationX)
        {
            XPlane.transform.eulerAngles = new Vector3(maxRotationX, XPlane.transform.eulerAngles.y, XPlane.transform.eulerAngles.z);
        }
        else if (ClampAround180(XPlane.transform.eulerAngles.x) < minRotationX)
        {
            XPlane.transform.eulerAngles = new Vector3(360 + minRotationX, XPlane.transform.eulerAngles.y, XPlane.transform.eulerAngles.z);
        }

        // Clamp Z values
        if (ClampAround180(XPlane.transform.eulerAngles.z) > maxRotationZ)
        {
            XPlane.transform.eulerAngles = new Vector3(XPlane.transform.eulerAngles.x, XPlane.transform.eulerAngles.y, maxRotationZ);
        }
        else if (ClampAround180(XPlane.transform.eulerAngles.z) < minRotationZ)
        {
            XPlane.transform.eulerAngles = new Vector3(XPlane.transform.eulerAngles.x, XPlane.transform.eulerAngles.y, 360 + minRotationZ);
        }

        // Set Zplane to Xplanes rotation
        ZPlane.transform.eulerAngles = new Vector3(ZPlane.transform.eulerAngles.x, ZPlane.transform.eulerAngles.y, XPlane.transform.eulerAngles.z);
    }
}
