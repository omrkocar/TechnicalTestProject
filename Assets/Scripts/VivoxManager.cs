using System;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine;

public class VivoxManager : MonoBehaviour
{
    private async void Start()
    {
        await UnityServices.Instance.InitializeAsync();
        await VivoxService.Instance.InitializeAsync();

        LoginOptions options = new();
        options.DisplayName = "Test Name";
        await VivoxService.Instance.LoginAsync(options);

        ChannelOptions channelOptions = new();
        channelOptions.MakeActiveChannelUponJoining = true;
        await VivoxService.Instance.JoinEchoChannelAsync("test", ChatCapability.AudioOnly, channelOptions);
    }
}
