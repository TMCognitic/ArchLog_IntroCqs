using BStorm.Tools.Database;
using ExempleCqs.Domain.Commands;
using ExempleCqs.Domain.Entities;
using ExempleCqs.Domain.Mappers;
using ExempleCqs.Domain.Queries;
using ExempleCqs.Domain.Repositories;
using System.Data.Common;

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
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit;", dr => dr.ToProduit()).ToList();
        }

        public Produit? Execute(GetProduitByIdQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Id = @Id;", dr => dr.ToProduit(), parameters: query).SingleOrDefault();
        }

        public bool Execute(AddProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("INSERT INTO Produit (Nom, Prix) VALUES (@Nom, @Prix);", parameters: command);
        }

        public bool Execute(UpdateProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("UPDATE Produit SET Nom = @Nom, Prix = @Prix WHERE Id = @Id;", parameters: command);
        }

        public bool Execute(DeleteProduitCommand command)
        {
            return 1 == _dbConnection.ExecuteNonQuery("DELETE FROM Produit WHERE Id = @Id;", parameters: command);
        }

        public IEnumerable<Produit> Execute(GetProduitParNomQuery query)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Nom LIKE CONCAT(N'%', @Fragment, N'%');", dr => dr.ToProduit(), parameters:query).ToList();
        }
    }
}
