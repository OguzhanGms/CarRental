using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHelper
    {
        public static async Task<IDataResult<string>> CarImageUpload(IFormFile formFile)
        {
            var getExtension = Path.GetExtension(formFile.FileName).ToLower();
            var isImage = IsImage(getExtension);
            if (isImage.Result.Success)
            {
                var imageName = Guid.NewGuid() + getExtension;
                var imagePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + FilePaths.CarImagesPath,
                    imageName);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }

                string imagePathAndName = FilePaths.CarImagesPath + "\\" + imageName;

                return new SuccessDataResult<string>(data: imagePathAndName);
            }

            return new ErrorDataResult<string>("Seçtiğiniz dosya resim uzantılı değil");
        }

        public static async Task<IDataResult<string>> CarImageUpdate(string filePath, IFormFile file)
        {
            var deleted = CarImageDelete(filePath).Result;
            if (!deleted.Success)
            {
                return new ErrorDataResult<string>(message: deleted.Message);
            }

            var uploaded = CarImageUpload(file).Result;
            if (!uploaded.Success)
            {
                return new ErrorDataResult<string>(message: uploaded.Message);
            }
            return new SuccessDataResult<string>(data:uploaded.Data);
        }

        public static async Task<IResult> CarImageDelete(string filePath)
        {
            var isExists = File.Exists(Directory.GetParent(Directory.GetCurrentDirectory()) + filePath);
            if (isExists)
            {
                File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + filePath);
                return new SuccessResult();
            }

            return new ErrorResult("Dosya bulunamadı");
        }

        private static async Task<IResult> IsImage(string extension)
        {
            string[] extensions = {".jpg", ".jpeg", "png"};
            if (extensions.Contains(extension))
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}