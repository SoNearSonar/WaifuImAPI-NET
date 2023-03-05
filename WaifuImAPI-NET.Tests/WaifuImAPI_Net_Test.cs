using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaifuImAPI_NET.Models.Enums;
using WaifuImAPI_NET.Models.Objects;

namespace WaifuImAPI_NET.Tests;

[TestClass]
public class WaifuImAPI_Net_Test
{
    [TestMethod]
    public void TestGetImage_ReturnsImageJSON()
    {
        WaifuImManager manager = new WaifuImManager();
        WaifuImImageList imageList = manager.GetImages().Result;
        Assert.IsNotNull(imageList);
    }

    [TestMethod]
    public void TestGetImageWithSettings_ReturnsImageJSON()
    {
        WaifuImManager manager = new WaifuImManager();
        WaifuImImageSettings settings = new WaifuImImageSettings()
        {
            ManyFiles = true,
            IncludedTags = new Tags[]
            {
                Tags.Waifu,
                Tags.Maid
            },
            IsNsfw = null
        };

        WaifuImImageList imageList = manager.GetImages(settings).Result;
        Assert.IsNotNull(imageList);
        Assert.IsTrue(imageList.Images.Count == 30);
    }

    [TestMethod]
    public void TestGetTags_ReturnsTagsJSON()
    {
        WaifuImManager manager = new WaifuImManager();
        WaifuImTagList tagList = manager.GetTags().Result;

        Assert.IsNotNull(tagList);
        Assert.IsTrue(tagList.VersatileTags.Length == 8);
        Assert.IsTrue(tagList.NsfwTags.Length == 7);

        Assert.IsTrue(tagList.VersatileTags[0].Equals(Tags.Maid));
        Assert.IsTrue(tagList.NsfwTags[5].Equals(Tags.Ecchi));
    }

    [TestMethod]
    public void TestGetFullTags_ReturnsTagsJSON()
    {
        WaifuImManager manager = new WaifuImManager();
        WaifuImFullTagList tagList = manager.GetFullTags().Result;

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

    // This test is dependent on a file that stores a token inside and if the account has at least 1 favorite
    // It is here for reference only
    [Ignore]
    [TestMethod]
    public void GetFavoritesValidToken_ReturnsImageJSON()
    {
        string token = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
        WaifuImManager manager = new WaifuImManager(token);
        WaifuImImageSettings settings = new WaifuImImageSettings()
        {
            IsNsfw = false,
        };

        WaifuImImageList imageList = manager.GetFavourites(settings).Result;
        Assert.IsNotNull(imageList);
        Assert.IsTrue(imageList.Images.Count != 0);
    }

    [TestMethod]
    public void GetFavoritesNoToken_ReturnsNoImageJSON()
    {
        WaifuImManager manager = new WaifuImManager();
        WaifuImImageSettings settings = new WaifuImImageSettings()
        {
            IsNsfw = false,
        };

        try
        {
            WaifuImImageList imageList = manager.GetFavourites(settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is HttpRequestException);
            Assert.IsTrue(ex.InnerException.Message.Equals("GetFavourites() requires a token to use"));
        }
    }

    [TestMethod]
    public void GetFavoritesEmnptyToken_ReturnsNoImageJSON()
    {
        WaifuImManager manager = new WaifuImManager("");
        WaifuImImageSettings settings = new WaifuImImageSettings()
        {
            IsNsfw = false,
        };

        try
        {
            WaifuImImageList imageList = manager.GetFavourites(settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is HttpRequestException);
            Assert.IsTrue(ex.InnerException.Message.Equals("GetFavourites() requires a token to use"));
        }
    }

    [TestMethod]
    public void GetFavoritesInvalidToken_ReturnsNoImageJSON()
    {
        WaifuImManager manager = new WaifuImManager("sample_invalid_token");
        WaifuImImageSettings settings = new WaifuImImageSettings()
        {
            IsNsfw = false,
        };

        try
        {
            WaifuImImageList imageList = manager.GetFavourites(settings).Result;
            Assert.Fail("This test case should not go here");
        }
        catch (AggregateException ex)
        {
            Assert.IsTrue(ex.InnerException is HttpRequestException);
        }
    }
}