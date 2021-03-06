﻿using FileSystemViewer.Engine.Components;

namespace FileSystemViewer.Engine.Frames
{
    internal sealed class SettingsAdjustmentFrameRunner : FrameRunner
    {
        public SettingsAdjustmentFrameRunner(IComponentProvider componentProvider) :
            base(componentProvider)
        {
        }

        protected override Layer Layer => Layers.Start;

        public override int RunOrder => RunOrders.Start;
    }
}