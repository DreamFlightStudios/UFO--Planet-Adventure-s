using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("PausePanals")]
    [SerializeField] private GameObject _currentPanal;
    [SerializeField] private GameObject[] _pausePanals;

    private bool _isPauseMenuActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ChagePauseMenuState();
    }

    public void ChagePauseMenuState()
    {
        _currentPanal = _pausePanals[0];

        _isPauseMenuActive = !_isPauseMenuActive;
        _currentPanal.SetActive(_isPauseMenuActive);

        if (_isPauseMenuActive)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;

            foreach(var panal in _pausePanals) panal.SetActive(false);
        }
    }

    public void ChagePanal(GameObject selectedPanal)
    {
        _currentPanal.SetActive(false);
        selectedPanal.SetActive(true);

        _currentPanal = selectedPanal;
    }
}
