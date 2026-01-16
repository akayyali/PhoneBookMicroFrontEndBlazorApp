using Contacts.Domain.Entities;
using PhoneBook.Kernel.Data.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Contacts.Domain.Specifications
{
    public class GetContactsSpecification : Specification<Contact, GetContactsSpecification>
    {
        //private readonly Guid contactId = Guid.;
        private readonly Expression<Func<Contact, bool>> _predicate;

        public GetContactsSpecification()
        {
            _predicate = Contact => true== true;
        }

        public GetContactsSpecification(Guid contactId)
        {
            _predicate = Contact => Contact.Id == contactId;
        }
        public GetContactsSpecification(Expression<Func<Contact, bool>> predicate)
        {
            _predicate = predicate;
        }

        public override Expression<Func<Contact, bool>> ToExpression()
        {
            return _predicate;
        }
    }
}
