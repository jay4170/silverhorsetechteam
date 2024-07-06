using silverhorse.Business_Logic;

namespace silverhorse.Dtos
{
    public class BaseCollectionItem
    {
        public List<BasePostDto> Post { get; set; }
        public List<BaseAlbumDto> Album { get; set; }
        public List<UserDto> User { get; set; }
    }

}
