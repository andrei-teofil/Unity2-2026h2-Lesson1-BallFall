using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    // static variables are stored "globally"
    // (don't depend on the instance of the object they are defined on)
    private static int level = 1;
    private static int bestLevel = 1;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI bestText;

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level:" + level;
        bestText.text = "Best:" + bestLevel;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("badPlatform"))
        {
            level = 1;
            SceneManager.LoadScene("SampleScene");
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            level++;
            if(level > bestLevel)
            {
                bestLevel = level;
            }
            SceneManager.LoadScene("SampleScene");
        }
    }
}
