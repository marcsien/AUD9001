﻿using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class DeleteInputCommand : CommandBase<Input, Input>
    {
        public async override Task<Input> Execute(AUD9001StorageContext context)
        {
            context.Inputs.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
