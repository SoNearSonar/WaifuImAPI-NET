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
        WaifuImSettings settings = new WaifuImSettings()
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
}