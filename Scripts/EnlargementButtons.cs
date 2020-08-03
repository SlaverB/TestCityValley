using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EnlargementButtons : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
	[SerializeField]
	private eTypeButton _typeButton;

	bool select;

	void Update () 
	{
		if (select == true)
		{
			switch (_typeButton) 
			{

			case eTypeButton.buttonUp:

				ControlCamera.Instance.EditSizeCamera (-0.1f);
				break;

			case eTypeButton.buttonDown:

				ControlCamera.Instance.EditSizeCamera (0.1f);
				break;
			}
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		select = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		select = false;
	}
}
enum eTypeButton
{
	buttonUp,
	buttonDown
}
