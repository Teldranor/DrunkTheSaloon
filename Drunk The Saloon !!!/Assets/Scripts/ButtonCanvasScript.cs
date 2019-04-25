using UnityEngine;
using System.Collections;

public class ButtonCanvasScript : MonoBehaviour
{

    private TypeCanvas mode = TypeCanvas.DISABLED;
    private GameObject resumeButton;
    private GameObject restartButton;
    private GameObject quitButton;
    private TextMesh text;

    private void Start()
    {
        text = gameObject.GetComponent<TextMesh>();
        resumeButton = transform.GetChild(0).gameObject;
        restartButton = transform.GetChild(1).gameObject;
        quitButton = transform.GetChild(2).gameObject;
    }

    public void changeMode(TypeCanvas newMode)
    {
        if (mode == TypeCanvas.DISABLED)
        {
            gameObject.SetActive(false);
        }
        else if (mode == TypeCanvas.WIN)
        {
            text.text = "Congratulations, you won !";
            gameObject.SetActive(true);
            resumeButton.SetActive(false);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
        }
        else if (mode == TypeCanvas.LOSE)
        {
            text.text = "Game over";
            gameObject.SetActive(true);
            resumeButton.SetActive(false);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
        }
        else if (mode == TypeCanvas.RESUME)
        {
            text.text = "Pause";
            gameObject.SetActive(true);
            resumeButton.SetActive(true);
            restartButton.SetActive(true);
            quitButton.SetActive(true);
        }
    }

    public void resume()
    {
        gameObject.SetActive(false);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}

public enum TypeCanvas
{
    WIN,
    LOSE,
    RESUME,
    DISABLED
}
