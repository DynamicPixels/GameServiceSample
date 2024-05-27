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
    // Start is called before the first frame update
    void Start()
    {
        //var input = new LoginAsGuestParams();
        //ServiceHub.Authentication.LoginAsGuest(input);

        //var room = ServiceHub.Services.MultiPlayer.RoomService.CreateAndOpenRoom(new CreateRoomParams
        //{
        //    MinPlayer = 2,
        //    MaxPlayer = 2,
        //    IsPrivate = true,
        //    IsPermanent = true,
        //    Name = "123",
        //    Players = {}
        //}).GetAwaiter().GetResult();

        //room.Broadcast("sdfsdf");
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

            var currentRoom = await ServiceHub.Services.MultiPlayer.RoomService.CreateRoom(input);

            Debug.Log(JsonConvert.SerializeObject(currentRoom));
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}
