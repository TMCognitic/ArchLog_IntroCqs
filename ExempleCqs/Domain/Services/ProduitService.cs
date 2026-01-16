using BStorm.Tools.Database;
using ExempleCqs.CustomErrors;
using ExempleCqs.Domain.Commands;
using ExempleCqs.Domain.Entities;
using ExempleCqs.Domain.Mappers;
using ExempleCqs.Domain.Queries;
using ExempleCqs.Domain.Repositories;
using System.Collections.Generic;
using System.Data.Common;
using Tools.Cqs.Results;

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

        public CqsResult<IEnumerable<Produit>> Execute(GetAllProduitQuery query)
        {
            try
            {
                return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit;", dr => dr.ToProduit()).ToList();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public CqsResult<Produit> Execute(GetProduitByIdQuery query)
        {
            try
            {
                Produit? produit = _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Id = @Id;", dr => dr.ToProduit(), parameters: query).SingleOrDefault();

                if (produit is null)
                    return Errors.ProductNotFound;

                return produit;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public CqsResult Execute(AddProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("INSERT INTO Produits (Nom, Prix) VALUES (@Nom, @Prix);", parameters: command);

                if (rows == 0)
                    return Error.Create("Aucune ligne insérée");

                return CqsResult.Success();            
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public CqsResult Execute(UpdateProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("UPDATE Produit SET Nom = @Nom, Prix = @Prix WHERE Id = @Id;", parameters: command);

                if (rows == 0)
                    return Errors.ProductNotFound;

                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public CqsResult Execute(DeleteProduitCommand command)
        {
            try
            {
                int rows = _dbConnection.ExecuteNonQuery("DELETE FROM Produit WHERE Id = @Id;", parameters: command);

                if (rows == 0)
                    return Errors.ProductNotFound;

                return CqsResult.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public CqsResult<IEnumerable<Produit>> Execute(GetProduitParNomQuery query)
        {
            try
            {
                return _dbConnection.ExecuteReader("SELECT Id, Nom, Prix FROM Produit WHERE Nom LIKE CONCAT(N'%', @Fragment, N'%');", dr => dr.ToProduit(), parameters: query).ToList();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
