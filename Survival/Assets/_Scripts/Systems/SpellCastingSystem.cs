using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Unity.Mathematics;
using UnityEngine;

public class SpellCastingSystem : IExecuteSystem
{
    private Contexts _contexts;
    private float _lmbTimer;
    private float _rmbTimer;
    public Dictionary<eLightSpellType, LightSpell> _lightSpellsMap;
    public Dictionary<eStrongSpellType, StrongSpell> _strongSpellsMap;
    private GameConfig _config;
    private InputManagerComponent _inputManager;

    public SpellCastingSystem(Contexts contexts)
    {
        _contexts = contexts;
        _config = _contexts.game.gameConfig.value;
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
    }

    private void CastLightSpell()
    {
        _lmbTimer = _config.LMBSpellCooldown;
        var go = Object.Instantiate(_lightSpellsMap[eLightSpellType.Explosion].Prefab, 
            _inputManager.mouseWorldPosition,
            quaternion.identity);
        var e = _contexts.game.CreateEntity();
        
        e.AddView(go);
        e.AddAnimator(go.GetComponent<Animator>());
        e.isDestroyed = false;
        e.isSpell = true;
        go.Link(e);
        
        _contexts.game.playerEntity.animator.value.SetTrigger(Constants.CastedLightSpell);
    }
}
