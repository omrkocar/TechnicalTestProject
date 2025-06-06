using System;
using System.Threading.Tasks;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine;
using Random = UnityEngine.Random;

public class VivoxManager : MonoBehaviour
{
    private ChannelOptions channelOptions;
    private Transform cam;

    private bool inPositionalChannel;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    public async Task Initialize()
    {
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
        inPositionalChannel = false;
        await VivoxService.Instance.LeaveAllChannelsAsync();
        await VivoxService.Instance.JoinEchoChannelAsync("echo", ChatCapability.AudioOnly, channelOptions);
    }
    
    public async void JoinGroupChannel()
    {
        inPositionalChannel = false;
        await VivoxService.Instance.LeaveAllChannelsAsync();
        await VivoxService.Instance.JoinGroupChannelAsync("group", ChatCapability.AudioOnly, channelOptions);
    }
    
    public async void JoinPositionalChannel()
    {
        inPositionalChannel = false;
        await VivoxService.Instance.LeaveAllChannelsAsync();

        var channel3dProperties = new Channel3DProperties()
        {

        };
        await VivoxService.Instance.JoinPositionalChannelAsync("positional", ChatCapability.AudioOnly, channel3dProperties, channelOptions);
        inPositionalChannel = true;
    }

    private void Update()
    {
        if (!inPositionalChannel)
            return;
        
        Vector3 pos = cam.position;
        VivoxService.Instance.Set3DPosition(pos, pos, cam.forward, cam.up, "positional");
    }
}
