﻿namespace FileSystemViewer.Engine.Components.Behaviors.Factories
{
    internal interface IComponentFactory<TBehavior>
    {
        Component CreateComponent(TBehavior behavior);
    }
}