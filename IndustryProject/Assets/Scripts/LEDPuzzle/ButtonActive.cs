using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ButtonActive : MonoBehaviour
{
    public bool activated = false;
    public bool finished = false;
    public float timer = 50;
    public GameObject sphereColour;
    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = PhotonView.Get(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(finished)
        {
            pv.RPC("RPCUpdateVar", RpcTarget.All, activated, finished);

            sphereColour.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else if(activated)
        {
            timer -= Time.deltaTime;

            pv.RPC("RPCUpdateVar", RpcTarget.All, activated, finished);

            sphereColour.GetComponent<MeshRenderer>().material.color = Color.green;
            if (timer <= 0)
            {
                activated = false;

                pv.RPC("RPCUpdateVar", RpcTarget.All, activated, finished);

                sphereColour.GetComponent<MeshRenderer>().material.color = Color.red;
                timer = 10;
            }
        }
    }

    [PunRPC]
    void RPCUpdateVar(bool one, bool two)
    {
        activated = one;
        finished = two;
    }
}
