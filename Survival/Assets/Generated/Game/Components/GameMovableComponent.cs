//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public MovableComponent movable { get { return (MovableComponent)GetComponent(GameComponentsLookup.Movable); } }
    public bool hasMovable { get { return HasComponent(GameComponentsLookup.Movable); } }

    public void AddMovable(UnityEngine.Rigidbody2D newRigidbody2D) {
        var index = GameComponentsLookup.Movable;
        var component = (MovableComponent)CreateComponent(index, typeof(MovableComponent));
        component.rigidbody2D = newRigidbody2D;
        AddComponent(index, component);
    }

    public void ReplaceMovable(UnityEngine.Rigidbody2D newRigidbody2D) {
        var index = GameComponentsLookup.Movable;
        var component = (MovableComponent)CreateComponent(index, typeof(MovableComponent));
        component.rigidbody2D = newRigidbody2D;
        ReplaceComponent(index, component);
    }

    public void RemoveMovable() {
        RemoveComponent(GameComponentsLookup.Movable);
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

    static Entitas.IMatcher<GameEntity> _matcherMovable;

    public static Entitas.IMatcher<GameEntity> Movable {
        get {
            if (_matcherMovable == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Movable);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMovable = matcher;
            }

            return _matcherMovable;
        }
    }
}