using System;
using Unity.Services.Core;
using Unity.Services.Vivox;
using UnityEngine;

[RequireComponent(typeof(VivoxManager)), RequireComponent(typeof(ConfigManager))]
public class GameInstance : MonoBehaviour
{
    public GameObject canvas;
    private async void Start()
    {
        canvas.SetActive(false);
        await UnityServices.Instance.InitializeAsync();
        
        await GetComponent<ConfigManager>().Initialize();
        await GetComponent<VivoxManager>().Initialize();

        canvas.SetActive(true);
    }
}
