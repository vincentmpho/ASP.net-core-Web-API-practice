using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walk_and_Trails_of_SA_API.Models.Domain;
using Walk_and_Trails_of_SA_API.Models.DTO;
using Walk_and_Trails_of_SA_API.Repositories;

namespace Walk_and_Trails_of_SA_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //POST: ?/Api/Images/Upload

        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUploadRequestDto)
        {

            
            ValidateFileUpload(imageUploadRequestDto);

            //check

            if (ModelState.IsValid)
            {

                //COnvert DTO to domain Model

                var imageDomainModel = new Image
                {
                    File = imageUploadRequestDto.File,
                    FileExtension = Path.GetExtension(imageUploadRequestDto.File.FileName),
                    FileSizeInBytes = imageUploadRequestDto.File.Length,
                    FileName = imageUploadRequestDto.FileName,
                    FileDescription = imageUploadRequestDto.FileDescription,
                };

                //use repository to upload image

                await imageRepository.Upload(imageDomainModel);

                return StatusCode(StatusCodes.Status200OK, imageDomainModel);
            }

            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUploadRequestDto)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", "png" };

            //check

            if (!allowedExtensions.Contains(Path.GetExtension(imageUploadRequestDto.File.FileName)))  
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            //check the size

            if (imageUploadRequestDto.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10mb, please upload a smaller size file.");
            }
        }
    }
}
