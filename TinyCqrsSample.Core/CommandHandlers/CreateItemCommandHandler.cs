using System;
using TinyCqrsSample.Core.Commands;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Storage;

namespace TinyCqrsSample.Core.CommandHandlers
{
    public class CreateItemCommandHandler:ICommandHandler<CreateItemCommand>
    {
        private readonly IRepository<DiaryItem> _repository;

        public CreateItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(CreateItemCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException("command");
            }
            if(_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = new DiaryItem(command.Id, command.Title, command.Description, command.From, command.To)
            {
                Version = -1
            };
            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
