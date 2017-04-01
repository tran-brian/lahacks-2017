using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class UpdateHUD : MonoBehaviour {
    public SocketIOComponent socket;
    public Transform bikeTrans;
    float bikeLeanX = 0;
    float bikeLeanY = 0;
    float bikeLeanZ = 0;

    public void Awake()
    {
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        //socket.url = "ws://localhost:3001/socket.io/?EIO=4&transport=websocket";
        //socket.autoConnect = true;

        //Assert.IsNotNull(socket, "You forgot something");

        //socket.url = "http://localhost:3001/socket.io/?EIO=4&transport=websocket";
        //socket.autoConnect = true;
    }


    // Use this for initialization
    void Start () {
        //GameObject go = GameObject.Find("SocketIO");
        //socket = go.GetComponent<SocketIOComponent>();
        //socket.url = "ws://localhost:3001/socket.io/?EIO=4&transport=websocket";
        //socket.autoConnect = true;
        Debug.Log("Blahd;jfad");
        
        socket.Emit("blah");
        socket.On("data", OnDataReceived);

        bikeLeanX = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if(bikeLeanX != 0 || bikeLeanY != 0 || bikeLeanZ != 0)
        {
            bikeTrans.Rotate(bikeLeanX, bikeLeanY, bikeLeanZ);
            bikeLeanX = 0;
            bikeLeanY = 0;
            bikeLeanZ = 0;
        }
	}

    void OnDataReceived(SocketIOEvent e)
    {
        Debug.Log("[Socket IO] Data received: " + e.name + " " + e.data);
    }

    void FakeUpdate(SocketIOEvent e)
    {
        Debug.Log("Fake update");
    }
}
