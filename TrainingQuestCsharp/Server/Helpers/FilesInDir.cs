using TrainingQuestCsharp.Shared.Models;

namespace TrainingQuestCsharp.Server.Helpers
{
    public static class FilesInDir
    {
        public static List<string> Paths = new List<string>();
        public static void TraverseDirectory(string folderPath)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
            var subdirectories = directoryInfo.EnumerateDirectories();

            foreach (var subdirectory in subdirectories)
            {
                TraverseDirectory(subdirectory.FullName);
            }

            var files = directoryInfo.EnumerateFiles();

            foreach (var file in files)
            {
                HandleFile(file);
            }
        }

        public static void HandleFile(FileInfo file)
        {
            Paths.Add(file.FullName);
        }
    }
}
