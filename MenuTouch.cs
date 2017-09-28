using UnityEngine;
using System.Collections;

public class MenuTouch : MonoBehaviour {

	public GameObject playButton, Menu;

	void Update () {
		if (!Variables.playing && !Variables.playAgain && Reset.menuLoaded && Input.touchCount > 0) {
			/*RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay( Input.GetTouch(0).position );

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "default" && Input.touches[0].phase == TouchPhase.Began)
			{
				hit.transform.gameObject.transform.localScale = new Vector3(0.95f,0.95f,0.95f);
			}

			if ( Physics.Raycast(ray, out hit) && hit.transform.gameObject.name == "default" && Input.touches[0].phase == TouchPhase.Ended)
			{
				hit.transform.gameObject.transform.localScale = new Vector3(1f,1f,1f);
				Reset.tapped = true;
			}*/
			foreach (Touch touch in Input.touches) {
				if (touch.phase == TouchPhase.Ended) {
					Reset.tapped = true;
				}
			}
		}
	}
}
