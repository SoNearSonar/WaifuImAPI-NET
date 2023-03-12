using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refit;
using WaifuImAPI_NET.Models;

namespace WaifuImAPI_NET.Tests;

[TestClass]
public class WaifuImAPI_Net_Test
{
    private readonly string token = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
    private readonly string invalidToken = "invalid_token";

    [TestMethod]
    public void TestGetImage_ReturnsImageJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImImageList imageList = client.GetImagesAsync().Result;
        Assert.IsNotNull(imageList);
    }

    [TestMethod]
    public void TestGetImageWithSettings_ReturnsImageJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImSearchSettings settings = new WaifuImSearchSettings()
        {
            ManyFiles = true,
            IncludedTags = new Tags[]
            {
                Tags.Waifu,
                Tags.Maid
            },
            IsNsfw = null
        };

        WaifuImImageList imageList = client.GetImagesAsync(settings).Result;
        Assert.IsNotNull(imageList);
        Assert.IsTrue(imageList.Images.Count == 30);
    }

    [TestMethod]
    public void TestGetTags_ReturnsTagsJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImTagList tagList = client.GetTagsAsync().Result;

        Assert.IsNotNull(tagList);
        Assert.IsTrue(tagList.VersatileTags.Length == 8);
        Assert.IsTrue(tagList.NsfwTags.Length == 7);

        Assert.IsTrue(tagList.VersatileTags[0].Equals(Tags.Maid));
        Assert.IsTrue(tagList.NsfwTags[5].Equals(Tags.Ecchi));
    }

    [TestMethod]
    public void TestGetFullTags_ReturnsTagsJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFullTagList tagList = client.GetFullTagsAsync().Result;

        Assert.IsNotNull(tagList);
        Assert.IsTrue(tagList.VersatileTags.Length == 8);
        Assert.IsTrue(tagList.NsfwTags.Length == 7);

        Assert.IsTrue(tagList.VersatileTags[0].TagId == 13);
        Assert.IsTrue(tagList.VersatileTags[0].Name.Equals("maid"));
        Assert.IsTrue(tagList.VersatileTags[0].Description.Equals("Cute womans or girl employed to do domestic work in their working uniform."));
        Assert.IsTrue(tagList.VersatileTags[0].IsNsfw == false);

        Assert.IsTrue(tagList.NsfwTags[5].TagId == 2);
        Assert.IsTrue(tagList.NsfwTags[5].Name.Equals("ecchi"));
        Assert.IsTrue(tagList.NsfwTags[5].Description.Equals("Slightly explicit sexual content. Show full to partial nudity. Doesn't show any genital."));
        Assert.IsTrue(tagList.NsfwTags[5].IsNsfw == true);
    }

    [Ignore]
    [TestMethod]
    public void GetFavoritesValidToken_ReturnsImageJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImSearchSettings settings = new WaifuImSearchSettings()
        {
            IsNsfw = false,
            ManyFiles = false
        };

        WaifuImImageList imageList = client.GetFavoritesAsync(token, settings).Result;
        Assert.IsNotNull(imageList);
        Assert.IsTrue(imageList.Images.Count != 0);
    }

    [TestMethod]
    public void GetFavoritesEmptyToken_ReturnsNoImageJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImSearchSettings settings = new WaifuImSearchSettings()
        {
            IsNsfw = false,
        };

        try
        {
            WaifuImImageList imageList = client.GetFavoritesAsync(null, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [TestMethod]
    public void GetFavoritesInvalidToken_ReturnsNoImageJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImSearchSettings settings = new WaifuImSearchSettings()
        {
            IsNsfw = false,
        };

        try
        {
            WaifuImImageList imageList = client.GetFavoritesAsync(invalidToken, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [Ignore]
    [TestMethod]
    public void InsertFavoriteValidToken_ReturnsFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8005
        };
        WaifuImFavorite favorite = client.InsertFavoriteAsync(token, settings).Result;
        Assert.IsNotNull(favorite);
        Assert.IsTrue(favorite.FavoriteStatus == FavoriteStatus.Inserted);
    }

    [TestMethod]
    public void InsertFavoriteEmptyToken_ReturnsNoFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.InsertFavoriteAsync(null, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [TestMethod]
    public void InsertFavoriteInvalidToken_ReturnsNoFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.InsertFavoriteAsync(invalidToken, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [Ignore]
    [TestMethod]
    public void DeleteFavoriteValidToken_ReturnsFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8007
        };
        WaifuImFavorite favorite = client.DeleteFavoriteAsync(token, settings).Result;
        Assert.IsNotNull(favorite);
        Assert.IsTrue(favorite.FavoriteStatus == FavoriteStatus.Deleted);
    }

    [TestMethod]
    public void DeleteFavoriteEmptyToken_ReturnsNoFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.InsertFavoriteAsync(null, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [TestMethod]
    public void DeleteFavoriteInvalidToken_ReturnsNoFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.InsertFavoriteAsync(invalidToken, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [Ignore]
    [TestMethod]
    public void ToggleFavoriteValidToken_ReturnsFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8007
        };
        WaifuImFavorite favorite = client.ToggleFavoriteAsync(token, settings).Result;
        Assert.IsNotNull(favorite);
    }

    [TestMethod]
    public void ToggleFavoriteEmptyToken_ReturnsFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.ToggleFavoriteAsync(null, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }

    [TestMethod]
    public void DeleteFavoriteInvalidToken_ReturnsFavoriteStatusJSON()
    {
        WaifuImClient client = new WaifuImClient();
        WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
        {
            ImageId = 8006
        };

        try
        {
            WaifuImFavorite favorite = client.ToggleFavoriteAsync(invalidToken, settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is ApiException);
        }
    }
}