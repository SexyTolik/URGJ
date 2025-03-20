using System;
using Unity.VisualScripting;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float _timeMultiplier = 1f;
    
    private float _timer = 0f;
    private float _timeMult = 1f;
    
    private void Awake()
    {
        Physics.simulationMode = SimulationMode.Script;
    }

    private void Update()
    {
        if (Physics.simulationMode != SimulationMode.Script)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _timeMult = _timeMultiplier;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _timeMult = 1f;
        }
        
        _timer += Time.deltaTime;

        while (_timer >= Time.fixedDeltaTime)
        {
            _timer -= Time.fixedDeltaTime;
            Physics.Simulate(Time.fixedDeltaTime * _timeMult);
        }
    }

    public void SetTimeMultiplier(float timeMultiplier)
    {
        if (timeMultiplier < 0) return;

        _timeMultiplier = timeMultiplier;
    }
}