using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Variables {
	public static int gameMode = 1;

	public static int score, coins;
	//public static int timer = 30;

	public static bool playing = false;

	public static bool jumped = false;
	public static bool straightJump = false;

	public static float rawSpeed = 5F;
	public static float speed = 0.1F;

	public static List<GameObject> pathArray = new List<GameObject>();
	public static List<bool> boolArray = new List<bool>();
	public static List<int> lengthArray = new List<int>();

	public static List<List <GameObject>> tileArray = new List<List<GameObject>>();
	public static List<bool> tileBool = new List<bool>();

	public static List<GameObject> waterblockArray = new List<GameObject>();
	public static List<bool> waterGeneration = new List<bool>();

	public static List<GameObject> objArray = new List<GameObject>();
	public static List<int> objType = new List<int>();

	public static bool jetPack;

	public static bool playAgain = true;
	public static Vector3 startpos = new Vector3(0,0.375F,-3);

}
