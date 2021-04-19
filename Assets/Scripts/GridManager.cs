using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
	public static GridManager instance;
	public List<Sprite> characters = new List<Sprite>();
	List<Sprite> characters2 = new List<Sprite>();
	public GameObject grid;
	public Canvas canvas;
	public GameObject tile;

	public int xSize, ySize;
	private float canvasCntr;

	private static bool clr1 = false;
	private static bool clr2 = false;
	private static bool clr3 = false;
	private static bool clr4 = false;
	public static bool cleared = false;

	private GameObject[,] tiles;

	void Start()
	{
		instance = GetComponent<GridManager>();

		Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
		CreateBoard(offset.x, offset.y);

		canvasCntr = canvas.GetComponent<RectTransform>().rect.width;
		grid.transform.position = new Vector3((canvasCntr * -0)-3, (0 - 2), 0);
	}

	private void CreateBoard(float xOffset, float yOffset)
	{
		CheckLvl();
		
		tiles = new GameObject[xSize, ySize];

		float startX = transform.position.x;
		float startY = transform.position.y;

		Sprite[] previousLeft = new Sprite[ySize];
		Sprite previousBelow = null;

		for (int x = 0; x < xSize; x++)
		{
			for (int y = 0; y < ySize; y++)
			{
				GameObject newTile = Instantiate(tile, new Vector3(startX + (xOffset * x), startY + (yOffset * y), 0), tile.transform.rotation);
				tiles[x, y] = newTile;
				newTile.transform.parent = transform;
				List<Sprite> possibleCharacters = new List<Sprite>();
				possibleCharacters.AddRange(characters);

				possibleCharacters.Remove(previousLeft[y]);
				possibleCharacters.Remove(previousBelow);
				Sprite newSprite = possibleCharacters[Random.Range(0, possibleCharacters.Count)];
				newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

				previousLeft[y] = newSprite;
				previousBelow = newSprite;
			}
		}
	}

	public void CheckLvl()
    {
		if (Tile.easyMode == true)
		{
			if (SkillLevel.skillLvl == 1)
			{
				xSize = 6;
				ySize = 6;
			}
			else if (SkillLevel.skillLvl == 2)
			{
				xSize = 6;
				ySize = 6;
			}
			else if (SkillLevel.skillLvl == 3)
			{
				xSize = 6;
				ySize = 6;
			}
			else
			{
				xSize = 5;
				ySize = 5;
			}

		}

		if (Tile.MediumMode == true)
		{
			if (SkillLevel.skillLvl == 1)
			{
				xSize = 5;
				ySize = 5;
			}
			else if (SkillLevel.skillLvl == 2)
			{
				xSize = 5;
				ySize = 5;
			}
			else if (SkillLevel.skillLvl == 3)
			{
				xSize = 6;
				ySize = 6;
			}
			else
			{
				xSize = 4;
				ySize = 4;
			}
		}

		if (Tile.HardMode == true)
		{
			if (SkillLevel.skillLvl == 1)
			{
				xSize = 5;
				ySize = 5;
			}
			else if (SkillLevel.skillLvl == 2)
			{
				xSize = 5;
				ySize = 5;
			}
			else if (SkillLevel.skillLvl == 3)
			{
				xSize = 6;
				ySize = 6;
			}
			else
			{
				xSize = 4;
				ySize = 4;
			}
		}
	}

	public static void CheckPass(int lvl)
    {
		int[] pass = new int [5];
		pass[0] = 4;
		pass[1] = 3;
		pass[2] = 2;
		pass[3] = 1;
		pass[4] = 5;

		if (Tile.easyMode == true)
		{
			if (pass[0] == lvl)
			{
				Debug.Log("passed one");
				clr1 = true;
			}
			if (clr1 == true && pass[1] == lvl)
			{
				Debug.Log("passed two");
				clr2 = true;
			}
			if (clr2 == true && pass[2] == lvl)
			{
				Debug.Log("passed clear");
				clr3 = true;
				cleared = true;
			}
		}

		if (Tile.MediumMode == true)
		{
			if (pass[0] == lvl)
			{
				Debug.Log("passed one");
				clr1 = true;
			}
			if (clr1 == true && pass[1] == lvl)
			{
				Debug.Log("passed two");
				clr2 = true;
			}
			if (clr2 == true && pass[2] == lvl)
			{
				Debug.Log("passed three");
				clr3 = true;
			}
			if (clr3 == true && pass[3] == lvl)
			{
				Debug.Log("passed clear");
				clr4 = true;
				cleared = true;
			}
		}

		if (Tile.HardMode == true)
        {
			if (pass[0] == lvl)
			{
				Debug.Log("passed one");
				clr1 = true;
			}
			if (clr1 == true && pass[1] == lvl)
			{
				Debug.Log("passed two");
				clr2 = true;
			}
			if (clr2 == true && pass[2] == lvl)
			{
				Debug.Log("passed three");
				clr3 = true;
			}
			if (clr3 == true && pass[3] == lvl)
			{
				Debug.Log("passed four");
				clr4 = true;
			}
			if (clr4 == true && pass[4] == lvl)
			{
				Debug.Log("passed five");
				cleared = true;
				Debug.Log("Cleared game");
			}
		}
    }

	public static void ClearPass()
    {
		clr1 = false;
		clr2 = false;
		clr3 = false;
		clr4 = false;
		cleared = false;
    }

}
