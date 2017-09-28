using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {
	public GameObject collectEffect, jetpack, jeteffect, timeeffect;
	public static GameObject jetPack, jetEffect1, jetEffect2;

	void Update () {
		if (Variables.playing && !Variables.jumped && !Variables.straightJump && !Variables.jetPack) {
			for (int i = 0; i < Variables.objArray.Count; i++) {
				if (Variables.objArray [i].transform.position.x == gameObject.transform.position.x) {
					if (Variables.objArray [i].transform.position.z - 0.5 < -3 && Variables.objArray [i].transform.position.z + 0.5 > -3) {

						if (Variables.objType [i] == 0) {
							GameObject effect = Instantiate(collectEffect) as GameObject;
							effect.transform.position = new Vector3(gameObject.transform.position.x, 1.25F, -3);
							Destroy (effect, 3);

							Variables.coins += 1;

							Destroy (Variables.objArray [i], 0);
							Variables.objType.RemoveAt (i);
							Variables.objArray.RemoveAt (i);

						}
						else if (Variables.objType [i] == 1) {
							Variables.jetPack = true;
							SpeedController.currentSpeed = Variables.rawSpeed;
							PowerUp.up = true;

							Destroy (Variables.objArray [i], 0);
							Variables.objType.RemoveAt (i);
							Variables.objArray.RemoveAt (i);

							jetPack = Instantiate(jetpack) as GameObject;
							jetPack.transform.position = new Vector3(gameObject.transform.position.x, 1, -3.35F);
							jetPack.transform.parent = gameObject.transform;

							jetEffect1 = Instantiate(jeteffect) as GameObject;
							jetEffect1.transform.position = new Vector3(gameObject.transform.position.x-0.1F, 0.7F, -3.35F);
							jetEffect1.transform.parent = gameObject.transform;

							jetEffect2 = Instantiate(jeteffect) as GameObject;
							jetEffect2.transform.position = new Vector3(gameObject.transform.position.x+0.1F, 0.7F, -3.35F);
							jetEffect2.transform.parent = gameObject.transform;

						}
					}
				}
			}
		}
	}
}
