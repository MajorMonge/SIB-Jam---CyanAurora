using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class AliveTimer : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI timer;
    [SerializeField]
    private TextMeshProUGUI bestTimeText;

    private bool stopped = false;

    private int tmin = 0;
    private int tsecs = 0;
    private int tfrac = 0;

    private int bmin = 0;
    private int bsecs = 0;
    private int bfrac = 0;

    private void Awake()
    {
        PlayerFrigate.OnPlayerDied += (x) => { Stop(); };

        StringBuilder sb = new StringBuilder();

        bmin = PlayerPrefs.GetInt("BestTimeMin", 0);
        bsecs = PlayerPrefs.GetInt("BestTimeSecs", 0);
        bfrac = PlayerPrefs.GetInt("BestTimeFraction", 0);

        if (bmin < 10) sb.Append(0);
        sb.Append(bmin).Append(':');
        if (bsecs < 10) sb.Append(0);
        sb.Append(bsecs).Append('.');
        if (bfrac < 10) sb.Append(0);
        sb.Append(bfrac);

        bestTimeText.text = sb.ToString();
    }

    private void Update()
    {
        if (!stopped)
        {
            float t = Time.timeSinceLevelLoad;
            tsecs = Mathf.FloorToInt(t);

            tfrac = (int)((t - tsecs) * 100);
    
            tmin = tsecs / 60;
            tsecs = tsecs % 60;

            StringBuilder sb = new StringBuilder();

            if (tmin < 10) sb.Append(0);
            sb.Append(tmin).Append(':');
            if (tsecs < 10) sb.Append(0);
            sb.Append(tsecs).Append('.');
            if (tfrac < 10) sb.Append(0);
            sb.Append(tfrac);

            timer.text = sb.ToString();
        }
    }

    public void Stop()
    {
        stopped = true;

        float btime = bsecs + (bmin * 60);
        float ttime = tsecs + (tmin * 60);

        btime += (bfrac / 100f);
        ttime += (tfrac / 100f);

        if (ttime > btime)
        {
            Debug.LogFormat("{0} > {1}", ttime, btime);
            PlayerPrefs.SetInt("BestTimeMin", tmin);
            PlayerPrefs.SetInt("BestTimeSecs", tsecs);
            PlayerPrefs.SetInt("BestTimeFraction", tfrac);

            bestTimeText.text = timer.text;
        }
    }

    [ContextMenu("Reset Best Time")]
    public void ResetBestTime()
    {
        PlayerPrefs.DeleteKey("BestTimeMin");
        PlayerPrefs.DeleteKey("BestTimeSecs");
        PlayerPrefs.DeleteKey("BestTimeFraction");
        Debug.Log("Best Time Reset.");
    }
}
