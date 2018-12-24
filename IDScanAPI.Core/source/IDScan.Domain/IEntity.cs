namespace IDScan.Domain {
    using System;

    internal interface IEntity {
        Guid Id { get; }
    }
}