namespace IDScan.Application {
    internal sealed class AccountNotFoundException : ApplicationException {
        internal AccountNotFoundException (string message) : base (message) { }
    }
}