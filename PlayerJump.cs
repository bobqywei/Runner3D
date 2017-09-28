using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
		
	float currentTime;
	float jumpPercent = 1;
	int frameCount;
	public static Vector3 endpos;
	Vector2 startTap;
	bool ground = true;
	bool left, right;
	bool apex = false;
	bool firstInput = false;

	void Update ()
	{

		if (Variables.playing) {
			int fingerCount = 0;

			if (Variables.gameMode == 1 && !CameraFollow.transition) {
				if (Input.touchCount > 0) {
					foreach (Touch touch in Input.touches) {

						if (touch.phase == TouchPhase.Began) {
							startTap = touch.position;
						}

						if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {

							fingerCount ++;

							if (fingerCount == 1 && touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Moved) {
								if (touch.position.y - startTap.y > 100 && !Variables.jumped && ground && !Variables.jetPack) {
									gameObject.GetComponent<AudioSource> ().Play ();
									endpos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1F, gameObject.transform.position.z);
									Variables.startpos = gameObject.transform.position;
									Variables.straightJump = true;
									ground = false;
									firstInput = true;
								} else if (Mathf.Abs (touch.position.x - startTap.x) > 100) {
									firstInput = true;

									if (!Variables.straightJump && !PowerUp.transition && !PowerUp.up) {
										Variables.startpos = gameObject.transform.position;
										Variables.jumped = true;
							
										if (touch.position.x - startTap.x < 0 && gameObject.transform.position.x == endpos.x) {
											if (!Variables.jetPack) {
												gameObject.GetComponent<AudioSource> ().Play ();
												endpos = new Vector3 (transform.position.x - 0.625F, transform.position.y + 1, transform.position.z);
											} else {
												endpos = new Vector3 (transform.position.x - 1.25F, 2, transform.position.z);
											}

											left = true;
										}
										if (touch.position.x - startTap.x > 0 && gameObject.transform.position.x == endpos.x) {
											if (!Variables.jetPack) {
												gameObject.GetComponent<AudioSource> ().Play ();
												endpos = new Vector3 (transform.position.x + 0.625F, transform.position.y + 1, transform.position.z);
											} else {
												endpos = new Vector3 (transform.position.x + 1.25F, 2, transform.position.z);
											}

											right = true;
										}
									}
								}
							}
						}
					}
				} else {
					if (!firstInput) {
						if (Input.GetButtonDown ("left") || Input.GetButtonDown ("right") || Input.GetButtonDown ("up")) {
							firstInput = true;
						}
					}

					if (Input.GetButtonUp ("left") || Input.GetButtonUp ("right")) {

						if (!Variables.straightJump && !PowerUp.transition && !PowerUp.up) {
							Variables.startpos = gameObject.transform.position;
							Variables.jumped = true;
					
							if (Input.GetButtonUp ("left") && gameObject.transform.position.x == endpos.x) {
								if (!Variables.jetPack) {
									gameObject.GetComponent<AudioSource> ().Play ();
									endpos = new Vector3 (transform.position.x - 0.625F, transform.position.y + 1, transform.position.z);
								} else {
									endpos = new Vector3 (transform.position.x - 1.25F, 2, transform.position.z);
								}

								left = true;
							}
							if (Input.GetButtonUp ("right") && gameObject.transform.position.x == endpos.x) {
								if (!Variables.jetPack) {
									gameObject.GetComponent<AudioSource> ().Play ();
									endpos = new Vector3 (transform.position.x + 0.625F, transform.position.y + 1, transform.position.z);
								} else {
									endpos = new Vector3 (transform.position.x + 1.25F, 2, transform.position.z);
								}

								right = true;
							}
						}
					} else if (Input.GetButtonUp ("up") && !Variables.jumped && ground && !Variables.jetPack) {
						gameObject.GetComponent<AudioSource> ().Play ();
						endpos = new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + 1F, gameObject.transform.position.z);
						Variables.startpos = gameObject.transform.position;
						Variables.straightJump = true;
						ground = false;
					}
				}
			}
	
			if (Variables.jumped) {

				if (firstInput) {

					if (!Variables.jetPack) {
						currentTime += Variables.speed;
						jumpPercent = currentTime;
						gameObject.transform.position = Vector3.Lerp (Variables.startpos, endpos, jumpPercent);

						if (jumpPercent > 0.9 && !apex) {
							apex = true;
							gameObject.transform.position = endpos;
							Variables.startpos = endpos;

							if (right) {
								endpos = new Vector3 (transform.position.x + 0.625F, transform.position.y - 1, transform.position.z);
							} else if (left) {
								endpos = new Vector3 (transform.position.x - 0.625F, transform.position.y - 1, transform.position.z);
							}

							jumpPercent = 0;
							currentTime = 0;

						} else if (jumpPercent > 0.9 && apex) {
							gameObject.transform.Find ("PlayerObject").GetComponent<AudioSource> ().Play ();
							Variables.jumped = false;
							apex = false;
							gameObject.transform.position = endpos;
							jumpPercent = 0;
							currentTime = 0;
							right = false;
							left = false;
						
						}
					} else {
						if (!PowerUp.end) {
							currentTime += Variables.speed / 2;
						} else {
							currentTime += Variables.speed * 5 / 2;
						}

						jumpPercent = currentTime;
						gameObject.transform.position = Vector3.Lerp (Variables.startpos, endpos, jumpPercent);
						
						if (jumpPercent > 0.9) {
							gameObject.transform.position = endpos;
							Variables.jumped = false;
							
							jumpPercent = 0;
							currentTime = 0;

							right = false;
							left = false;
							
						}
					}
				}
			}
			if (Variables.straightJump && !ground) {
				frameCount += 1;

				jumpPercent = frameCount * Variables.speed;
				gameObject.transform.position = Vector3.Lerp (Variables.startpos, endpos, jumpPercent);

				if (jumpPercent > 1 && !apex) {
					frameCount = 0;
					gameObject.transform.position = endpos;
					endpos = Variables.startpos;
					Variables.startpos = gameObject.transform.position;
					apex = true;

				} else if (jumpPercent > 1 && apex) {
					gameObject.transform.Find ("PlayerObject").GetComponent<AudioSource> ().Play ();
					ground = true;
					apex = false;
					jumpPercent = 0;
					frameCount = 0;
					gameObject.transform.position = endpos;
					Variables.straightJump = false;
				}
			}
		} else {
			Variables.startpos = new Vector3 (0, 0, 0);
			endpos = new Vector3 (0, 0, 0);
		}
	}
}

