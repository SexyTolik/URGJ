using UnityEngine;

public class MonoComponent : MonoBehaviour
{
    public MonoRoot Root
    {
        get
        {
            if (_root == null)
            {
                _root = GetComponentInParent<MonoRoot>();

                if (_root == null)
                {
                    Debug.LogError($"Root for {GetType()} not found");
                    return default;
                }
            }

            return _root;
        }
    }

    private MonoRoot _root;
}