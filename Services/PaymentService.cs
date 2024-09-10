

public class PaymentService{

    public int CalculatePayment(int totalMinutes){

        return totalMinutes*(int)(Limit.CHARGE);
    }
}