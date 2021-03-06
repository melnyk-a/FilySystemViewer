﻿using FileSystemViewer.Logic.Objects.FileSystemEntries;
using FileSystemViewer.Logic.Objects.FileSystemEntries.Repositories;
using System.Collections.Generic;

namespace FileSystemViewer.Logic.Iterators
{
    internal sealed class ForwardIterator : FileSystemIterator
    {
        public ForwardIterator(FileSystemEntry entry) :
            base(entry)
        {
        }

        protected override IEnumerable<NextItem> CreateSearchFunctions()
        {
            return new NextItem[] { NextChild, NextSibling, NextRelativeDegree };
        }

        private bool HasChild
        {
            get
            {
                bool hasChild = false;

                Repository childRepository = Current.Repository;
                if (childRepository != null && childRepository.IsExpand)
                {
                    hasChild = true;
                }

                return hasChild;
            }
        }

        private bool HasSibling
        {
            get
            {
                bool hasSibling = false;

                if (Current.Parent != null)
                {
                    Repository parentRepository = Current.Parent.Repository;
                    if (parentRepository.Entries.Count > 1)
                    {
                        hasSibling = true;
                    }
                }

                return hasSibling;
            }
        }

        private bool HasRelativeDegree(FileSystemEntry entry)
        {
            bool hasRelativeDegree = false;

            if (entry.Parent != null && entry.Parent.Parent != null)
            {
                hasRelativeDegree = true;
            }

            return hasRelativeDegree;
        }



        private FileSystemEntry NextChild(FileSystemEntry entry)
        {
            FileSystemEntry nextChild = null;

            if (HasChild)
            {
                nextChild = entry.Repository.Entries[0];
            }

            return nextChild;
        }

        private FileSystemEntry NextRelativeDegree(FileSystemEntry entry)
        {
            FileSystemEntry nextRelativeDegree = null;

            if (HasRelativeDegree(entry))
            {
                Repository parentRepository;
                parentRepository = entry.Parent.Parent.Repository;
                int index = parentRepository.Entries.IndexOf(entry.Parent);
                if (index == parentRepository.Entries.Count - 1)
                {
                    nextRelativeDegree = NextRelativeDegree(entry.Parent);
                }
                else
                {
                    nextRelativeDegree = parentRepository.Entries[index + 1];
                }
            }

            return nextRelativeDegree;
        }

        private FileSystemEntry NextSibling(FileSystemEntry entry)
        {
            FileSystemEntry nextSibling = null;

            if (HasSibling)
            {
                Repository parentRepository = entry.Parent.Repository;
                int index = parentRepository.Entries.IndexOf(Current);
                if (index < parentRepository.Entries.Count - 1)
                {
                    nextSibling = parentRepository.Entries[index + 1];
                }
            }

            return nextSibling;
        }
    }
}