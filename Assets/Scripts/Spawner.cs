using System.Collections;
using System.Collections.Generic;
using com.mycompany;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject gotchiPrefab;
    public GameObject gotchiPlayerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int playerGotchiId = 20952;

        int[] npcGotchiIds = {
            8364, 13974, 2674, 23496,
            5702, 23098, 24941, 16980, 13209
        };

        for (int i = 0; i < npcGotchiIds.Length; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 10f);
            GameObject gotchi = Instantiate(gotchiPrefab, position, Quaternion.identity);
            GotchiUI gotchiUi = gotchi.GetComponent<GotchiUI>();
            gotchiUi.SetCurrentGotchi(npcGotchiIds[i]);
        }

        Vector3 playerPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 10f);
        GameObject playerGotchi = Instantiate(gotchiPlayerPrefab, playerPosition, Quaternion.identity);
        GotchiUI playerGotchiUi = playerGotchi.GetComponent<GotchiUI>();
        playerGotchiUi.SetCurrentGotchi(playerGotchiId);
    }
}
