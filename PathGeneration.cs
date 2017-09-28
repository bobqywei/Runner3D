using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathGeneration : MonoBehaviour
{
	public GameObject Path, Path2, Path3, Coin, jetPack;
	int pathchoice;
	int objOnPath;
	int objGenerated;
	//int timesSplit;
	int consecutive;
	int pathlength;
	//int timerGenerated;

	void Start ()
	{
		Variables.pathArray.Add (Instantiate (Path) as GameObject);
		Variables.boolArray.Add (true);
		Variables.lengthArray.Add (4);
		Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, -3);
		
		Variables.pathArray.Add (Instantiate (Path) as GameObject);
		Variables.boolArray.Add (true);
		Variables.lengthArray.Add (4);
		Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 2);
		
		Variables.pathArray.Add (Instantiate (Path) as GameObject);
		Variables.boolArray.Add (true);
		Variables.lengthArray.Add (4);
		Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 7);
		
		Variables.pathArray.Add (Instantiate (Path) as GameObject);
		Variables.boolArray.Add (true);
		Variables.lengthArray.Add (4);
		Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 12);
		
		Variables.pathArray.Add (Instantiate (Path) as GameObject);
		Variables.boolArray.Add (false);
		Variables.lengthArray.Add (4);
		Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (0, 0.5F, 17);
	}

	void Update ()
	{

		if (Variables.playing) {

			for (int i = 0; i < Variables.pathArray.Count; i++) {
				Variables.pathArray [i].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z - Variables.speed);

				if (!GameMode.modeTransition && Variables.gameMode == 1) {
					if (!Variables.boolArray [i] && Variables.pathArray [i].transform.position.z < 15.5 + (Variables.speed) / 2) {
						Variables.boolArray [i] = true;

						objOnPath = Random.Range (1, 5);
						pathlength = Random.Range (1, 6);

						if (consecutive > 2) {
							pathchoice = 1;
						} else if (pathlength >= 5) {
							pathchoice = 1;
						} else {
							pathchoice = Random.Range (1, 4);
						}

						if (pathchoice == 1) {

							consecutive = 0;

							if (pathlength == 1 || pathlength == 2 || pathlength == 3) {
								Variables.pathArray.Add (Instantiate (Path) as GameObject);
								Variables.lengthArray.Add (4);
							} else if (pathlength == 4) {
								Variables.pathArray.Add (Instantiate (Path2) as GameObject);
								Variables.lengthArray.Add (6);
							} else if (pathlength >= 5) {
								Variables.pathArray.Add (Instantiate (Path3) as GameObject);
								Variables.lengthArray.Add (2);
							}

							Variables.boolArray.Add (false);
							Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + Variables.lengthArray [i] / 2 + Variables.lengthArray [Variables.lengthArray.Count - 1] / 2 + 1);

						} else if (pathchoice == 2) {

							if (pathlength == 1 || pathlength == 2 || pathlength == 3) {
								Variables.pathArray.Add (Instantiate (Path) as GameObject);
								Variables.lengthArray.Add (4);
							} else if (pathlength == 4) {
								Variables.pathArray.Add (Instantiate (Path2) as GameObject);
								Variables.lengthArray.Add (6);
							} else if (pathlength >= 5) {
								Variables.pathArray.Add (Instantiate (Path3) as GameObject);
								Variables.lengthArray.Add (2);
							}

							Variables.boolArray.Add (false);
							consecutive += 1;
							Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x - 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray [i] * 5, Variables.lengthArray [i] * 8F) / 10F));

							if (check ()) {
								Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x + 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray [i] * 5, Variables.lengthArray [i] * 8F) / 10F));
								if (check ()) {
									Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + Variables.lengthArray [i] / 2 + Variables.lengthArray [Variables.lengthArray.Count - 1] / 2 + 1);
									consecutive = 0;
								}
							}

						} else if (pathchoice == 3) {

							if (pathlength == 1 || pathlength == 2 || pathlength == 3) {
								Variables.pathArray.Add (Instantiate (Path) as GameObject);
								Variables.lengthArray.Add (4);
							} else if (pathlength == 4) {
								Variables.pathArray.Add (Instantiate (Path2) as GameObject);
								Variables.lengthArray.Add (6);
							} else if (pathlength >= 5) {
								Variables.pathArray.Add (Instantiate (Path3) as GameObject);
								Variables.lengthArray.Add (2);
							}

							Variables.boolArray.Add (false);
							consecutive += 1;
							Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x + 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray [i] * 5, Variables.lengthArray [i] * 8F) / 10F));

							if (check ()) {
								Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x - 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray [i] * 5, Variables.lengthArray [i] * 8F) / 10F));
								if (check ()) {
									Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + Variables.lengthArray [i] / 2 + Variables.lengthArray [Variables.lengthArray.Count - 1] / 2 + 1);
									consecutive = 0;
								}
							}
						}


						/*else if (pathchoice == 4) {

						if (pathlength == 1 || pathlength == 2 || pathlength == 3) {
							Variables.pathArray.Add (Instantiate (Path) as GameObject);
							Variables.lengthArray.Add (4);
						}
						else if (pathlength == 4) {
							Variables.pathArray.Add (Instantiate (Path2) as GameObject);
							Variables.lengthArray.Add (6);
						}
						else if (pathlength >= 5) {
							Variables.pathArray.Add (Instantiate (Path3) as GameObject);
							Variables.lengthArray.Add (2);
						}

						Variables.boolArray.Add (false);
						consecutive += 1;
						Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x + 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray[i]*5, Variables.lengthArray[i]*8F) / 10F));

						if (check ()) {

							Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x - 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray[i]*5, Variables.lengthArray[i]*8F) / 10F));

							if (check ()) {
								Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + Variables.lengthArray[i]/2 + Variables.lengthArray[Variables.lengthArray.Count - 1]/2 + 1);
							}
						}
						else {

							if (timesSplit < 1) {

								if (pathlength == 1 || pathlength == 2 || pathlength == 3) {
									Variables.pathArray.Add (Instantiate (Path) as GameObject);
									Variables.lengthArray.Add (4);
								}
								else if (pathlength == 4) {
									Variables.pathArray.Add (Instantiate (Path2) as GameObject);
									Variables.lengthArray.Add (6);
								}
								else if (pathlength >= 5) {
									Variables.pathArray.Add (Instantiate (Path3) as GameObject);
									Variables.lengthArray.Add (2);
								}

								Variables.boolArray.Add (false);
								consecutive += 1;
								Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x - 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray[i]*5, Variables.lengthArray[i]*8F) / 10F));
						
								if (check ()) {

									Variables.pathArray [Variables.pathArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x + 1.25F, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z + (Random.Range (Variables.lengthArray[i]*5, Variables.lengthArray[i]*8F) / 10F));

									if (check ()) {
										Destroy (Variables.pathArray [Variables.pathArray.Count - 1], 0);
										Variables.pathArray.RemoveAt (Variables.pathArray.Count - 1);
										Variables.boolArray.RemoveAt (Variables.boolArray.Count - 1);
										Variables.lengthArray.RemoveAt (Variables.lengthArray.Count - 1);
									}
								}

								else {
									timesSplit += 1;
								}
							}
						}
					}*/

						if (objOnPath == 1 && !Variables.jetPack && !PowerUp.safe) {
							objGenerated = Random.Range (1, 6);

							if (objGenerated == 1) {
								Variables.objArray.Add (Instantiate (jetPack) as GameObject);
								Variables.objType.Add (1);

								Variables.objArray [Variables.objArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x, 1.2F, Random.Range (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z - Variables.lengthArray [Variables.lengthArray.Count - 1] / 3, Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + Variables.lengthArray [Variables.lengthArray.Count - 1] / 3));
							} else {
								Variables.objArray.Add (Instantiate (Coin) as GameObject);
								Variables.objType.Add (0);

								Variables.objArray [Variables.objArray.Count - 1].transform.position = new Vector3 (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x, 1.05F, Random.Range (Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z - Variables.lengthArray [Variables.lengthArray.Count - 1] / 3, Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z + Variables.lengthArray [Variables.lengthArray.Count - 1] / 3));
							}
						}
					}
				}

				if (Variables.pathArray [i].transform.position.z <= -13) {
					Destroy (Variables.pathArray [i], 0);
					Variables.pathArray.RemoveAt (i);
					Variables.boolArray.RemoveAt (i);
					Variables.lengthArray.RemoveAt (i);
					if (Variables.pathArray.Count > 0) {
						Variables.pathArray [i].transform.position = new Vector3 (Variables.pathArray [i].transform.position.x, Variables.pathArray [i].transform.position.y, Variables.pathArray [i].transform.position.z - Variables.speed);
					}
				}
			}
		} else {
			consecutive = 0;
			//timesSplit = 0;
		}
	}

	bool check ()
	{
		for (int i = 0; i < Variables.pathArray.Count - 1; i++) {
			if (Variables.pathArray [i].transform.position.x == Variables.pathArray [Variables.pathArray.Count - 1].transform.position.x && Variables.pathArray [i].transform.position.z + Variables.lengthArray [i] / 2 >= Variables.pathArray [Variables.pathArray.Count - 1].transform.position.z - (Variables.lengthArray [Variables.lengthArray.Count - 1] / 2 + 1)) {
				return true;
			}
		}
		return false;
	}
}
