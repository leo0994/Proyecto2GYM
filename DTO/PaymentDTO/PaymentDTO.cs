public class PaymentDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int PaymentMethodId { get; set; }
        public string Status { get; set; }
        public string CouponName { get; set; }
}