﻿using ClassLibrary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Books
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {

    }
}
