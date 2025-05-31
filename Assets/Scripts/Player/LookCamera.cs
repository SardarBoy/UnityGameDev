// Cleaned version below
using UnityEngine;

public class LookCamera : MonoBehaviour
{
	public float speedNormal = 10f;

	public float speedFast = 50f;

	public float mouseSensitivityX = 5f;

	public float mouseSensitivityY = 5f;

	private float rotY;

	private void Start()
	{
		if (GetComponent<Rigidbody>() != null)
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	private void Update()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		if (Input.GetMouseButton(1))
		{
			float num = ((Component)this).transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouseSensitivityX;
			rotY += Input.GetAxis("Mouse Y") * mouseSensitivityY;
			rotY = Mathf.Clamp(rotY, -89.5f, 89.5f);
			((Component)this).transform.localEulerAngles = new Vector3(0f - rotY, num, 0f);
		}
		if (Input.GetKey((KeyCode)117))
		{
			((Component)this).gameObject.transform.localPosition = new Vector3(0f, 3500f, 0f);
		}
	}
}
