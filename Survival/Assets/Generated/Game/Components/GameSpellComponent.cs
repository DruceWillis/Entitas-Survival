//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public SpellComponent spell { get { return (SpellComponent)GetComponent(GameComponentsLookup.Spell); } }
    public bool hasSpell { get { return HasComponent(GameComponentsLookup.Spell); } }

    public void AddSpell(int newDamage) {
        var index = GameComponentsLookup.Spell;
        var component = (SpellComponent)CreateComponent(index, typeof(SpellComponent));
        component.damage = newDamage;
        AddComponent(index, component);
    }

    public void ReplaceSpell(int newDamage) {
        var index = GameComponentsLookup.Spell;
        var component = (SpellComponent)CreateComponent(index, typeof(SpellComponent));
        component.damage = newDamage;
        ReplaceComponent(index, component);
    }

    public void RemoveSpell() {
        RemoveComponent(GameComponentsLookup.Spell);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherSpell;

    public static Entitas.IMatcher<GameEntity> Spell {
        get {
            if (_matcherSpell == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Spell);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherSpell = matcher;
            }

            return _matcherSpell;
        }
    }
}
