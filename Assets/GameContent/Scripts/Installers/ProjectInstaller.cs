using GameContent.Scripts.Audio;
using GameContent.Scripts.Scene;
using UnityEngine;
using Zenject;

namespace GameContent.Scripts.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private AudioManager _audioManager;
        
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
            
            AudioManager audioManager = Container.InstantiatePrefabForComponent<AudioManager>(_audioManager);
            Container.BindInstance(audioManager).AsSingle();
        }
    }
}