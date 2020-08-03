using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlCamera : MonoBehaviour 
{
	[SerializeField]
	private Camera _camera;

	public static ControlCamera Instance;

	private float speed = 5;

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		_camera.orthographicSize = 40f;
	}
	
	void Update () 
	{
		_camera.orthographicSize += Input.GetAxis ("Mouse ScrollWheel");

		if (_camera.orthographicSize >= 60) 
		{
			_camera.orthographicSize = 60;
		}

		if (_camera.orthographicSize <= 40) 
		{
			_camera.orthographicSize = 40;
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			if (gameObject.transform.position.x <= Field.Instance.GetRightEdgeField) 
			{
				speed = 5;

				gameObject.transform.position += gameObject.transform.right* speed * Time.deltaTime;

				if (gameObject.transform.position.x > Field.Instance.GetRightEdgeField) 
				{
					speed = 0;
				}
			}
		}

		if (Input.GetKey (KeyCode.A)) 
		{
			if (gameObject.transform.position.x >= Field.Instance.GetLeftEdgeField) 
			{
				speed = 5;

				gameObject.transform.position += (-gameObject.transform.right)* speed * Time.deltaTime;

				if (gameObject.transform.position.x > Field.Instance.GetRightEdgeField) 
				{
					speed = 0;
				}
			}
		}

		if (Input.GetKey (KeyCode.W)) 
		{	
			if (gameObject.transform.position.y <= Field.Instance.GetHeightEdgeField) 
			{
				speed = 5;

				gameObject.transform.position += gameObject.transform.up* speed * Time.deltaTime;

				if (gameObject.transform.position.y > Field.Instance.GetHeightEdgeField) 
				{
					speed = 0;
				}
			}
		}

		if (Input.GetKey (KeyCode.S)) 
		{
			if (gameObject.transform.position.y >= Field.Instance.GetBottomEdgeField) 
			{
				speed = 5;

				gameObject.transform.position += (-gameObject.transform.up)* speed * Time.deltaTime;

				if (gameObject.transform.position.y < Field.Instance.GetBottomEdgeField) 
				{
					speed = 0;
				}
			}
		}
	}

	public void EditSizeCamera(float count)
	{
		_camera.orthographicSize += count;
	}
}
