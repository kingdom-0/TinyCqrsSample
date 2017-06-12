using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Commands;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Storage;

namespace TinyCqrsSample.Core.CommandHandlers
{
    public class ChangeItemCommandHandler:ICommandHandler<ChangeItemCommand>
    {
        private readonly IRepository<DiaryItem> _repository;

        public ChangeItemCommandHandler(IRepository<DiaryItem> repository)
        {
            _repository = repository;
        }

        public void Execute(ChangeItemCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException("command");
            }
            if(_repository == null)
            {
                throw new InvalidOperationException("Repository is not initialized.");
            }
            var aggregate = _repository.GetById(command.Id);
            if(aggregate.Title != command.Title)
            {
                aggregate.ChangeTitle(command.Title);
            }
            if(aggregate.Description != command.Description)
            {
                aggregate.ChangeDescription(command.Description);
            }
            if(aggregate.From != command.From)
            {
                aggregate.ChangeFrom(command.From);
            }
            if(aggregate.To != command.To)
            {
                aggregate.ChangeTo(command.To);
            }

            _repository.Save(aggregate, aggregate.Version);
        }
    }
}
