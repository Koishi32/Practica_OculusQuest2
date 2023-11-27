using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class goalReached : MonoBehaviour
{

    [SerializeField] GameObject WinScren;
    private void Start()
    {
        WinScren.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            WinScren.SetActive(true);
            Invoke("Win", 2);
        }
    }

    public void Win() {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
}
