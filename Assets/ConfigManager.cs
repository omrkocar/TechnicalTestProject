using System;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.RemoteConfig;
using UnityEngine;

public class ConfigManager : MonoBehaviour
{
    public struct userAttributes
    {
        
    }

    public string channelname;
    
    public struct appAttributes {}
    
    public async Task Initialize()
    {
        RemoteConfigService.Instance.FetchCompleted += ApplyRemoteSettings;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
        await Task.CompletedTask;
    }

    void ApplyRemoteSettings(ConfigResponse configResponse)
    {
        channelname = RemoteConfigService.Instance.appConfig.GetString("Channel Name", "error channel");
    }
}
