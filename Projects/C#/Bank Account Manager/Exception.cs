using System;

class InvalidPasswordFormat : Exception {

  public InvalidPasswordFormat() {}
  public InvalidPasswordFormat(string error) : base(error) {}

}

class CustomerAccountNotFound : Exception {

  public CustomerAccountNotFound() { }
  public CustomerAccountNotFound(string whereDidItGo) : base(whereDidItGo) { }
  
}

class NegativeDollarAmount : Exception {

  public NegativeDollarAmount() { }
  public NegativeDollarAmount(string minus) : base(minus) { }
  
}

class InsufficientFunds : Exception {

  public InsufficientFunds() { }
  public InsufficientFunds(string broke) : base(broke) { }
  
}