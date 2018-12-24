namespace IDScan.Infrastructure {
    public class AccountNotFoundException : InfrastructureException {
        internal AccountNotFoundException (string message) : base (message) { }
    }
}