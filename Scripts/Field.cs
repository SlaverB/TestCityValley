using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Field : MonoBehaviour
{
	public static Field Instance;

	[SerializeField]
	private Camera _Camera;

	private float _widthField;

	private float _heightField;

	private float _leftEdgeField;

	private float _rightEdgeField;

	private float _topEdgeField;

	private float _bottomEdgeField;

	public float GetLeftEdgeField
	{
		get
		{
			return _leftEdgeField;
		}
	}

	public float GetRightEdgeField
	{
		get
		{
			return _rightEdgeField;
		}
	}

	public float GetHeightEdgeField
	{
		get
		{
			return _topEdgeField;
		}
	}

	public float GetBottomEdgeField
	{
		get
		{
			return _bottomEdgeField;
		}
	}

	private Vector2 CursorWorldPosition
	{
		get
		{
			return _Camera.ScreenToWorldPoint(Input.mousePosition);
		}
	}

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		_Camera = Camera.main;
	}

	void OnEnable()
	{
		gameObject.transform.position = new Vector3 (0,0,0);

		_widthField = gameObject.GetComponent<Renderer> ().bounds.size.x;

		_leftEdgeField = gameObject.transform.position.x - _widthField / 2;

		_rightEdgeField = gameObject.transform.position.x + _widthField / 2;

		_heightField = gameObject.GetComponent<Renderer> ().bounds.size.y;

		_topEdgeField = gameObject.transform.position.y + _heightField / 2;

		_bottomEdgeField = gameObject.transform.position.y - _heightField / 2;
	}


}
