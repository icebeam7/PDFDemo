using System.Collections.Generic;

using PDFDemo.Models;

namespace PDFDemo.Services
{
    public class ProductService
    {
        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = 0,
                    Name = "Brown eggs",
                    OriginalPrice = 28.1,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/0.jpg",
                },
                new Product()
                {
                    Id = 1,
                    Name = "Sweet fresh stawberry",
                    OriginalPrice = 29.45,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/1.jpg",
                },
                new Product()
                {
                    Id = 2,
                    Name = "Asparagus",
                    OriginalPrice = 18.95,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/2.jpg",
                },
                new Product()
                {
                    Id = 3,
                    Name = "Green smoothie",
                    OriginalPrice = 17.68,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/3.jpg",
                },
                new Product()
                {
                    Id = 4,
                    Name = "Raw legums",
                    OriginalPrice = 17.11,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/4.jpg",
                },
                new Product()
                {
                    Id = 5,
                    Name = "Baking cake",
                    OriginalPrice = 11.14,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/5.jpg",
                },
                new Product()
                {
                    Id = 6,
                    Name = "Pesto with basil",
                    OriginalPrice = 18.19,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/6.jpg",
                },
                new Product()
                {
                    Id = 7,
                    Name = "Hazelnut in black ceramic bowl",
                    OriginalPrice = 27.35,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/7.jpg",
                },
                new Product()
                {
                    Id = 8,
                    Name = "Fresh stawberry",
                    OriginalPrice = 28.59,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/8.jpg",
                },
                new Product()
                {
                    Id = 9,
                    Name = "Lemon and salt",
                    OriginalPrice = 15.79,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/9.jpg",
                },
                new Product()
                {
                    Id = 10,
                    Name = "Homemade bread",
                    OriginalPrice = 17.48,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/10.jpg",
                },
                new Product()
                {
                    Id = 11,
                    Name = "Legums",
                    OriginalPrice = 14.77,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/11.jpg",
                },
                new Product()
                {
                    Id = 12,
                    Name = "Fresh tomato",
                    OriginalPrice = 16.3,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/12.jpg",
                },
                new Product()
                {
                    Id = 13,
                    Name = "Healthy breakfast",
                    OriginalPrice = 13.02,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/13.jpg",
                },
                new Product()
                {
                    Id = 14,
                    Name = "Green beans",
                    OriginalPrice = 28.79,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/14.jpg",
                },
                new Product()
                {
                    Id = 15,
                    Name = "Baked stuffed portabello mushrooms",
                    OriginalPrice = 20.31,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/15.jpg",
                },
                new Product()
                {
                    Id = 16,
                    Name = "Strawberry jelly",
                    OriginalPrice = 14.18,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/16.jpg",
                },
                new Product()
                {
                    Id = 17,
                    Name = "Pears juice",
                    OriginalPrice = 19.49,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/17.jpg",
                },
                new Product()
                {
                    Id = 18,
                    Name = "Fresh pears",
                    OriginalPrice = 15.12,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/18.jpg",
                },
                new Product()
                {
                    Id = 19,
                    Name = "Caprese salad",
                    OriginalPrice = 16.76,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/19.jpg",
                },
                new Product()
                {
                    Id = 20,
                    Name = "Oranges",
                    OriginalPrice = 21.48,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/20.jpg",
                },
                new Product()
                {
                    Id = 21,
                    Name = "Vegan food",
                    OriginalPrice = 29.66,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/21.jpg",
                },
                new Product()
                {
                    Id = 22,
                    Name = "Breakfast with muesli",
                    OriginalPrice = 22.7,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/22.jpg",
                },
                new Product()
                {
                    Id = 23,
                    Name = "Honey",
                    OriginalPrice = 17.01,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/23.jpg",
                },
                new Product()
                {
                    Id = 24,
                    Name = "Breakfast with cottage",
                    OriginalPrice = 14.05,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/24.jpg",
                },
                new Product()
                {
                    Id = 25,
                    Name = "Strawberry smoothie",
                    OriginalPrice = 28.86,
                    PictureUrl = "https://raw.githubusercontent.com/wedeploy-examples/supermarket-web-example/master/ui/assets/images/25.jpg",
                }
            };
        }
    }
}
