using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tile
{
		public Vector3 _tilePos;

		public Vector2 _matrixPos;

		public Vector2 _size;

		public List<Vector2> _points;

		public Bounds bounds;

		public Tile (Vector2 matrixPos,Vector3 tilePos,Vector2 size)
		{
			_points = new List<Vector2>();

			_matrixPos = matrixPos;

			_tilePos = tilePos;
			
			//записываем все 4 точки тайла
			_points.Add(new Vector3(tilePos.x - size.x/2f,tilePos.y));

			_points.Add(new Vector3(tilePos.x,tilePos.y + size.y/2f ));
			
			_points.Add(new Vector3(tilePos.x + size.x/2f,tilePos.y));

			_points.Add(new Vector3(tilePos.x,tilePos.y - size.y/2f));

			bounds = new Bounds(tilePos,new Vector3(size.x,size.y));
		}
		
	public bool CheckTitle(Vector2 inPoint)
	{
		bool result = false;

		if (bounds.Contains (inPoint)) 
		{
			result = true;
		}
		return result;
	}

 
} 
