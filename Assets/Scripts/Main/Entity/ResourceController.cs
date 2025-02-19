using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimType { Elf, Knight, Lizard }

public class ResourceController : MonoBehaviour
{
    private BaseController baseController;
    private StatHandler statHandler;
    private AnimationHandler animationHandler;

    public RuntimeAnimatorController[] mainAnimController;
    public RuntimeAnimatorController[] runAnimController;
    public AnimType animType { get; private set; }


    public int gold { get; private set; }

    public float CurrentHealth { get; private set; }
    public float MaxHealth => statHandler.Health;

    public AudioClip damageClip;

    private void Awake()
    {
        baseController = GetComponent<BaseController>();
        statHandler = GetComponent<StatHandler>();
        animationHandler = GetComponent<AnimationHandler>();

        animType = AnimType.Elf;
    }

    private void Start()
    {
        gold = 0;
        CurrentHealth = statHandler.Health;
    }

    private void Update()
    {
       
    }

    public bool ChangeHealth(float change)
    {
        if (change == 0)
            return false;

        CurrentHealth += change;
        CurrentHealth = CurrentHealth > MaxHealth ? MaxHealth : CurrentHealth;
        CurrentHealth = CurrentHealth < 0 ? 0 : CurrentHealth;

        if (change < 0)
        {
            animationHandler.Damage();

            //if (damageClip != null)
            //    SoundManager.PlayClip(damageClip);
        }

        if (CurrentHealth <= 0f)
        {
            Death();
        }

        return true;
    }

    public void ChangeAnim(AnimType animType)
    {
        this.animType = animType;
    }

    public void GetGold(int gold)
    {
        this.gold += gold;
    }

    private void Death()
    {
        baseController.Death();
    }

}
