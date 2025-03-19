using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeMultiplier = 1f;
    private float _timer = 0f;

    private void Awake()
    {
        Physics.simulationMode = SimulationMode.Script;
    }

    private void Update()
    {
        if (Physics.simulationMode != SimulationMode.Script)
            return;

        _timer += Time.deltaTime;

        while (_timer >= Time.fixedDeltaTime)
        {
            _timer -= Time.fixedDeltaTime;
            Physics.Simulate(Time.fixedDeltaTime * _timeMultiplier);
        }
    }
}
