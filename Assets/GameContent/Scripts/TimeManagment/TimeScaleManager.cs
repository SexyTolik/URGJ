using UnityEngine;

namespace GameContent.Scripts.TimeManagment
{
    public class TimeScaleManager : MonoBehaviour
    {
        [SerializeField] private float _timeMultiplier = 1f;
    
        private float _fixedDeltaTimeOrig;
    
        private void Awake()
        {
            _fixedDeltaTimeOrig = Time.fixedDeltaTime;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (Time.timeScale != 1f) return;
                Time.timeScale = _timeMultiplier;
                Time.fixedDeltaTime = this._fixedDeltaTimeOrig * Time.timeScale;
            }
        
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Time.timeScale = 1f;
                Time.fixedDeltaTime = _fixedDeltaTimeOrig;
            }
        }
    }
}