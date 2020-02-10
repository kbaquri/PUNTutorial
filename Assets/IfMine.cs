using Photon.Pun;
using UnityEngine;

public class IfMine : MonoBehaviourPun
{
    public GameObject myCamera;

    private float acceleration, direction;

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float steering = 5f;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            myCamera.SetActive(true);
        }
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            acceleration = Input.GetAxis("Vertical");
            direction = Input.GetAxis("Horizontal");
        }
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            float _velocity = acceleration * speed;
            gameObject.transform.position += gameObject.transform.forward * _velocity * Time.deltaTime;
            // gameObject.transform.localPosition += _velocity;

            Vector3 _rotation = new Vector3(0f, direction * steering * Time.deltaTime);
            gameObject.transform.Rotate(_rotation);
        }
    }
}
