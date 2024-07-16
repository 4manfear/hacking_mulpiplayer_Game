using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.SceneManagement;
using Fusion.Sockets;
using System;
using JetBrains.Annotations;


public class BasicSpawner : MonoBehaviour, INetworkRunnerCallbacks
{
    [SerializeField] private NetworkPrefabRef _playerPrefab;

    // Dictionary to keep track of spawned player avatars
    private Dictionary<PlayerRef, NetworkObject> _spawnedCharacters = new Dictionary<PlayerRef, NetworkObject>();


    // this function is called when a new player joined the game
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        // Create a unique spawn position for the new player
        Vector3 spawnposition = new Vector3((player.RawEncoded % runner.Config.Simulation.PlayerCount) * 3, 1, 0);

        // Spawn the player avatar at the calculated position
        NetworkObject networkPlayerObject = runner.Spawn(_playerPrefab, spawnposition, Quaternion.identity, player);

        // Add the spawned avatar to the dictionary for tracking
        _spawnedCharacters.Add(player, networkPlayerObject);

    }
    // this function is called when a player left the game
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        // Check if the dictionary contains the leaving player's avatar
        if (_spawnedCharacters.TryGetValue(player, out NetworkObject networkObject))
        {
            // Despawn (remove) the player's avatar from the game
            runner.Despawn(networkObject);

            // Remove the player's avatar from the dictionary
            _spawnedCharacters.Remove(player);
        }
    }
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {

    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {

    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {

    }
    public void OnConnectedToServer(NetworkRunner runner)
    {

    }
    public void OnDisconnectedFromServer(NetworkRunner runner, NetDisconnectReason reason)
    {

    }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {

    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {

    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {

    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {

    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {

    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {

    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {

    }
    public void OnSceneLoadStart(NetworkRunner runner)
    {

    }
    public void OnObjectExitAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }
    public void OnObjectEnterAOI(NetworkRunner runner, NetworkObject obj, PlayerRef player)
    {

    }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ReliableKey key, ArraySegment<byte> data)
    {

    }
    public void OnReliableDataProgress(NetworkRunner runner, PlayerRef player, ReliableKey key, float progress)
    {

    }


    private NetworkRunner _runner;



    async void StartGame(GameMode mode)
    {
        // adding a "NetworkRunner" to the gameobject and storring it in "_runner" variable 
        _runner = gameObject.AddComponent<NetworkRunner>();
        //Enabling the "Networkrunner" to provide Input for the network simulation
        _runner.ProvideInput = true;

        // Get a SceneRef object for the currently active scene using its build index
        var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
        // Create a new NetworkSceneInfo object to manage network scene information
        var sceneInfo = new NetworkSceneInfo();
        // Check if the SceneRef is valid
        if (scene.IsValid)
        {
            // Add the scene reference to the NetworkSceneInfo object with additive load mode
            sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
        }
        // Asynchronously, starting a new game session with the specified parameters
        //   /\-> (waiting wait for the completion of the StartGame method. This allows the program to continue executing other tasks while waiting.)
        await _runner.StartGame(new StartGameArgs()
        {
            // Set the game mode for the session
            GameMode = mode,
            // Set the name of the game session
            SessionName = "TestRoom",
            // Set the scene to be loaded for the game session
            Scene = scene,
            // Add a NetworkSceneManagerDefault component to the GameObject and set it as the scene manager
            //NetworkSceneManagerDefault -> this method helps for the seen loading and unloading
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
        });
    }
    // this is a method called for rendering and handling GUI event
    private void OnGUI()
    {
        if (_runner == null)
        {
            // Create a "Host" button
            if (GUI.Button(new Rect(0, 0, 200, 40), "Host"))
            {
                StartGame(GameMode.Host);
            }
            // Create a "Join" button 
            if (GUI.Button(new Rect(0, 40, 200, 40), "Join"))
            {
                StartGame(GameMode.Client);
            }
        }
    }


    
    
}
