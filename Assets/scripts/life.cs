using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class life : MonoBehaviour
{
    public int Lives;
    public GameObject LoseScreen;
    float TimeSinceDamage;
    float DamgeInterval;
    bool Damaged=false;
    public static int EnemiesKilled;
    [SerializeField] TextMeshProUGUI LiveText;
    [SerializeField] TextMeshProUGUI EnemiesKilledText;
    // Start is called before the first frame update
    void Start()
    {
        life.EnemiesKilled = 0;
        Lives = 10;
        LoseScreen.SetActive(false);
        Time.timeScale = 1;
        DamgeInterval = 1.5f;
        TimeSinceDamage = 0;
        Damaged = false;
        LiveText.text = "Vidas: " + Lives;
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesKilledText.text = "Eliminated: " + EnemiesKilled;
        if (Lives<=0) {
            LoseScreen.SetActive(true);
            Invoke("StartLose",2.0f);
        }
        if (Damaged) {
            TimeSinceDamage += Time.deltaTime;
            if (TimeSinceDamage > DamgeInterval) {
                TimeSinceDamage = 0;
                Damaged = false;
            }
        }
    }

    public void takeDamage() {
        if (!Damaged) {
            Damaged = true;
            Lives -= 1;
            LiveText.text = "Life: " + Lives;
        }
    }
    public void StartLose() {
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
}
