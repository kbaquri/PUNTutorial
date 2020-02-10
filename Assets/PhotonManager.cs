using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    RoomOptions roomOptions = new RoomOptions();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to server.");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause)
    {
        print("Disconnected from master server for reason " + cause.ToString());
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("We have now joined the lobby");

        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = 4;

        //Join a room if it exist or create one 
        PhotonNetwork.JoinOrCreateRoom("PUNTutorial", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //Callback function for if we fail to join a rooom
    {
        Debug.Log("Failed to join a room");
        PhotonNetwork.JoinOrCreateRoom("PUNTutorial", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom Called");
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("SlotCar_B", new Vector3(2, 0, 0), Quaternion.identity, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("SlotCar_C", new Vector3(-2, 0, 0), Quaternion.identity, 0);

        }
    }
}
