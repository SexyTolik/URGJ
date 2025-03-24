using GameContent.Scripts.Scene;
using Zenject;

namespace GameContent.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [Inject] private SceneLoader _sceneLoader;
        
        public override void InstallBindings()
        {
            
            
            _sceneLoader.LoadSceneByIndex(1); //MainMenu
        }
    }
}