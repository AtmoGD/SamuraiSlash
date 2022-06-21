using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    void TakeDamage(int _damage);
    void TakeDamage(int _damage, Samurai _attacker);
}
