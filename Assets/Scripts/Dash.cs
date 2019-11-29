using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField] private PlayerMobileControll playerMove;
    [SerializeField] private PlayerDamage playerDamage;

    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    public bool allreadyDash;

    IEnumerator DashOn()
    {
        playerDamage.ChangeInvincible(true);
        playerMove.speed = dashSpeed;
        allreadyDash = true;

        yield return new WaitForSeconds(dashTime);

        playerDamage.ChangeInvincible(false);
        allreadyDash = false;
    }

    public void StartDash()
    {
        if (allreadyDash)
            return;

        StartCoroutine(DashOn());
    }
}
