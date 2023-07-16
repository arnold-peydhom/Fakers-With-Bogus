//Scaffold-DbContext 'Server=(localdb)\mssqllocaldb;Database=NyamaAppDb;Trusted_Connection=True;MultipleActiveResultSets=true' Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Data
//commande permetant de se connecter a une base de donnees existante
namespace program;

using Bogus;
using NyamaSeed.Data;

public class Program
{
    public static readonly DateTime DateTimeMin = new(2022, 06, 01);
    public static readonly DateTime DateTimeMax = new(2023, 06, 01);

    public static void Main(string[] args)
    {
        var context = new NyamaAppDbContext();

        GenerateFakerData(context);
    }

    public static void GenerateFakerData(NyamaAppDbContext dataBaseContext)
    {
        var boolValues = new bool[] { true, false };
        var faker = new Faker();
        var minValue = 0.0m;
        var maxValue = 100.0m;
        var precision = 2;

        var expenseFaker = new Faker<NyamaSeed.Data.Expense>()
            .RuleFor(x => x.Quantity, f => f.Random.Number(1, 150))
            .RuleFor(x => x.Amount, f => f.Random.Number(1000, 10000))
            .RuleFor(x => x.DateOfExpense, f => f.Date.Between(DateTimeMin, DateTimeMax).Date)
            .RuleFor(x => x.UnitId, f => f.Random.Number(1, 2))
            .RuleFor(x => x.ExpenseTypeId, f => f.Random.Number(1, 14));

        var orderFaker = new Faker<NyamaSeed.Data.Order>()
            .RuleFor(x => x.CreatingDate, f => f.Date.Between(DateTimeMin, DateTimeMax).Date)
            .RuleFor(x => x.IsPayLater, f => f.PickRandom(boolValues))
            .RuleFor(x => x.QuantityOfBags, f => f.Random.Number(20, 100))
            .RuleFor(x => x.ShopId, f => f.Random.Number(1, 1020))
            .RuleFor(x => x.PayementDate, (f, x) =>
            {
                if (x.IsPayLater)
                {
                    return f.Date.Between(DateTimeMin, DateTimeMax);
                }
                else
                {
                    return null;
                }
            });

        var shopFaker = new Faker<NyamaSeed.Data.Shop>()
            .RuleFor(x => x.Name, f => f.Company.CompanyName())
            .RuleFor(x => x.IsProspection, f => f.PickRandom(boolValues))
            .RuleFor(x => x.FirstPhone, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.IsWhatsappFirstPhone, f => f.PickRandom(boolValues))
            .RuleFor(x => x.GpsLongigtude, f => f.Random.Decimal(minValue, maxValue).ToString("f" + precision))
            .RuleFor(x => x.GpsLatitude, f => f.Random.Decimal(minValue, maxValue).ToString("f" + precision))
            .RuleFor(x => x.SecondPhone, f => f.Phone.PhoneNumber())
            .RuleFor(x => x.IsWhatsappSecondPhone, f => f.PickRandom(boolValues))
            .RuleFor(x => x.CreatingDate, f => f.Date.Between(DateTimeMin, DateTimeMax).Date)
            .RuleFor(x => x.JoiningDate, f => f.Date.Between(DateTimeMin, DateTimeMax).Date)
            .RuleFor(x => x.DistrictId, f => f.Random.Number(1, 16));

        var expenses = expenseFaker.Generate(240);

        var shops = shopFaker.Generate(1000);

        foreach (var shop in shops)
        {
            var order = orderFaker.Generate(180);

            foreach(var orders in order)
            {
                shop.Orders.Add(orders);
            }
        }

        dataBaseContext.Expenses.AddRange(expenses);
        dataBaseContext.Shops.AddRange(shops);

        dataBaseContext.SaveChanges();

    }
}
