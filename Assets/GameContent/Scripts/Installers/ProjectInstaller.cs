using GameContent.Scripts.Audio;
using GameContent.Scripts.Scene;
using UnityEngine;
using Zenject;

namespace GameContent.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private SceneLoader _sceneLoader;
    
        public override void InstallBindings()
        {
            Container.BindInstance<AudioManager>(_audioManager).AsSingle();
            Container.BindInstance<SceneLoader>(_sceneLoader).AsSingle();
        }
    }
}