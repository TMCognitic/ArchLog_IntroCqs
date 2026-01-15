using BStorm.Tools.Database;
using ExempleCqs.Domain.Commands;
using ExempleCqs.Domain.Entities;
using ExempleCqs.Domain.Mappers;
using ExempleCqs.Domain.Queries;
using ExempleCqs.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleCqs.Domain.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly DbConnection _dbConnection;

        public ProduitService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public IEnumerable<Produit> Execute(GetAllProduitQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit", dr => dr.ToProduit()).ToList();
        }

        public Produit? Execute(GetProduitByIdQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Id = @Id", dr => dr.ToProduit(), parameters: query).SingleOrDefault();
        }

        public bool Execute(AddProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("INSERT INTO Produit (Nom, Prix) VALUES (@Nom, @Prix);", parameters: command);
        }
    }
}
