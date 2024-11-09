using System.IO;
using System.Text;
using StoryTeller.Logic.Interfaces;
using StoryTellerApp.Droid.Implementations;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(AndroidFile))]
namespace StoryTellerApp.Droid.Implementations
{
    public class AndroidFile : IFile
    {
        public void SaveFile(string fileName, string text)
        {
            var filePath = GetFilePath(fileName);
            File.WriteAllText(filePath, text, Encoding.UTF8);
        }

        private static string GetFilePath(string fileName)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, fileName);
            return filePath;
        }

        public string LoadFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            return File.ReadAllText(filePath);
        }

        public bool FileExists(string fileName)
        {
            var filePath = GetFilePath(fileName);
            return File.Exists(filePath);
        }

        public void DeleteFile(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}