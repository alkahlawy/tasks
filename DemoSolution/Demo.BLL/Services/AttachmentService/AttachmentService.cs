using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> AllowedExtensions = [ ".png", ".jpg", ".jpeg" ];
        const int _maxSize = 2_097_152; // 2 MB

        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        public string? Upload(IFormFile file, string folderName)
        {
            #region Upload Steps
            // 1. Check Extension
            // 2. Check Size
            // 3. Get Located Folder Path
            // 4. Create Unique File Name
            // 5. Create Full Path
            // 6. Create file stream to copy file [Unmanged needed to be disposed]
            // 7. Use stream to copy file to target location
            // 8. Return file name to be stored in database
            #endregion
            var extension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(extension)) return null;

            if (file.Length == 0 || file.Length > _maxSize) return null;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Images");
            var fileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(folderPath, fileName);

            using FileStream fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }
    }
}
