using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour
{
	private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
	private static Tile previousSelected = null;
	private static Tile currentSelected = null;

	private SpriteRenderer render;
	private bool isSelected = false;

	private GameObject[] adjacentDirections = new GameObject[] { };

	public static bool easyMode = false;
	public static bool MediumMode = false;
	public static bool HardMode = false;

	void Awake()
	{
		render = GetComponent<SpriteRenderer>();
	}

	private void Select()
	{
		isSelected = true;
		render.color = selectedColor;
		previousSelected = gameObject.GetComponent<Tile>();
	}

	private void Deselect()
	{
		isSelected = false;
		render.color = Color.white;
		previousSelected = null;
	}

	void OnMouseDown()
	{
		if (render.sprite == null)
		{
			return;
		}

		if (isSelected)
		{
			Deselect();
		}
		else
		{
			if (previousSelected == null)
			{
				Select();
				CheckDigit(previousSelected);
			}
			else
			{
				currentSelected = gameObject.GetComponent<Tile>();
				if (currentSelected.transform.position.x == previousSelected.transform.position.x || currentSelected.transform.position.y == previousSelected.transform.position.y)
				{
					Debug.Log("Next Chosen");
					previousSelected.Deselect();
					currentSelected.Select();
					CheckDigit(currentSelected);
				}
				else
				{
					previousSelected.GetComponent<Tile>().Deselect();
					GridManager.ClearPass();
					Select();
					CheckDigit(previousSelected);
				}
			}
		}
	}

	public void CheckDigit(Tile digit)
    {

		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-1")
		{
			GridManager.CheckPass(1);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-2")
		{
			GridManager.CheckPass(2);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-3")
		{
			GridManager.CheckPass(3);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-4")
		{
			GridManager.CheckPass(4);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-5")
		{
			GridManager.CheckPass(5);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-6")
		{
			GridManager.CheckPass(6);
		}
		if (digit.GetComponent<SpriteRenderer>().sprite.name == "Level-7")
		{
			GridManager.CheckPass(7);
		}

	}


	public void SetModeEasy()
	{
		easyMode = true;
		MediumMode = false;
		HardMode = false;
	}

	public void SetModeMedium()
	{
		easyMode = false;
		MediumMode = true;
		HardMode = false;
	}

	public void SetModeHard()
	{
		easyMode = false;
		MediumMode = false;
		HardMode = true;
	}


}