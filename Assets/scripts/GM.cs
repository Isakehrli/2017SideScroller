using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    private int _Lives = 3;
    private int _Points;
    public GameObject gameOverSign;


    public Text livesValue;
    public Text pointsValue;

    public void Setlives(int newValue) {
        _Lives = newValue;
        Debug.Log("Lives now equal: " + _Lives);
        livesValue.text = _Lives.ToString();

        if(_Lives == 0)   {
            gameOverSign.SetActive(true);
        }

    }

    public int GetLives() {
        return _Lives;
    }

    public void SetPoints(int newValue) {
        _Points = newValue;
        pointsValue.text = _Points.ToString();
    }   
        public int GetPoints() {
        return _Points;
    }
}
