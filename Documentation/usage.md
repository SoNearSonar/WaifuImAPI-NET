# Using WaifuImAPI-NET
WaifuImAPI-NET is a C# API wrapper for Waifu.IM's API. It supports the following functions from the API:
- Getting images
- Getting tags and full tags
- Getting, inserting, deleting, and toggling favorites

## Images
Below are examples of C# API calls for getting images:

Getting image(s) with default settings:
```csharp
WaifuClient client = new WaifuClient();
WaifuImImageList imageList = await client.GetImagesAsync();

foreach (WaifuImImage image in imageList.Images)
{
	Console.WriteLine("Image URL: " + image.Url);
	Console.WriteLine("Image Source: " + image.Source);
	Console.WriteLine("Image Width: " + image.Width);
	Console.WriteLine("Image Height: " + image.Height);
}
```

Getting image(s) with user-set settings:
```csharp
WaifuClient client = new WaifuClient();
WaifuImSearchSettings settings = new WaifuImSearchSettings()
{
	ManyFiles = true,
	IncludedTags = new Tags[]
	{
		Tags.Waifu,
		Tags.Maid
	},
	IsNsfw = false
};
WaifuImImageList imageList = await client.GetImagesAsync();

foreach (WaifuImImage image in imageList.Images)
{
	Console.WriteLine("Image URL: " + image.Url);
	Console.WriteLine("Image Source: " + image.Source);
	Console.WriteLine("Image Width: " + image.Width);
	Console.WriteLine("Image Height: " + image.Height);
}
```

## Tags
Below are examples of C# API calls for getting tags:

Getting list of simple tags (not full tags):
```csharp
WaifuClient client = new WaifuClient();
WaifuImTagList tagList = await client.GetTagsAsync();

foreach (Tags tag in tagList.VersatileTags)
{
	Console.WriteLine("Tag name: " + tag.ToString());
}
```

Getting list of full tags:
```csharp
WaifuClient client = new WaifuClient();
WaifuImFullTagList tagList = await client.GetFullTagsAsync();

foreach (WaifuImTag tag in tagList.VersatileTags)
{
	Console.WriteLine("Tag name: " + tag.Name);
	Console.WriteLine("Tag ID: " + tag.TagId);
	Console.WriteLine("Tag description: " + tag.Description);
	Console.WriteLine("Tag is NSFW?: " + tag.IsNsfw);
}
```

## Favorites
Below are examples of C# API calls for utilizing favorites:

NOTE: Favorites requires getting an Authorization token and storing it somewhere in any projects that are made. It is not recommended to store it as plain-text or on a open source repository. More information can be found [here]()

### Get Favorites
Getting list of favorited images:
```csharp
WaifuImClient client = new WaifuImClient();
string token = "token";
WaifuImImageList favImageList = client.GetFavoritesAsync(token);

foreach (WaifuImImage image in favImageList.Images)
{
	Console.WriteLine("Image URL: " + image.Url);
	Console.WriteLine("Image Source: " + image.Source);
	Console.WriteLine("Image Width: " + image.Width);
	Console.WriteLine("Image Height: " + image.Height);
}
```

Getting list of favorited images with user-set settings:
```csharp
WaifuImClient client = new WaifuImClient();
WaifuImSearchSettings settings = new WaifuImSearchSettings()
{
	IsNsfw = false
};
string token = "token";
WaifuImImageList favImageList = client.GetFavoritesAsync(token, settings);

foreach (WaifuImImage image in favImageList.Images)
{
	Console.WriteLine("Image URL: " + image.Url);
	Console.WriteLine("Image Source: " + image.Source);
	Console.WriteLine("Image Width: " + image.Width);
	Console.WriteLine("Image Height: " + image.Height);
}
```

### Insert Favorites
Adding a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient();
string token = "token";
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};
WaifuImFavorite favorite = await client.InsertFavoriteAsync(token, settings);
```

NOTE: A WaifuImFavoriteSettings object is required to use this method call. If the favorited image exists an exception will be thrown.

### Delete Favorites
Removing a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient();
string token = "token";
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};
WaifuImFavorite favorite = await client.DeleteFavoriteAsync(token, settings)
```

NOTE: A WaifuImFavoriteSettings object is required to use this method call. If the favorited image does not exist an exception will be thrown.

### Toggle Favorites
Changing a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient();
string token = "token";
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};
WaifuImFavorite favorite = await client.ToggleFavoriteAsync(token, settings);
```