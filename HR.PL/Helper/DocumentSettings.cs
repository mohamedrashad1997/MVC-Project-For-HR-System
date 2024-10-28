using static NuGet.Packaging.PackagingConstants;

namespace HR.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UplodeFile(IFormFile file , string FolderName)
        {
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);
            string FileName = $"{Guid.NewGuid()}{file.FileName}";
            string FilePath = Path.Combine(FolderPath, FileName);
            using var FS = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(FS);
            return FileName;

        }
    }
}
