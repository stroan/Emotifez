using UnityEngine;
using System.Collections;

public class CameraFollowCharacterBehavior : MonoBehaviour {

	public GameObject _Player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (_Player.transform.position.x, _Player.transform.position.y, this.transform.position.z);
	}
}
