using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DynamicPixels.GameService;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Services.MultiPlayer.Room.Models;
using DynamicPixels.GameService.Services.Authentication.Models;
using Newtonsoft.Json;
using DynamicPixels.GameService.Services.MultiPlayer.Room;

public class TestScript : MonoBehaviour
{
    private static Room _room;

    // Start is called before the first frame update
    void Start()
    {
        //DynamicPixels.GameService.ServiceHub.A
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void LoginAsGuest()
    {
        try
        {
            var input = new LoginAsGuestParams()
            {
                deviceId = "12345754697",
                name = "Akram"
            };
            var result = await ServiceHub.Authentication.LoginAsGuest(input);
            Debug.Log(JsonConvert.SerializeObject(result.User));
        }
        catch (DynamicPixelsException e)
        {
            Debug.LogException(e);
        }
    }

    public async void CreateRoom()
    {
        try
        {
            var input = new CreateRoomParams
            {
                MinPlayer = 2,
                MaxPlayer = 2,
                IsPrivate = true,
                IsPermanent = true,
                Name = "RoomName",
                State = RoomState.Open
            };

            _room = await ServiceHub.Services.MultiPlayer.RoomService.CreateRoom(input);
            
            BindRoomEventHandlers();

            Debug.Log(JsonConvert.SerializeObject(_room));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    public async void BroadcastToRoom()
    {
        try
        {
            await _room.Broadcast("Hello");

            Debug.Log("Message has Sent");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

    private void BindRoomEventHandlers()
    {
        _room.OnMessageReceived += OnMessageReceive;
    }

    private void OnMessageReceive(object src, Request req)
    {
        Debug.Log($"Message Received: {req.Payload}");
    }
}
