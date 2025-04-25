using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Core.Exceptions.File;
using Core.Exceptions.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Utilities.FileHelper
{
    public sealed class FileHelper : IFileHelper
    {
        BlobStorageSettings _blobStorageSettings;
        string imageUrl;

        public FileHelper(IConfiguration configuration)
        {
            _blobStorageSettings = configuration.GetSection("BlobStorageSettings").Get<BlobStorageSettings>()!;

            imageUrl = string.Format($"https://{_blobStorageSettings.AccountName}.blob.core.windows.net/{_blobStorageSettings.ContainerName}");
        }


        public async Task<ImageRespone> Upload(IFormFile file)
        {
            CheckIfFileExtensionIsImage(Path.GetExtension(file.FileName));

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // BlobServiceClient ile Azure Blob Storage'a bağlantıyı oluşturuyoruz.
            BlobContainerClient containerClient = GetContainerClient(fileName);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            using (var stream = file.OpenReadStream())  
            {
                await blobClient.UploadAsync(file.OpenReadStream(), new BlobHttpHeaders
                {
                    ContentType = file.ContentType
                });
            }

            return new ImageRespone { Name = fileName, Path = string.Format($"{imageUrl}/{fileName}")};
        }


        public async Task Delete(string fileName)
        {
            BlobContainerClient containerClient = GetContainerClient(fileName);

            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            var exists = await blobClient.ExistsAsync();

            if (!exists.Value)
                throw new EntityNotFoundException("Görsel");
           

            await blobClient.DeleteAsync();
        }


        public async Task<ImageRespone> Update(IFormFile file, string fileName)
        {
            await Delete(fileName);

            return await Upload(file);
        }


        public void CheckIfFileEnter(IFormFile? file)
        {
            if (file == null)
                throw new FileNotProvidedException();
        }


        #region BusinessRules

        private void CheckIfFileExtensionIsImage(string extension)
        {
            if (extension != ".jpg" && extension != ".png" && extension != ".jpeg" && extension != ".webp")
                throw new FileNotProvidedException();
        }


        private BlobContainerClient GetContainerClient(string fileName)
        {
            string containerEndpoint = string.Format($"{imageUrl}/{fileName}?{_blobStorageSettings.SasToken}");

            return new BlobContainerClient(new Uri(containerEndpoint));
        }


        #endregion
    }
}
