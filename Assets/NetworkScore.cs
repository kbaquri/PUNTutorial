using Photon.Pun;
using UnityEngine.UI;

public class NetworkScore : MonoBehaviourPun/*, IPunObservable*/
{
    private int score = 0;

    public Text scoreText;

    // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    // {
    //     if (stream.IsWriting)
    //     {
    //         stream.SendNext(score);
    //     }
    //     else
    //     {
    //         this.score = (int)stream.ReceiveNext();
    //     }
    // }

    public void ButtonClick()
    {
        photonView.RPC("OnAwakeRPC", RpcTarget.All, null);
    }

    [PunRPC]
    public void OnAwakeRPC()
    {
        scoreText.text = "Score: " + ++score;
    }
}
