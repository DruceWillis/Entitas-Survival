//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventListenertInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public interface ILevelProgressionListener {
    void OnLevelProgression(GameEntity entity, int level, int currentEXP, int nextLevelRequiredEXP);
}