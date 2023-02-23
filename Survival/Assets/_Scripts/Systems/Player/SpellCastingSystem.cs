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

        if (_lmbTimer <= 0 && (_inputManager.lmbIsPressed || _inputManager.lmbWasPressed))
        {
            CastLightSpell();
        }

        if (_rmbTimer <= 0 && _inputManager.rmbWasPressed)
        {
            CastStrongSpell();
        }
    }

    private void CastSpell(GameObject prefab, int damage)
    {
        var go = Object.Instantiate(prefab, 
            _inputManager.mouseWorldPosition,
            quaternion.identity);
        var e = _contexts.game.CreateEntity();
        e.AddView(go);
        e.AddAnimator(go.GetComponent<Animator>());
        e.isDestroyed = false;
        e.AddSpell(damage);
        go.Link(e);
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
