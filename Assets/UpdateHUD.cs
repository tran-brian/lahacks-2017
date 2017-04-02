//using SocketIO;
#if WINDOWS_UWP
//using Quobject.SocketIoClientDotNet.Client;
using Windows.Networking.Sockets;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UpdateHUD : MonoBehaviour {
    //public SocketIOComponent socket;
#if WINDOWS_UWP
//    private Socket socket;
    MessageWebSocket webSock = new MessageWebSocket();
#endif
    public Transform bikeTrans;
    float bikeLeanX = 0;
    float bikeLeanY = 0;
    float bikeLeanZ = 0;

    public void Awake()
    {
        //GameObject go = GameObject.Find("SocketIO");
        //socket = go.GetComponent<SocketIOComponent>();
//#if WINDOWS_UWP
//        socket = IO.Socket("http://localhost");
//#endif
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
        //#if WINDOWS_UWP

        //        socket.On("data", (data) => {
        //            OnDataReceived();
        //        });
        //        socket.Emit("data");
        //#endif

#if WINDOWS_UWP
        Debug.Log("Your face");
#elif UNITY_EDITOR
        Debug.Log("Editor");
#else
        Debug.Log("Haha");
#endif
        Debug.Log(initSocket());
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

    void OnDataReceived(object e)
    {
        Debug.Log("[Socket IO] Data received: " + e); //.name + " " + e.data);
    }

    void FakeUpdate(object e)
    {
        Debug.Log("Fake update");
        
    }



    string initSocket()
    {
        string s = "";
        Debug.Log("initsocket");
#if WINDOWS_UWP
        Debug.Log("initsocket");
        //In this case we will be sending/receiving a string so we need to set the MessageType to Utf8.
        webSock.Control.MessageType = SocketMessageType.Utf8;

        //Add the MessageReceived event handler.
        webSock.MessageReceived += WebSock_MessageReceived;

        //Add the Closed event handler.
        //webSock.Closed += WebSock_Closed;

        System.Uri serverUri = new System.Uri("wss://127.0.0:4444");

        try
        {
            //Connect to the server.
            webSock.ConnectAsync(serverUri);

            //Send a message to the server.
            WebSock_SendMessage(webSock, "Hello, world!");
            Console.WriteLine("Message sent!");
        s = "sock";
        }
        catch (Exception ex)
        {
            //Add code here to handle any exceptions
            Console.WriteLine("Exception: " + ex.Message");
        s = "Exception";
        }
else
Console.WriteLine("Boop");
        s = "Boop";
#endif

        return s;
    }

#if WINDOWS_UWP
    //The MessageReceived event handler.
    private void WebSock_MessageReceived(MessageWebSocket sender, MessageWebSocketMessageReceivedEventArgs args)
    {
        System.Data.DataReader messageReader = args.GetDataReader();
        messageReader.UnicodeEncoding = UnicodeEncoding.Utf8;
        string messageString = messageReader.ReadString(messageReader.UnconsumedBufferLength);

        //Add code here to do something with the string that is received.
        Text textObj = GameObject.FindObjectOfType<Text>();
        textObj.text = messageString;

        Debug.Log("msg rcvd");
    }
#endif

}
