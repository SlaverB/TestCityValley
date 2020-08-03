using System.Collections.Generic;
using UnityEngine;

public class TileMapManager : MonoBehaviour
{
	public static TileMapManager Instance;

	[SerializeField]
	private Camera _Camera;

 	private TileMap m_tileMap;

	private readonly string _levelpath = "Prefabs/";


	public Vector2 tileSize;

	public Vector2 mapSize;
 
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
		m_tileMap = TileMap.Instance; 
 
		m_tileMap.CreateMap(gameObject.transform.position,mapSize,tileSize);

		CreateObjects();
	}
 
	void OnDrawGizmos()
	{

		foreach (Tile tile in TileMap.Instance._tiles)
		{
			for (int i = 0;i<tile._points.Count;++i)
			{
				if(i == tile._points.Count-1)
				{		
					Gizmos.DrawLine(tile._points[i],tile._points[0]);
				}
                else
                {
					Gizmos.DrawLine(tile._points[i],tile._points[i+1]);
				}
			}
		}
	}

	private void CreateObjects()
    {
		List<Tile> edgeTile = new List<Tile>();
		foreach (Tile tile in TileMap.Instance._tiles)
		{
			if(tile._matrixPos.x == 0 || tile._matrixPos.x == mapSize.x-1|| tile._matrixPos.y == 0 || tile._matrixPos.y == mapSize.y - 1)
            {
				edgeTile.Add(tile);
				if((tile._matrixPos.x > 0 && tile._matrixPos.x % 2 == 0) || (tile._matrixPos.y > 0 && tile._matrixPos.y % 2 == 0))
                {
					if ((mapSize.x - 1) % 2 == 0 && tile._matrixPos.y % 2 == 0 && tile._matrixPos.x == mapSize.x - 1 
						|| (mapSize.y - 1) % 2 == 0 && tile._matrixPos.x % 2 == 0 && tile._matrixPos.y == mapSize.x - 1)
                    {
						continue;
                    }
					GameObject go = Instantiate(Resources.Load(_levelpath + Random.Range(1, 14), typeof(GameObject))) as GameObject;
					go.transform.position = tile._tilePos;
				}
			}
		}
	}
	public void BuyObjectInShop(string nameProduct)
	{
		GameObject go = Instantiate (Resources.Load(("ProductInShop/"+nameProduct),typeof(GameObject))) as GameObject;

		go.transform.parent = gameObject.transform;

		go.transform.localScale = new Vector3 (0.1f,0.1f,0.1f);

		go.SetActive (true);

		go.transform.position = CursorWorldPosition;
	}	
	
}



