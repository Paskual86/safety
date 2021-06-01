using Plugin.Media;
using Plugin.Media.Abstractions;
using SafetyBP.Domain.Entities;
using SafetyBP.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SafetyBP.Core
{
    public class SafetyCamera : ISafetyCamera
    {
        public async Task<SafetyCameraResponse> GetPhotoAsync()
        {
            var result = new SafetyCameraResponse();

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                result.CameraNotAvailable = true;
                return result;
            }

            var utcNow = DateTime.UtcNow;
            var nombreFoto = utcNow.ToString("MMddyyyyhhmmss");

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "SafetyBP",
                Name = nombreFoto,
                PhotoSize = PhotoSize.Medium,
                CompressionQuality = 92,
                AllowCropping = true
            });

            if (file == null) return result;

            var stream = file.GetStream();
            var buffer = new byte[16 * 1024];
            var imgBytes = new byte[0];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                imgBytes = ms.ToArray();
            }

            result.Content = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
            result.PathFile = file.Path.ToString();

            return result;
        }
    }
}
