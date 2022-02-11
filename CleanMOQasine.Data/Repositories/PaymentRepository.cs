using CleanMOQasine.Data.Entities;

namespace CleanMOQasine.Data.Repositories
{
    public class PaymentRepository
    {
        private readonly CleanMOQasineContext _context;
        public PaymentRepository()
        {
        }

        public Payment GetPaymentById(int id)
            => _context.Payments.FirstOrDefault(g => g.Id == id && !g.IsDeleted);

        public IEnumerable<Payment> GetAllPayments()
            => _context.Payments.Where(p => !p.IsDeleted).ToList();

        public void DeletePayment(int id)
        {
            var oldPayment = _context.Payments.FirstOrDefault(p => p.Id == id);
            oldPayment.IsDeleted = true;
            _context.SaveChanges();
        }

        public void UpdatePayment(Payment newPayment)
        {
            var oldPayment = _context.Payments.FirstOrDefault(p => p.Id == newPayment.Id);
            oldPayment = newPayment;
            _context.SaveChanges();
        }

        public void AddPayment(Payment newPayment)
        {
            _context.Payments.Add(newPayment);
            _context.SaveChanges();
        }
    }
}
