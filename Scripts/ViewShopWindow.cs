using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ViewShopWindow : MonoBehaviour 
{
	[SerializeField]
	private Button _buttonClose;

	public static ViewShopWindow Instance;

	void Awake()
	{
		Instance = this;
	}

	void Start () 
	{
		_buttonClose.onClick.AddListener (CloseShoopWindow);
	}

	public void CloseShoopWindow()
	{
		gameObject.transform.DOScale(new Vector3(0,0,0),0.5f).OnComplete(()=>{
		
		gameObject.SetActive (false);

		Destroy (gameObject);

		ScrollCamera.Instance.CanScroll = true;

		});

		ButtonPanel.Instance.StateButtonOpenShop (true);
	}
}
