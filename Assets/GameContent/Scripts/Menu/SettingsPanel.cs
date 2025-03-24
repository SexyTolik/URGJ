using UnityEngine;
using UnityEngine.UI;

namespace GameContent.Scripts.Menu
{
    public class SettingsPanel : MonoBehaviour
    {
        [SerializeField] private Slider _volumeSlider;
        [SerializeField] private Slider _testSlider;
        [SerializeField] private Slider _testSlider2;
    
        //[Inject] private "like settings changer or volume changer"

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }
    }
}