using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Resolution {
    QHD = 0, FHD = 1, HD = 2, SD = 3
}

public class TitleManager : MonoBehaviour {
    [SerializeField] private List<GameObject> optionPanels;

    public void NextScene() {
        SceneManager.LoadScene(1);
    }

    public void OpenPanel(GameObject panel) {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel) {
        panel.SetActive(false);
    }

    public void AllClosePanel() {
        optionPanels.ForEach(x => x.SetActive(false));
    }

    public void SetResolution(int resolution) {
        Resolution res = (Resolution)resolution;
        switch(res) {
            case Resolution.QHD:
                Screen.SetResolution(2560, 1440, true);
                break;
            case Resolution.FHD:
                Screen.SetResolution(1920, 1080, true);
                break;
            case Resolution.HD:
                Screen.SetResolution(1280, 720, true);
                break;
            case Resolution.SD:
                Screen.SetResolution(720, 480, true);
                break;
        }
    }

    public void VSync(bool ison) {
        QualitySettings.vSyncCount = ison ? 1 : 0;
    }

    public void SetVolumeMaster(float volume) {
        SoundManager.Instance.SetVolumeMaster(volume);
    }

    public void SetVolumeBgm(float volume) {
        SoundManager.Instance.SetVolumeBgm(volume);
    }

    public void SetVolumeSFX(float volume) {
        SoundManager.Instance.SetVolumeSFX(volume);
    }
}
