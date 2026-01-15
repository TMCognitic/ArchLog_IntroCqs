namespace ExempleCqs.Domain.Entities
{
    public class Produit
    {
        public int Id { get; }
        public string Nom { get; set; }
        public double Prix { get; set; }

        internal Produit(int id, string nom, double prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}
