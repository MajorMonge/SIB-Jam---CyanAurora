using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class AliveTimer : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI timer;

    private static bool stopped = false;

    private void Awake()
    {
        PlayerFrigate.OnPlayerDied += (x) => { Stop(); };
    }

    private void Update()
    {
        if (!stopped)
        {
            float t = Time.timeSinceLevelLoad;
            int secs = Mathf.FloorToInt(t);

            int fraction = (int)((t - secs) * 100);
    
            int min = secs / 60;

            StringBuilder sb = new StringBuilder();

            if (min < 10) sb.Append(0);
            sb.Append(min).Append(':');
            if (secs < 10) sb.Append(0);
            sb.Append(secs).Append('.');
            if (fraction < 10) sb.Append(0);
            sb.Append(fraction);

            timer.text = sb.ToString();
        }
    }

    public static void Stop()
    {
        stopped = true;
    }
}
