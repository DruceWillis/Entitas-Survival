using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Unity.Mathematics;
using UnityEngine;

public class SpellCastingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private SpellConfig _config;
    private InputManagerComponent _inputManager;

    public Dictionary<eLightSpellType, LightSpell> _lightSpellsMap;
    public Dictionary<eStrongSpellType, StrongSpell> _strongSpellsMap;

    private float _lmbTimer;
    private float _rmbTimer;
    private float _iceSpearTimer;
    
    public SpellCastingSystem(Contexts contexts)
    {
        _contexts = contexts;
        _config = _contexts.game.gameConfig.value.SpellConfig;
        _lightSpellsMap = _config.LightSpellsMap;
        _strongSpellsMap = _config.StrongSpellsMap;
        _inputManager = _contexts.input.inputManager;
    }

    public void Execute()
    {
        _lmbTimer = _lmbTimer <= 0 ? 0 : _lmbTimer - Time.deltaTime;
        _rmbTimer = _rmbTimer <= 0 ? 0 : _rmbTimer - Time.deltaTime;
        _iceSpearTimer = _iceSpearTimer <= 0 ? 0 : _iceSpearTimer - Time.deltaTime;

        if (_lmbTimer <= 0 && (_inputManager.lmbIsPressed || _inputManager.lmbWasPressed))
        {
            CastLightSpell();
        }

        if (_rmbTimer <= 0 && _inputManager.rmbWasPressed)
        {
            CastStrongSpell();
        }

        // if (_iceSpearTimer <= 0 && _contexts.game.playerEntity.levelProgression.level >= 3)
        // {
        //     CastProjectile(_config.IceSpear.Prefab, _config.IceSpear.Damage);
        // }
    }

    private (GameEntity, GameObject) CastSpell(GameObject prefab, int damage, bool spawnAtMousePos = true)
    {
        Vector3 spawnPos = spawnAtMousePos
            ? _inputManager.mouseWorldPosition
            : _contexts.game.playerEntity.view.value.transform.position;
            
        var go = Object.Instantiate(prefab, spawnPos, quaternion.identity);
        var e = _contexts.game.CreateEntity();
        
        e.AddView(go);
        e.AddAnimator(go.GetComponent<Animator>());
        e.isDestroyed = false;
        e.AddSpell(damage);
        go.Link(e);

        return (e, go);
    }

    private void CastProjectile(GameObject prefab, int damage)
    {
        _iceSpearTimer = _config.IceSpearCooldown;
        
        var entityWithGameObject = CastSpell(prefab, damage, false);
        entityWithGameObject.Item1.isPlayerProjectile = true;
        entityWithGameObject.Item1.AddDisplacement(Vector3.right);
        entityWithGameObject.Item1.AddMovable(entityWithGameObject.Item2.GetComponent<Rigidbody2D>());
        
        Debug.Log("Casting Projectile!!!");
    }
    
    private void CastLightSpell()
    {
        _lmbTimer = _config.LMBSpellCooldown;
        var spell = _lightSpellsMap[eLightSpellType.Explosion];
        
        CastSpell(spell.Prefab, spell.Damage);
            
        _contexts.game.playerEntity.animator.value.SetTrigger(Constants.CastedLightSpell);
    }
    
    private void CastStrongSpell()
    {
        _rmbTimer = _config.RMBSpellCooldown;
        var spell = _strongSpellsMap[eStrongSpellType.StrongExplosion];
        
        CastSpell(spell.Prefab, spell.Damage);
            
        _contexts.game.playerEntity.animator.value.SetTrigger(Constants.CastedStrongSpell);
    }
}
