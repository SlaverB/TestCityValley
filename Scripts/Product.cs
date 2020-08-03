using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Product : MonoBehaviour,IDragHandler,IEndDragHandler,IBeginDragHandler,IPointerDownHandler,IEventSystemHandler 
{
	[SerializeField]
	private eProduct _eTypeProduct;

	[SerializeField]
	private eSizeProduct _eSizeProduct;

	public Vector2 size;

	public Vector2 matrixPosition = new Vector2 (20f, 20f);

	public Vector2 tempMatrixPosition;

	private Camera _Camera;

	Vector2 deltaMouse;

	private Vector2 CursorWorldPosition
	{
		get
		{
			//#if (UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE) && !UNITY_EDITOR
			//	if (Input.touchCount == 1 )
			//		return m_Camera.ScreenToWorldPoint(Input.GetTouch(0).position);
			//#else
					return _Camera.ScreenToWorldPoint(Input.mousePosition);
			//#endif
		}
	}

	void Start()
	{
		_Camera = Camera.main;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		tempMatrixPosition = matrixPosition;

		TileMap.Instance.GetCurrentTile(gameObject.transform.position); 

		Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		deltaMouse = worldPos - gameObject.transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		ScrollCamera.Instance.CanScroll = false;

		this.transform.position = CursorWorldPosition;

		switch (_eTypeProduct) 
		{

		case eProduct.House_1:

			ButtonPanel.Instance.EditTextDefinition (_eTypeProduct.ToString (), _eSizeProduct.ToString ());
			break;

		case eProduct.House_2:

			ButtonPanel.Instance.EditTextDefinition (_eTypeProduct.ToString(),_eSizeProduct.ToString());
			break;

		case eProduct.House_3:

			ButtonPanel.Instance.EditTextDefinition (_eTypeProduct.ToString(),_eSizeProduct.ToString());
			break;

		case eProduct.House_4:

			ButtonPanel.Instance.EditTextDefinition (_eTypeProduct.ToString(),_eSizeProduct.ToString());
			break;
		}

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

		TileMap.Instance.GetCurrentTile( gameObject.transform.position); 

		gameObject.transform.position =  new Vector3(mousePosition.x - deltaMouse.x, mousePosition.y - deltaMouse.y, 0);
	}
		
	public void OnEndDrag(PointerEventData eventData)
	{
		ScrollCamera.Instance.CanScroll = true;

		ButtonPanel.Instance.ClearTextDefinition();

		gameObject.transform.position = TileMap.Instance.GetMatrixTilePosition(TileMap.Instance.m_currentTile._matrixPos);

		matrixPosition =  TileMap.Instance.m_currentTile._matrixPos;

		tempMatrixPosition =  matrixPosition;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		ScrollCamera.Instance.CanScroll = false;
	}
}

enum eSizeProduct
{
	One_Cell,
	Two_Cell,
	Three_Cell,
	Four_Cell
}
