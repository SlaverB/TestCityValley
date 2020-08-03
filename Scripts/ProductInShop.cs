using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProductInShop : MonoBehaviour, IPointerDownHandler
{
	[SerializeField]
	private eProduct eTypeProduct;

	public void OnPointerDown(PointerEventData eventData)
	{
		switch(eTypeProduct)
		{

		case eProduct.House_1:

			ViewShopWindow.Instance.CloseShoopWindow ();

			TileMapManager.Instance.BuyObjectInShop (eTypeProduct.ToString());
			break;

		case eProduct.House_2:

			ViewShopWindow.Instance.CloseShoopWindow ();
		
			TileMapManager.Instance.BuyObjectInShop (eTypeProduct.ToString());
			break;

		case eProduct.House_3:

			ViewShopWindow.Instance.CloseShoopWindow ();
			
			TileMapManager.Instance.BuyObjectInShop (eTypeProduct.ToString());
			break;

		case eProduct.House_4:

			ViewShopWindow.Instance.CloseShoopWindow ();
			
			TileMapManager.Instance.BuyObjectInShop (eTypeProduct.ToString());
			break;
		}
	}
}

enum eProduct
{
	House_1,
	House_2,
	House_3,
	House_4
}
