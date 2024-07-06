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
            // Randomly select one post, one album, and one user
            var post = posts[random.Next(posts.Count)];
            var album = albums[random.Next(albums.Count)];
            var user = users[random.Next(users.Count)];

            collection.Add(new BaseCollectionItem
            {
                Post = new List<BasePostDto> { post },
                Album = new List<BaseAlbumDto> { album },
                User = new List<UserDto> { user }
            });
        }

        return collection;
    }
}
