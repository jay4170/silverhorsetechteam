using silverhorse.Business_Logic;
using silverhorse.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CollectionService
{
    private readonly Posts _posts;
    private readonly Albums _albums;
    private readonly Users _users;

    public CollectionService(Posts posts, Albums albums, Users users)
    {
        _posts = posts;
        _albums = albums;
        _users = users;
    }
    //todo fix this
    public async Task<List<BaseCollectionItem>> GetCollectionAsync()
    {
        var posts = await _posts.GetPostListAsync();
        var albums = await _albums.GetAlbumListAsync();
        var users = await _users.GetUserListAsync();

        var random = new Random();

        var collection = new List<BaseCollectionItem>();

        for (int i = 0; i < 30; i++)
        {
            var post = new List<BasePostDto> { posts[random.Next(posts.Count)] };
            var album = new List<BaseAlbumDto> { albums[random.Next(albums.Count)] };
            var user = new List<UserDto> { users[random.Next(users.Count)] };

            collection.Add(new BaseCollectionItem
            {
                Post = post,
                Album = album,
                User = user
            });
        }

        return collection;
    }
}
