using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ButtonPanel : MonoBehaviour 
{
	[SerializeField]
	private Button _buttonOpenShop;

	[SerializeField]
	private Button _buttonActiveGrid;

	[SerializeField]
	private Text _textDefinition;

	[SerializeField]
	private Image _ImageBgDefinition;

	public static Action GridButtonPressed;
	public static ButtonPanel Instance;

	void Awake()
	{
		Instance = this;
	}

	void OnEnable()
	{
		_ImageBgDefinition.fillAmount = 0;
	}

	void Start () 
	{
		_buttonOpenShop.onClick.AddListener (OpenShop);

		_buttonActiveGrid.onClick.AddListener (ActiveGrid);
	}

	private void OpenShop()
	{
		GameObject go = Instantiate (Resources.Load("ShopWindow",typeof(GameObject))) as GameObject;

		go.transform.parent = transform.parent;

		go.SetActive (true);

		go.transform.localPosition = new Vector3 (0,0,0);

		go.transform.localScale = new Vector3 (0,0,0);
								
		go.transform.DOScale(new Vector3(1,1,1),0.5f);

		ScrollCamera.Instance.CanScroll = false;

		StateButtonOpenShop (false);
	}

	private void ActiveGrid()
	{
		GridButtonPressed?.Invoke();
	}

	public void EditTextDefinition(string Name, string size)
	{
		_textDefinition.text = "Name: " + Name + "\n"+ "Size: "+ size;

		_ImageBgDefinition.DOFillAmount (1, 0.3f);
	}
	public void ClearTextDefinition()
	{
		_textDefinition.text = "";

		_ImageBgDefinition.DOFillAmount (0, 0.3f);
	}
	public void StateButtonOpenShop(bool state)
	{
		_buttonOpenShop.interactable = state;
	}
}
