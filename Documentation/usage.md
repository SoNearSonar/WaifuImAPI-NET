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
	Height = ">1000",
	Width = "<1000",
	ByteSize = ">500000",
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

NOTE: Favorites requires getting an Authorization token and storing it somewhere in any projects that are made. It is not recommended to store it as plain-text or on a open source repository. A token can be obtained from logging in [here](https://www.waifu.im/dashboard/)

### Get Favorites
Getting list of favorited images:
```csharp
WaifuImClient client = new WaifuImClient("token");

WaifuImImageList favImageList = client.GetFavoritesAsync();

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
WaifuImClient client = new WaifuImClient("token");
WaifuImSearchSettings settings = new WaifuImSearchSettings()
{
	IsNsfw = false
};

WaifuImImageList favImageList = client.GetFavoritesAsync(settings);

foreach (WaifuImImage image in favImageList.Images)
{
	Console.WriteLine("Image URL: " + image.Url);
	Console.WriteLine("Image Source: " + image.Source);
	Console.WriteLine("Image Width: " + image.Width);
	Console.WriteLine("Image Height: " + image.Height);
}
```

NOTE: A WaifuImFavoriteSettings object is required to use the following method calls and an image ID must be provided. Exceptions will be thrown depending on what happens in an API call

### Insert Favorites
Adding a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient("token");
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};

WaifuImFavorite favorite = await client.InsertFavoriteAsync(settings);
```

### Delete Favorites
Removing a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient("token");
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};

WaifuImFavorite favorite = await client.DeleteFavoriteAsync(settings)
```

### Toggle Favorites
Changing a favorite to your favorites:
```csharp
WaifuImClient client = new WaifuImClient("token");
WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
{
	ImageId = 0001
};
WaifuImFavorite favorite = await client.ToggleFavoriteAsync(settings);
```
