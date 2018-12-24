namespace IDScan.Domain.Customers {
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System;

    public sealed class AccountCollection {
        private readonly IList<Guid> _accountIds;

        public AccountCollection () {
            _accountIds = new List<Guid> ();
        }

        public IReadOnlyCollection<Guid> ToReadOnlyCollection () {
            IReadOnlyCollection<Guid> accountIds = new ReadOnlyCollection<Guid> (_accountIds);
            return accountIds;
        }

        public void Add (Guid accountId) {
            _accountIds.Add (accountId);
        }
    }
}