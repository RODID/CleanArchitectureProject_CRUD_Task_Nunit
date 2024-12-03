//using Infrastructure.Database;
//using MediatR;
//using Application.Queries.Login.TokenHelper;

//namespace Application.Queries.Login
//{
//    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
//    {
//        private readonly FakeDatabase _fakeDatabase;
//        private readonly TokenHelper _tokenHelper;

//        public LoginUserQueryHandler(FakeDatabase fakeDatabase, TokenHelper tokenHelper)
//        {
//            _fakeDatabase = fakeDatabase;
//            _tokenHelper = tokenHelper;
//        }

//        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
//        {

//        }
//    }
//}
