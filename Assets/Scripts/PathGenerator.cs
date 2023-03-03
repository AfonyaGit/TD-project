using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator
{
	private int width, height;
	private List<Vector2Int> pathCells;
	public PathGenerator(int width, int height)
	{
		this.width = width;
		this.height = height;
	}

	public List<Vector2Int> GeneratePath()
	{
		pathCells = new List<Vector2Int>();
		int y = (int)(height / 2);
		int x = 0;
		/*
		for (int x = 0; x < width; x++)
		{
			pathCells.Add(new Vector2Int(x, y));
		}
		*/
		while (x < width)
		{
			pathCells.Add(new Vector2Int(x, y));

			bool validMove = false;
			while (!validMove)
			{
				int move = Random.Range(0, 3);

				if (move == 0 || x % 2 == 0 || x > (width - 2))
				{
					x++;
					validMove = true;
				}
				else if (move == 1 && CellIsFree(x, y + 1) && y < (height - 3))
				{
					y++;
					validMove = true;
				}
				else if (move == 2 && CellIsFree(x, y - 1) && y > 2)
				{
					y--;
					validMove = true;
				}
			}
		}
		return pathCells;
	}
	private bool CellIsFree(int x, int y)
	{
		return !pathCells.Contains(new Vector2Int(x, y));
	}
}
