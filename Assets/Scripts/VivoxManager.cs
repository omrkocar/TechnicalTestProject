using System;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine;
using Random = UnityEngine.Random;

public class VivoxManager : MonoBehaviour
{
    private ChannelOptions channelOptions;
    private async void Start()
    {
        await UnityServices.Instance.InitializeAsync();
        await VivoxService.Instance.InitializeAsync();

        LoginOptions options = new()
        {
            DisplayName = $"Player {Guid.NewGuid()}"
        };
        await VivoxService.Instance.LoginAsync(options);
        
        channelOptions = new()
        {
            MakeActiveChannelUponJoining = true
        };
    }

    public async void JoinEchoChannel()
    {
        await VivoxService.Instance.LeaveAllChannelsAsync();
        await VivoxService.Instance.JoinEchoChannelAsync("test", ChatCapability.AudioOnly, channelOptions);
    }
    
    public async void JoinGroupChannel()
    {
        await VivoxService.Instance.LeaveAllChannelsAsync();
        await VivoxService.Instance.JoinGroupChannelAsync("test", ChatCapability.AudioOnly, channelOptions);
    }
    
    public async void JoinPositionalChannel()
    {
        await VivoxService.Instance.LeaveAllChannelsAsync();

        var channel3dProperties = new Channel3DProperties()
        {

        };
        await VivoxService.Instance.JoinPositionalChannelAsync("test", ChatCapability.AudioOnly, channel3dProperties, channelOptions);
    }
}
