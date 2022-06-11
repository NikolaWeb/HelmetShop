namespace HelmetShop.Api.Core
{
    public class AppSettings
    {
        public string ConnectionString { get; set; }

        public JwtSettings JwtSettings { get; set; }



        //"ConnectionString": "Data Source=.\\SQLEXPRESS;Initial Catalog=HelmetShopDatabase;Integrated Security=True",
        //  "JwtSettings": {
        //    "Minutes": 60,
        //    "Issuer": "HS_API",
        //    "SecretKey": "tajnikljuc789punokaraktera"
        //  }
    }
}
