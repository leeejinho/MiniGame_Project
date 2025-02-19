using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum objType { Coin, Bomb, Chest }

public class ObjectController : MonoBehaviour
{
    [SerializeField] private objType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch (type)
            {
                case objType.Coin: // ÄÚÀÎ È¹µæ
                    {
                        ResourceController resourceController = collision.GetComponent<ResourceController>();
                        if (resourceController != null)
                        {
                            resourceController.GetGold(1);
                        }

                        Destroy(gameObject);
                    }
                    break;
                case objType.Bomb: // Ã¼·Â °¨¼Ò
                    {
                        ResourceController resourceController = collision.GetComponent<ResourceController>();
                        if (resourceController != null)
                        {
                            resourceController.ChangeHealth(-1);
                        }

                        Destroy(gameObject);
                    }
                    break;
                case objType.Chest:
                    {
                        ResourceController resourceController = collision.GetComponent<ResourceController>();
                        if (resourceController != null)
                        {
                            resourceController.GetGold(100);
                        }

                        Animator anim = GetComponentInChildren<Animator>();
                        anim.SetBool("IsOpen", true);

                        MiniGameManager.Instance.GameOver();
                    }
                    break;
            }

        }
    }
}
