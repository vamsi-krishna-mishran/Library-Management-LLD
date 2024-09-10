

/// <summary>
/// This service gives the amount to be paid
/// as per the panalty time given in minutes
/// from borrow class.
/// </summary>
public class PaymentService{

    public int CalculatePayment(int totalMinutes){

        return totalMinutes*(int)(Limit.CHARGE);
    }
}