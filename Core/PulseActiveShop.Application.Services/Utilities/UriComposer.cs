using Microsoft.Extensions.Configuration;

namespace PulseActiveShop.Application.Services.Utilities
{
    public interface IUriComposer
    {
        string ComposePictureUri(string? imageName);
    }

    public class UriComposer : IUriComposer
    {
        private readonly string _imageBaseUrl;

        public UriComposer(IConfiguration configuration)
        {
            this._imageBaseUrl = configuration["BlobStorage:ImageUrl"] ?? throw new ArgumentNullException("Blob connection string cannot be null");
        }
        public string ComposePictureUri(string? imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                return string.Empty;

            return Path.Combine(this._imageBaseUrl, imageName);
        }
    }
}
