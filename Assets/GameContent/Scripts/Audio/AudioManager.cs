using UnityEngine;

namespace GameContent.Scripts.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSourceTest;

        public void PlayTest()
        {
            _audioSourceTest.Play();
        }
    }
}