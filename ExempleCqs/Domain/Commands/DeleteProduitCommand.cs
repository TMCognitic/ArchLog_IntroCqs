using Tools.Cqs.Commands;

namespace ExempleCqs.Domain.Commands
{
    public sealed class DeleteProduitCommand : ICommandDefinition
    {
        public int Id { get; }

        public DeleteProduitCommand(int id)
        {
            Id = id;
        }
    }
}
