using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class NetworkRunner : MonoBehaviour {

	[SerializeField]
	public bool isenabled = false;

	[SerializeField]
	public bool isServer = false;
	public NetworkManager manager;
	void Awake()
	{
		manager = GetComponent<NetworkManager>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isenabled) {
			return;
		}
		if (!manager.IsClientConnected () && !NetworkServer.active && manager.matchMaker == null) {
			Debug.Log ("Attemting to start network manager");
			isenabled = true;
			if (isServer) {
				Debug.Log ("Running as host");
				manager.StartHost();
			}
			if (!isServer) {
				Debug.Log ("Running as client");
				manager.StartClient();
			}
		}
		if (NetworkServer.active && manager.IsClientConnected ()) {
			if (!isenabled) {
				manager.StopHost();
			}
		}
	}
}
