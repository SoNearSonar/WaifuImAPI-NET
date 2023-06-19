using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaifuImAPI_NET.Models;

namespace WaifuImAPI_NET.Tests;

public class WaifuImAPI_Net_Test
{
    private readonly static string token = string.Empty;

    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void TestGetImage_ReturnsImage()
        {
            WaifuImClient client = new WaifuImClient();

            WaifuImImageList imageList = client.GetImagesAsync().Result;

            Assert.IsNotNull(imageList);
        }

        [TestMethod]
        public void TestGetImageWithSettings_SpecificFile_ReturnsImage()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImSearchSettings settings = new WaifuImSearchSettings()
            {
                IncludedFiles = new string[]
                {
                    "8108"
                }
            };

            WaifuImImageList imageList = client.GetImagesAsync(settings).Result;
            
            Assert.IsNotNull(imageList);
            Assert.IsTrue(imageList.Images.Count == 1);
            Assert.IsNotNull(imageList.Images[0].Artist);
        }

        [TestMethod]
        public void TestGetImageWithSettings_ReturnsImage()
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
                Height = ">1000",
                Width = "<1000",
                ByteSize = ">500000",
                Orientation = Orientation.Random,
                IsNsfw = null
            };

            WaifuImImageList imageList = client.GetImagesAsync(settings).Result;

            Assert.IsNotNull(imageList);
            Assert.IsNotNull(imageList.Images);
        }
    }

    [TestClass]
    public class TagTest
    {
        [TestMethod]
        public void TestGetTags_ReturnsTags()
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
        public void TestGetFullTags_ReturnsTags()
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
    }

    [TestClass]
    public class GetFavoriteTest
    {
        // This test requires a token to use. Also is reliant on images within an account being favorites
        [Ignore]
        [TestMethod]
        public void GetFavoritesValidToken_ReturnsImage()
        {
            WaifuImClient client = new WaifuImClient(string.Empty);
            WaifuImSearchSettings settings = new WaifuImSearchSettings()
            {
                IsNsfw = false,
                ManyFiles = false
            };

            WaifuImImageList imageList = client.GetFavoritesAsync(settings).Result;

            Assert.IsNotNull(imageList);
            Assert.IsTrue(imageList.Images.Count != 0);
        }

        [TestMethod]
        public void GetFavoritesEmptyToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImSearchSettings settings = new WaifuImSearchSettings()
            {
                IsNsfw = false,
            };

            try
            {
                WaifuImImageList imageList = client.GetFavoritesAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void GetFavoritesInvalidToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient("invalid_token");
            WaifuImSearchSettings settings = new WaifuImSearchSettings()
            {
                IsNsfw = false,
            };

            try
            {
                WaifuImImageList imageList = client.GetFavoritesAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }

    [TestClass]
    public class InsertFavoriteTest
    {
        // This test requires a token from an account to use. Also is reliant on an image ID favorite not within said account to exist
        [Ignore]
        [TestMethod]
        public void InsertFavoriteValidToken_ReturnsFavoriteStatus()
        {
            WaifuImClient client = new WaifuImClient("api_key_here");
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8005
            };

            WaifuImFavorite favorite = client.InsertFavoriteAsync(settings).Result;

            Assert.IsNotNull(favorite);
            Assert.IsTrue(favorite.FavoriteStatus == FavoriteStatus.Inserted);
        }

        [TestMethod]
        public void InsertFavoriteEmptyToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.InsertFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void InsertFavoriteInvalidToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient("invalid_token");
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.InsertFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }

    [TestClass]
    public class DeleteFavoriteTest
    {
        // This test requires a token from an account to use. Also is reliant on an image ID favorite within said account to exist
        [Ignore]
        [TestMethod]
        public void DeleteFavoriteValidToken_ReturnsFavoriteStatus()
        {
            WaifuImClient client = new WaifuImClient("api_key_here");
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8005
            };

            WaifuImFavorite favorite = client.DeleteFavoriteAsync(settings).Result;

            Assert.IsNotNull(favorite);
            Assert.IsTrue(favorite.FavoriteStatus == FavoriteStatus.Deleted);
        }

        [TestMethod]
        public void DeleteFavoriteEmptyToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.InsertFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void DeleteFavoriteInvalidToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.InsertFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }

    [TestClass]
    public class ToggleFavoriteTest
    {
        // This test requires a token from an account to use. Also is reliant on an image ID to exist
        [Ignore]
        [TestMethod]
        public void ToggleFavoriteValidToken_ReturnsFavoriteStatus()
        {
            WaifuImClient client = new WaifuImClient("api_key_here");
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8005
            };

            WaifuImFavorite favorite = client.ToggleFavoriteAsync(settings).Result;

            Assert.IsNotNull(favorite);
        }

        [TestMethod]
        public void ToggleFavoriteEmptyToken_ReturnsError()
        {
            WaifuImClient client = new WaifuImClient();
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.ToggleFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }

        [TestMethod]
        public void DeleteFavoriteInvalidToken_ReturnsFavoriteStatusJSON()
        {
            WaifuImClient client = new WaifuImClient("invalid_token");
            WaifuImFavoriteSettings settings = new WaifuImFavoriteSettings()
            {
                ImageId = 8006
            };

            try
            {
                WaifuImFavorite favorite = client.ToggleFavoriteAsync(settings).Result;
                Assert.Fail("This test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsTrue(ex.InnerException is HttpRequestException);
            }
        }
    }
}