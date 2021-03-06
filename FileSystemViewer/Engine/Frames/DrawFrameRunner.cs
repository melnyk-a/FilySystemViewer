﻿using FileSystemViewer.Engine.Components;

namespace FileSystemViewer.Engine.Frames
{
    internal sealed class DrawFrameRunner : FrameRunner
    {
        public DrawFrameRunner(IComponentProvider componentProvider) :
            base(componentProvider)
        {
        }

        protected override Layer Layer => Layers.Draw;

        public override int RunOrder => RunOrders.Draw;
    }
}