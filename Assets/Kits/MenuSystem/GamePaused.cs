using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Timeline.DirectorControlPlayable;

public class GamePaused : MonoBehaviour
{
    [SerializeField] InputActionReference pause;

    public GameObject menuPausa;
    public bool gamePaused = false;

    private void Awake()
    {
        Reanudar();
    }

    private void OnEnable()
    {
        if (pause != null && pause.action != null)
        {
            pause.action.Enable();
        }
    }
        private void OnDisable()
    {
        if (pause != null && pause.action != null)
        {
            pause.action.Disable();
        }
    }

    private void Update()
    {
        if (pause == null || pause.action == null)
        {
            return;
        }

        if (pause.action.WasPressedThisFrame())
        {
            if (gamePaused)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;
        gamePaused = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    private void OnDestroy()
    {
        // Evita que otra escena quede detenida.
        Time.timeScale = 1f;
    }
}
