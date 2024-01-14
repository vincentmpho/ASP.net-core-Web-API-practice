using System.Net;
using Walk_and_Trails_of_SA_API.Models.Domain;

namespace Walk_and_Trails_of_SA_API.Repositories
{
    public interface IImageRepository
    {

        Task<Image>Upload(Image image);
    }
}
