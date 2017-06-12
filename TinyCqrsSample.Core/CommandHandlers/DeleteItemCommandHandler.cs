using System;
using TinyCqrsSample.Core.Commands;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Storage;

namespace TinyCqrsSample.Core.CommandHandlers
{
    public class DeleteItemCommandHandler:ICommandHandler<DeleteItemCommand>
    {
        private readonly IRepository<DiaryItem> _repository;

        public DeleteItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(DeleteItemCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException("command");
            }
            if(_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }

            var aggregateRoot = _repository.GetById(command.Id);
            aggregateRoot.Delete();
            _repository.Save(aggregateRoot, aggregateRoot.Version);
        }
    }
}
