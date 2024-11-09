using System;
using System.Collections.Generic;
using System.Text;

namespace StoryTeller.Logic.Interfaces
{
    public interface IFile
    {
        void SaveFile(string fileName, string text);
        string LoadFile(string fileName);
        bool FileExists(string fileName);
        void DeleteFile(string fileName);
    } 
}
