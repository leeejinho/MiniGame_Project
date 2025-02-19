using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Coroutine objRoutine;

    [SerializeField] private List<GameObject> objPrefabs;

    [SerializeField] private float spawnDuration = 7f;
    [SerializeField] private float padding = 2f;

    private float offsetX = 10f;
    private float offsetY = -4f;

    private List<Action> listPattern = new List<Action>();

    private void Awake()
    {
        listPattern.Add(SetObjPattern1);
        listPattern.Add(SetObjPattern2);
    }

    public void StartSpawn()
    {
        objRoutine = StartCoroutine(SpawnObj());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnObj()
    {
        yield return new WaitForSeconds(0.5f);

        while (true)
        {
            listPattern[UnityEngine.Random.Range(0, listPattern.Count)]?.Invoke();
            yield return new WaitForSeconds(spawnDuration);
        }
        
    }

    private void SetObjPattern1()
    {
        Vector3 playerPos = MiniGameManager.Instance.player.transform.position;
        playerPos.x += offsetX;
        playerPos.y = offsetY;

        for (int i = 0; i < 20; i++)
        {
            playerPos.x += padding;

            Instantiate(objPrefabs[(int)objType.Coin], playerPos, Quaternion.identity);
        }
    }

    private void SetObjPattern2()
    {
        Vector3 playerPos = MiniGameManager.Instance.player.transform.position;
        playerPos.x += offsetX;

        for (int i = 0; i < 20; i++)
        {
            playerPos.x += padding;
            playerPos.y = offsetY;

            if (i % 7 == 0 && i != 0)
            {
                Instantiate(objPrefabs[(int)objType.Bomb], playerPos, Quaternion.identity);

                playerPos.y = -1.5f;
                Instantiate(objPrefabs[(int)objType.Coin], playerPos, Quaternion.identity);
            }
            else
                Instantiate(objPrefabs[(int)objType.Coin], playerPos, Quaternion.identity);
        }
    }
}
