using UnityEngine;
using System.Collections;

public class TileDrop : MonoBehaviour {
	
	void Update () {
		if (Variables.gameMode == 2) {
			for (int i = 0; i < Variables.tileArray.Count; i++){
				for (int j = 0; j < Variables.tileArray[i].Count; j++) {
					if (Variables.tileArray[i][j].tag == "FallenTile") {
						Variables.tileArray[i][j].transform.position = new Vector3 (Variables.tileArray[i][j].transform.position.x, Variables.tileArray[i][j].transform.position.y - Variables.speed/2, Variables.tileArray[i][j].transform.position.z);
					}
				}
			}
		}
	}
}
