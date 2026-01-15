using BStorm.Tools.Database;
using ExempleDalBll.Dal.Entities;
using ExempleDalBll.Dal.Mappers;
using ExempleDalBll.Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleDalBll.Dal.Services
{
    public class ProduitService : IProduitRepository
    {
        private readonly DbConnection _dbConnection;

        public ProduitService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _dbConnection.Open();
        }

        public IEnumerable<Produit> Get()
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit;", dr => dr.ToProduit()).ToList();
        }

        public Produit? Get(int id)
        {
            return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Id = @Id;", dr => dr.ToProduit(), parameters: new { id }).SingleOrDefault();
        }

        public bool Insert(Produit produit)
        {
            return 1 == _dbConnection.ExecuteNonQuery("INSERT INTO Produit (Nom, Prix) VALUES (@Nom, @Prix);", parameters: new { produit.Nom, produit.Prix });
        }

        public bool Update(Produit produit)
        {
            return 1 == _dbConnection.ExecuteNonQuery("UPDATE Produit SET Nom = @Nom, Prix = @Prix WHERE Id = @Id;", parameters: produit);
        }

        public bool Delete(int id)
        {
            return 1 == _dbConnection.ExecuteNonQuery("DELETE FROM Produit WHERE Id = @Id;", parameters: new { id });
        }
    }
}
