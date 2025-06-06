using System;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine;
using Random = UnityEngine.Random;

public class VivoxManager : MonoBehaviour
{
    private async void Start()
    {
        await UnityServices.Instance.InitializeAsync();
        await VivoxService.Instance.InitializeAsync();

        LoginOptions options = new();
        options.DisplayName = $"Test Name {Random.Range(0, 100f)}{Random.Range(0,100f)}";
        await VivoxService.Instance.LoginAsync(options);

        ChannelOptions channelOptions = new();
        channelOptions.MakeActiveChannelUponJoining = true;
        await VivoxService.Instance.JoinGroupChannelAsync("test", ChatCapability.AudioOnly, channelOptions);
    }
}
