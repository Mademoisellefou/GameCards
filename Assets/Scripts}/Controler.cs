
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Controler : MonoBehaviour
{
    [SerializeField] private CreatorCrads _Cs;
    void Start()
    {
        _Cs = CreatorCrads.instance;
    }
    public Text Score;
    private void Update()
    {
        if (_Cs.score==4) { SceneManager.LoadScene("Quiz"); }
        Score.text = _Cs.score.ToString();
    }
    public void _Exit() {
        Application.Quit();
    }
}
