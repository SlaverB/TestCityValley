using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class TileMap 
{
	public Vector2 tileSize;

	public Tile m_currentTile;
	
    public List<Tile> _tiles;//Список в котором все тайлы

    private static TileMap instance;  	
 
	public static TileMap Instance
	{
	   get 
	   {
	       	if (instance == null)
	        {
	            instance = new TileMap();
	        }
	        return instance;
	    }
	}

	private TileMap ()
	{
		_tiles = new List<Tile>();
	}

	public void AddTileInList(Tile tile)//Добавлять в список новый тайл
	{
		_tiles.Add(tile);
	}

	public void GetCurrentTile(Vector3 inputPos)
	{
		foreach(Tile _tile in _tiles)
		{
			if (_tile.CheckTitle (inputPos)) 
			{
				m_currentTile = _tile;

				break;
			} 
		}
	}
    
	public void CreateMap(Vector3 objectPosition,Vector2 mapSize,Vector2 tileSize)
	{
		tileSize = new Vector2(tileSize.x/100f, tileSize.y/100f);//задаем размер одного тайла

        Vector3 currentPos = objectPosition;	

		for(int i = 0;i< mapSize.x;++i)
		{
			if(i == 0)
			{
				currentPos = new Vector3( currentPos.x,(currentPos.y - tileSize.y/2f) ,0);
			}
			else
			{
				currentPos = new Vector3((currentPos.x +(tileSize.x/2f )) + tileSize.x/2f * mapSize.x,(currentPos.y - tileSize.y/2f) + tileSize.y/2f * mapSize.y  ,0);
			}
			
			for(int j = 0;j<mapSize.y;++j)
			{
				 Tile tile  = new Tile(new Vector2(j,i),currentPos,tileSize);

				 AddTileInList(tile);

				currentPos  = new Vector3(currentPos.x - tileSize.x/2, currentPos.y - tileSize.y/2,0);	 
			}
 		} 
	}

	public Vector3 GetMatrixTilePosition(Vector2 matrixPos)//получить матричные координаты тайла
	{
		 foreach(Tile _tile in _tiles) 
		{	
 			if(_tile._matrixPos.Equals(matrixPos))
			{		
				return new Vector3 (_tile._tilePos.x, _tile._tilePos.y, _tile._tilePos.z);
			}
		}
			return Vector3.one;
	} 
}
	
	 

 	
 