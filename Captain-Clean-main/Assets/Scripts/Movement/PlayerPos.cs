using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    private Vector2 defaultStartPosition = new Vector2(-7.16f, 0.24f);

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reload the current scene to apply the new position
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}