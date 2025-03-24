using System;
using GameContent.Scripts.Audio;
using GameContent.Scripts.Scene;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GameContent.Scripts.Menu
{
    public class MainMenuPanel : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _exitButton;

        [Header("Settings")]
        [SerializeField] private SettingsPanel _settings;
        
        [Inject] private SceneLoader _sceneLoader;
        [Inject] private AudioManager _audioManager;
        
        
        private void Awake()
        {
            Debug.Log(_audioManager);
            _settings.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartClickedHandle);
            _settingsButton.onClick.AddListener(OnSettingsClickedHandle);
            _exitButton.onClick.AddListener(OnExitClickedHandle);
        }
        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartClickedHandle);
            _settingsButton.onClick.RemoveListener(OnSettingsClickedHandle);
            _exitButton.onClick.RemoveListener(OnExitClickedHandle);
        }

        private void OnStartClickedHandle()
        {
            _sceneLoader.LoadSceneByIndex(2); //test Scene
        }
        private void OnSettingsClickedHandle()
        {
            _settings.gameObject.SetActive(true);
        }
        private void OnExitClickedHandle()
        {
            _audioManager.PlayTest();
            //_sceneLoader.ExitGame();
        }
    }
}