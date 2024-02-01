using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;
    [SerializeField] private GameObject[] _pausePanels;

    private bool _isPause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ChagePauseMenuState();
    }

    public void ChagePauseMenuState()
    {
        _currentPanel = _pausePanels[0];

        foreach(var panal in _pausePanels) panal.SetActive(false);

        _isPause = !_isPause;
        _currentPanel.SetActive(_isPause);

        Cursor.visible = _isPause;
        Cursor.lockState = _isPause ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ChangePanel(GameObject selectedPanal)
    {
        _currentPanel.SetActive(false);
        selectedPanal.SetActive(true);

        _currentPanel = selectedPanal;
    }
}
