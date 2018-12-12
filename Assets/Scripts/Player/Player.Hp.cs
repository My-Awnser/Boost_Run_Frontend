﻿using System.Collections;
using UnityEngine;

public partial class Player : MonoBehaviour {

    private const float decreaseBaseSpeed = 1800f;

    private float hp;
    public float decreaseHp, decreaseTime;

    private bool bAlive;

    private IEnumerator UpdateHp() {
        WaitUntil waitBelowDecreaseBaseSpeed = new WaitUntil(() => speed < decreaseBaseSpeed);

        while (bAlive) {
            yield return waitBelowDecreaseBaseSpeed;
            yield return CoroutineStorage.WaitForSeconds(decreaseTime);

            if (speed < decreaseBaseSpeed)
                Hp -= decreaseHp;
        }

        manager.GameOver();
    }

    public float Hp {
        get { return hp; }
        set {
            if (value <= 0f) {
                bAlive = false;
                value = 0f;
            }

            else if (value > 1f) value = 1f;

            hp = value;
            hpUi.UpdateUi(hp);
        }
    }
}
