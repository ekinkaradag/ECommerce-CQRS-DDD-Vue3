using NSubstitute;
using ECommerce.Domain.Customers;

namespace ECommerce.UnitTests.Customers
{
    public class CustomerFactory
    {
        public static Customer Create()
        {
            var customerUniquenessChecker = Substitute.For<ICustomerUniquenessChecker>();
            var email = "customeremail.com";
            customerUniquenessChecker.IsUnique(email).Returns(true);

            return Customer.CreateRegistered(email, "Name", customerUniquenessChecker);
        }
    }
}