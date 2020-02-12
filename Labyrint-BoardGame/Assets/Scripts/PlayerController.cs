using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float rotateFactor = 20f;

    private float maxRotationX = 6.0f;
    private float maxRotationZ = 6.0f;

    public GameObject XPlane;
    public GameObject ZPlane;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float rotateX = Input.GetAxisRaw("Horizontal") * rotateFactor * Time.deltaTime;
        float rotateZ = Input.GetAxisRaw("Vertical") * rotateFactor * Time.deltaTime;    

        Debug.Log((XPlane.transform.eulerAngles.x + rotateX));
        if ((XPlane.transform.eulerAngles.x + rotateX) < maxRotationX && (XPlane.transform.eulerAngles.x + rotateX) > -maxRotationX)
        {
            XPlane.transform.eulerAngles += new Vector3(rotateZ, 0, -rotateX);
        }
        // ZPlane.transform.eulerAngles = new Vector3(0, 0, -rotateX);
    }
}
