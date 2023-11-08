using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelScript : MonoBehaviour
{

    public Transform rearWheel;
    public float wheelieForce = 1000.0f;
    public float maxWheelieAngle = 45.0f;

    private bool isWheelieActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isWheelieActive)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 wheelieDirection = -transform.up; // Arah ke atas relatif terhadap kendaraan
            rb.AddForceAtPosition(wheelieDirection * wheelieForce, rearWheel.position, ForceMode.Impulse);
            isWheelieActive = true;
        }

        if (isWheelieActive)
        {
            float currentWheelieAngle = Mathf.Clamp(rearWheel.localEulerAngles.x, 0.0f, maxWheelieAngle);
            rearWheel.localEulerAngles = new Vector3(currentWheelieAngle, 0, 0);
        }
    }

}
