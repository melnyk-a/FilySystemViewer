﻿using FileSystemViewer.Engine.Input;
using FileSystemViewer.Logic.Managers.Entries;
using FileSystemViewer.Logic.Managers.Refreshes;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;

namespace FileSystemViewer.Logic.Behaviors.UpdateBehaviors.MoveBehaviors
{
    internal sealed class MoveRightBehavior : MoveBehavior
    {
        public MoveRightBehavior(
            ISelectedManager selectedManager, 
            IPressedKeysProvider pressedKeys, 
            IRefreshProvider refreshProvider
        ) :
            base(selectedManager, pressedKeys, refreshProvider)
        {
        }

        protected override Key Key => Key.RightArrow;

        protected override void ProcessMove(ISelectedManager selectedManager)
        {
            Repository repository = selectedManager.Item.GetRepository();
            if (repository != null)
            {
                repository.IsExpand = true;
            }
        }
    }
}