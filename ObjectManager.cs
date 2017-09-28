using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour
{

	void Update ()
	{
		if (Variables.playing) {
			for (int j = 0; j < Variables.objArray.Count; j++) {
				Variables.objArray [j].transform.position = new Vector3 (Variables.objArray [j].transform.position.x, Variables.objArray [j].transform.position.y, Variables.objArray [j].transform.position.z - Variables.speed);
			
				if (Variables.objArray [j].transform.position.z <= -13) {
					Destroy (Variables.objArray [j], 0);
					Variables.objArray.RemoveAt (j);
					Variables.objType.RemoveAt (j);
				
					if (Variables.objArray.Count > 0) {
						Variables.objArray [j].transform.position = new Vector3 (Variables.objArray [j].transform.position.x, Variables.objArray [j].transform.position.y, Variables.objArray [j].transform.position.z - Variables.speed);
					}
				}
			}
		}
	}
}
