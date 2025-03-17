using UnityEngine;

namespace GameContent.Scripts.Player
{
    public class GroundChecker : MonoBehaviour
    {
        [SerializeField] private Transform _checkSpot;
        [SerializeField] private float _checkRadius = 1f;
        [SerializeField] private LayerMask _checkMask;

        public bool Check()
        {
            return Physics.CheckSphere(_checkSpot.position, _checkRadius, _checkMask);
        }
    }
}