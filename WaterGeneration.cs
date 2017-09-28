using UnityEngine;
using System.Collections;

public class WaterGeneration : MonoBehaviour {
	/*public GameObject water, player;
	GameObject block;
	float farleft, farright;

	void Start () {
		Variables.waterblockArray.Add (Instantiate (water) as GameObject);
		Variables.waterblockArray [Variables.waterblockArray.Count - 1].transform.position = new Vector3 (0, -0.25F, 2);
		Variables.waterGeneration.Add (false);
	}

	void Update () {

		if (Variables.playing) {

			for (int i = 0; i < Variables.waterblockArray.Count; i++) {
				Variables.waterblockArray [i].transform.position = new Vector3 (Variables.waterblockArray[i].transform.position.x, Variables.waterblockArray[i].transform.position.y, Variables.waterblockArray[i].transform.position.z - Variables.speed);
				if (Variables.waterblockArray [i].transform.position.z <= 2 && !Variables.waterGeneration[i]){
					Variables.waterGeneration [i] = true;
					Variables.waterblockArray.Add (Instantiate (water) as GameObject);
					Variables.waterblockArray [Variables.waterblockArray.Count - 1].transform.position = new Vector3(Variables.waterblockArray[i].transform.position.x, Variables.waterblockArray[i].transform.position.y, Variables.waterblockArray[i].transform.position.z + 25 + Variables.speed);
					Variables.waterGeneration.Add (false);
				}

				if (Variables.waterblockArray [i].transform.position.z < -21){
					Destroy(Variables.waterblockArray[i]);
					Variables.waterblockArray.RemoveAt(i);
					Variables.waterGeneration.RemoveAt(i);
					Variables.waterblockArray[i].transform.position = new Vector3 (Variables.waterblockArray[i].transform.position.x, Variables.waterblockArray[i].transform.position.y, Variables.waterblockArray[i].transform.position.z - Variables.speed);
				}
			}

			if (player.transform.position.x > farright && !Variables.jumped) {
				farright = player.transform.position.x + 18.75F;
				Variables.waterblockArray.Add (Instantiate (water) as GameObject);
				Variables.waterblockArray [Variables.waterblockArray.Count - 1].transform.position = new Vector3 (player.transform.position.x + 18.75F, -0.25F, Variables.waterblockArray [0].transform.position.z);
				Variables.waterGeneration.Add (false);
			}
			if (player.transform.position.x < farleft && !Variables.jumped) {
				farleft = player.transform.position.x - 18.75F;
				Variables.waterblockArray.Add (Instantiate (water) as GameObject);
				Variables.waterblockArray [Variables.waterblockArray.Count - 1].transform.position = new Vector3 (player.transform.position.x - 18.75F, -0.25F, Variables.waterblockArray [0].transform.position.z);
				Variables.waterGeneration.Add (false);
			}

		} else {
			farleft = 0;
			farright = 0;
		}
	}*/
}
