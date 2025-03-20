using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeSlowMo : MonoBehaviour
{
    public float slowMotionSpeed = 0.2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = slowMotionSpeed; // Включить замедление
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f; // Вернуть нормальную скорость
        }
    }
}
