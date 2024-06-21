using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] Button hostBtn;
    [SerializeField] Button serverBtn;
    [SerializeField] Button clientBtn;

    private void StartGame()
    {
        transform.Find("Debug").gameObject.SetActive(false);
    }

    private void Awake()
    {
        hostBtn.onClick.AddListener(() => {
            StartGame();
            NetworkManager.Singleton.StartHost();
        });

        serverBtn.onClick.AddListener(() => {
            StartGame();
            NetworkManager.Singleton.StartServer();
        });
        
        clientBtn.onClick.AddListener(() => {
            StartGame();
            NetworkManager.Singleton.StartClient();
        });




    }





}
