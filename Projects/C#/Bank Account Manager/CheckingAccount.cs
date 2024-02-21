class CheckingAccount : BankAccount {

  private double withdrawlLimit;

  public CheckingAccount(string n, string uID, string uPass) : base(n, uID, uPass) {
    
    withdrawlLimit = 300.00;
    
  }

  public double getWLimit() {
    return withdrawlLimit;
  }

  public void setWLimit(double limit) {
    withdrawlLimit = limit;
  }
  
}