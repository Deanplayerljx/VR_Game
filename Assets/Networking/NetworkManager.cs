using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	const string VERSION = "V0.0.1";
	public string room_name = "VR_MARKET";
	public string player_prefab_name = "Player";
	public Transform spawnPoint;
	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings (VERSION);
	}
	void OnJoinedLobby(){
		RoomOptions roomOptions = new RoomOptions () { IsVisible = false, MaxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom (room_name, roomOptions, TypedLobby.Default);
	}
	void OnJoinedRoom() {
		GameObject player = PhotonNetwork.Instantiate (player_prefab_name, spawnPoint.position, spawnPoint.rotation, 0);
		player.GetComponentInChildren<Camera> ().enabled = true;
		player.GetComponentInChildren<GvrViewer> ().enabled = true;

	}
}