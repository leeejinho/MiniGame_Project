using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLoopController : MonoBehaviour
{
    [SerializeField] private int bgCount = 3;
    [SerializeField] private int bgWidth = 18;

    private const string bgTag = "Background";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(bgTag))
        {
            Vector3 bgPos = collision.transform.position;
            bgPos.x += bgCount * bgWidth;

            collision.transform.position = bgPos;
        }
    }
}
