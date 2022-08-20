using AutoMapper;

namespace NZWalks.Api.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
                .ReverseMap();

            //Now we have to inject this mapping profile in Program.cs
        }
    }
}
