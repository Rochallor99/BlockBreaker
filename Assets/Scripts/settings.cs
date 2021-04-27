using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class settings : MonoBehaviour
{
    [SerializeField] Dropdown resolutionDropdown;
    Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;  // total 12 resolution options;  24 in PC because of refreshRate
        resolutions = resolutions.OrderByDescending(res => res.refreshRate).ToArray();
        DefineResolutions();
        
    }
    void DefineResolutions()
    {
        List<string> options = new List<string>();
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == 60)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;
                if (i >= 5)
                    options.Add(option);
            }

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
                resolutionDropdown.value = currentResolutionIndex;
            }
        }
        resolutionDropdown.AddOptions(options);

        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex+5];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

  
}
