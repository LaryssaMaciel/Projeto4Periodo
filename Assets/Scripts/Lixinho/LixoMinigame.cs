using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LixoMinigame : MonoBehaviour
{
    private int tipo = 0; // 0 = lixeira 1 (papel) // 1 = lixeira 2 (metal) // 2 = lixeira 3 (plástico) // 3 = lixeira 4 (orgânico)
    public Transform[] spawnPoint; // ponto de spawn
    public GameObject[] prefab; // o objeto do lixo
    private GameObject fadecs;

    void Awake() 
    {
        fadecs = GameObject.Find("Fade");
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            spawnPoint[i] = this.transform.GetChild(i).GetComponent<Transform>();
            tipo = Random.Range(0, 4); // escolhe o tipo
            Instantiate(prefab[tipo], spawnPoint[i].position, Quaternion.identity); // spawna
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("lixo").Length <= 0)
        {
            PlayerPrefs.SetString("Minigame_Lixo", "Finalizado");
            fadecs.GetComponent<Fade>().ChangeScene("Hub");
        }
    }
}
