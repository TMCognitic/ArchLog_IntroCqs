// See https://aka.ms/new-console-template for more information
#region Injection de dépendance
using ExempleCqs.Domain.Commands;
using ExempleCqs.Domain.Entities;
using ExempleCqs.Domain.Queries;
using ExempleCqs.Domain.Repositories;
using ExempleCqs.Domain.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<DbConnection, SqlConnection>(sp => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDatabase;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
serviceCollection.AddSingleton<IProduitRepository, ProduitService>();
#endregion

IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

IProduitRepository produitRepository = serviceProvider.GetRequiredService<IProduitRepository>();

//produitRepository.Execute(new AddProduitCommand("Fanta 50cl", 1.5));

foreach (Produit p in produitRepository.Execute(new GetProduitParNomQuery("fa")))
{
    Console.WriteLine($"[{p.Id:D5}] - {p.Nom} ({p.Prix:N2} Euro)");
}

//Produit? produit = produitRepository.Execute(new GetProduitByIdQuery(1002));

//if(produit is not null)
//{
//    Console.WriteLine($"[{produit.Id:D5}] - {produit.Nom} ({produit.Prix:N2} Euro)");
//}
//else
//{
//    Console.WriteLine("Produit non trouvé");
//}